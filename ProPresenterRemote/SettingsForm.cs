using Newtonsoft.Json;
using ProPresenterRemote.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public partial class SettingsForm : Form
    {
        private static readonly HttpClient Client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(Settings.Default.HttpTimeout)  
        };

        private Config _config = new Config();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            InitialiseForm();
        }

        private bool InitialiseForm()
        {
            _config = Config.ReadConfig();

            //need to keep this variable separate, as the event fires when ip address txt is set, clearing the port config variable
            var configPort = _config.Port;

            txtIPAddress.Text = _config.Ip;
            txtPort.Text = configPort;

            if (RefreshPpData())
            {
                //only apply the config if the settings refresh was successful (if propresenter is not reachable, refresh will fail)
                ApplyConfig();
                return true;
            }
            else
            {
                return false;
            }

        }

        /**
         * This method is used to refresh the config (since the libraries api returns a different UUID with every propresenter restart)
         */
        public void StartupRefresh()
        {
            if(InitialiseForm())
            {
                //only save on success
                btnSave_Click(null, null);
            }
        }

        /**
         * Apply the current config to the dialog - selects the combo items etc.
         */
        private void ApplyConfig()
        {
            SetCombo(cboBeforeServiceLook, _config.BeforeServiceLook);
            SetCombo(cboNormalLook, _config.NormalLook);
            SetCombo(cboPIPProp, _config.PipProp);
            SetCombo(cboBeforeServiceProp, _config.BeforeServiceProp);
            SetCombo(cboSpeakerLibrary, _config.SpeakerNameLibrary);
            SetCombo(cboSpeakerLook, _config.SpeakerNameLook);
            SetCombo(cboSpeakerPresentation, _config.SpeakerNamePresentation);
            cbClearSlideAfterSpeaker.Checked = _config.SpeakerNameClearSlide;

        }

        private void SetCombo(ComboBox combo, ItemData item)
        {
            if (item != null)
            {
                // name matching used as a backup, in case the ID changes but the name doesnt. This was happening for the speaker library
                ItemData nameMatchItem = null;

                foreach (var cboItem in combo.Items)
                {
                    if (((ItemData)cboItem).Uuid == item.Uuid)
                    {
                        combo.SelectedItem = cboItem;
                        return;
                    }

                    if (((ItemData)cboItem).Name == item.Name)
                    {
                        nameMatchItem = (ItemData)cboItem;
                    }

                }
                //if we get here, the UUID wasnt matched, lets try for a match on the name
                if (nameMatchItem != null)
                {
                    combo.SelectedItem = nameMatchItem;
                }
            }
        }
        /** 
         * Get the latest props and looks data from ProPresenter.         
         */
        private bool RefreshPpData()
        {
            //disable all the items, in case the request fails.
            cboBeforeServiceProp.Enabled = false;
            cboPIPProp.Enabled = false;
            cboNormalLook.Enabled = false;
            cboBeforeServiceLook.Enabled = false;
            btnSave.Enabled = false;
            cbClearSlideAfterSpeaker.Enabled = false;

            if (string.IsNullOrEmpty(_config.Ip))
            {
                // if there is no ip configured, we don't try to reach it
                return false;
            }
            try
            {
                //get all the props, and fill into the 2 combo boxes
                List<ItemData> itemData = RunRequest($"http://{_config.Ip}:{_config.Port}/v1/props");
                cboBeforeServiceProp.Enabled = true;
                cboBeforeServiceProp.Items.Clear();
                cboPIPProp.Enabled = true;
                cboPIPProp.Items.Clear();
                foreach (var item in itemData)
                {
                    cboBeforeServiceProp.Items.Add(item);
                    cboPIPProp.Items.Add(item);
                }


                //now get the looks, and fill the combo boxes
                cboNormalLook.Enabled = true;
                cboNormalLook.Items.Clear();
                cboBeforeServiceLook.Enabled = true;
                cboBeforeServiceLook.Items.Clear();
                cboSpeakerLook.Enabled = true;
                cboSpeakerLook.Items.Clear();
                itemData = RunRequest($"http://{_config.Ip}:{_config.Port}/v1/looks");
                foreach (var item in itemData)
                {
                    cboBeforeServiceLook.Items.Add(item);
                    cboNormalLook.Items.Add(item);
                    cboSpeakerLook.Items.Add(item);
                }

                //now the list of libraries
                cboSpeakerLibrary.Enabled = true;
                cboSpeakerLibrary.Items.Clear();
                itemData = RunRequestBasicList($"http://{_config.Ip}:{_config.Port}/v1/libraries");
                foreach (var item in itemData)
                {
                    cboSpeakerLibrary.Items.Add(item);
                }

                cbClearSlideAfterSpeaker.Enabled = true;
                cbClearSlideAfterSpeaker.Checked = _config.SpeakerNameClearSlide;

                //finally enable the save button
                btnSave.Enabled = true;

            }
            catch (Exception e) when (e is HttpRequestException || e is TaskCanceledException)
            {
                MessageBox.Show($@"error connecting to ProPresenter: {e.Message}");
                return false;
            }
            return true;
        }

        /**
         * Run a request, and return a list of ItemData - this same format is used for looks and props 
         */
        private List<ItemData> RunRequest(string url)
        {
            var itemData = new List<ItemData>();

            var propsTask = Client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new[] { new { id = new ItemData() } });

            Debug.WriteLine(data);

            if (data != null)
            {
                itemData.AddRange(data.Select(item => item.id));
            }

            return itemData;
        }
        private static List<ItemData> RunRequestBasicList(string url)
        {
            var itemData = new List<ItemData>();

            var propsTask = Client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new[] { new ItemData() });

            Debug.WriteLine(data);

            if (data != null) { itemData.AddRange(data); }

            return itemData;
        }
        private static List<ItemData> RunRequestItemList(string url)
        {
            var itemData = new List<ItemData>();

            var propsTask = Client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new { items = new[] { new ItemData() } });

            Debug.WriteLine(data);

            if (data != null) { itemData.AddRange(data.items); }

            return itemData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //NOTE: don't need to set the ip and port, they are set as they get validated and changed in the text boxes

            //get the combo box values
            _config.PipProp = (ItemData)cboPIPProp.SelectedItem;
            _config.BeforeServiceProp = (ItemData)cboBeforeServiceProp.SelectedItem;
            _config.BeforeServiceLook = (ItemData)cboBeforeServiceLook.SelectedItem;
            _config.NormalLook = (ItemData)cboNormalLook.SelectedItem;
            _config.SpeakerNameLibrary = (ItemData)cboSpeakerLibrary.SelectedItem;
            _config.SpeakerNameLook = (ItemData)cboSpeakerLook.SelectedItem;
            _config.SpeakerNamePresentation = (ItemData)cboSpeakerPresentation.SelectedItem;
            _config.SpeakerNameClearSlide = cbClearSlideAfterSpeaker.Checked;

            //save the config 
            Config.WriteConfig(_config);
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow digits and control chars, there must be no alpha chars in the port
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            if (RefreshPpData())
            {
                //only apply if the refresh was successful
                ApplyConfig();
            }
            btnRefresh.Enabled = true;
        }

        private void txtIpOrPort_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = (txtIPAddress.Text.Length > 0 && txtPort.Text.Length > 0);
            _config.Ip = txtIPAddress.Text.Trim();
            _config.Port = txtPort.Text;
        }

        private void cboSpeakerLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSpeakerPresentation.Enabled = true;
            cboSpeakerPresentation.Items.Clear();
            cboSpeakerPresentation.Text = "";
            if (cboSpeakerLibrary.SelectedItem != null)
            {
                var uuid = ((ItemData)cboSpeakerLibrary.SelectedItem).Uuid;

                var itemData = RunRequestItemList($"http://{_config.Ip}:{_config.Port}/v1/library/{uuid}");
                foreach (var item in itemData)
                {
                    cboSpeakerPresentation.Items.Add(item);
                }
            }
        }

    }
}
