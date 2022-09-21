using Newtonsoft.Json;
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
        private static readonly HttpClient client = new HttpClient();
        private Config config = new Config();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            config = Config.ReadConfig();
            RefreshPPData();
            ApplyConfig();
        }

        /**
         * Apply the current config to the dialog - selects the combo items etc.
         */
        private void ApplyConfig()
        {
            //need to keep this variable separate, as the event fires when ip address txt is set, clearing the port config variable
            var configPort = config.Port;

            txtIPAddress.Text = config.Ip;
            txtPort.Text = configPort;
            SetCombo(cboBeforeServiceLook, config.BeforeServiceLook);
            SetCombo(cboNormalLook, config.NormalLook);
            SetCombo(cboPIPProp, config.PipProp);
            SetCombo(cboBeforeServiceProp, config.BeforeServiceProp);
            SetCombo(cboSpeakerLibrary, config.SpeakerNameLibrary);
            SetCombo(cboSpeakerLook, config.SpeakerNameLook);
            SetCombo(cboSpeakerPresentation, config.SpeakerNamePresentation);
            txtSpeakerNameDelayMillis.Text = "" + config.SpeakerSleepMilliseconds;

        }

        private void SetCombo(ComboBox combo, ItemData item)
        {
            if (item != null)
            {
                foreach (var cboItem in combo.Items)
                {
                    if (((ItemData)cboItem).UUID == item.UUID)
                    {
                        combo.SelectedItem = cboItem;
                    }
                }
            }
        }
        /** 
         * Get the latest props and looks data from propresenter.         
         */
        private void RefreshPPData()
        {
            //disable all the items, in case the request fails.
            cboBeforeServiceProp.Enabled = false;
            cboPIPProp.Enabled = false;
            cboNormalLook.Enabled = false;
            cboBeforeServiceLook.Enabled = false;
            btnSave.Enabled = false;

            if (config.Ip == null || config.Ip.Length == 0)
            {
                // if there is no ip configured, we dont try to reach it
                return;
            }
            try
            {
                //get all the props, and fill into the 2 combo boxes
                List<ItemData> itemData = RunRequest($"http://{config.Ip}:{config.Port}/v1/props");
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
                itemData = RunRequest($"http://{config.Ip}:{config.Port}/v1/looks");
                foreach (var item in itemData)
                {
                    cboBeforeServiceLook.Items.Add(item);
                    cboNormalLook.Items.Add(item);
                    cboSpeakerLook.Items.Add(item);
                }

                //now the list of libraries
                cboSpeakerLibrary.Enabled = true;
                cboSpeakerLibrary.Items.Clear();
                itemData = RunRequestBasicList($"http://{config.Ip}:{config.Port}/v1/libraries");
                foreach (var item in itemData)
                {
                    cboSpeakerLibrary.Items.Add(item);
                }


                //finally enable the save button
                btnSave.Enabled = true;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("error connecting to propresenter: " + ex);
            }
        }

        /**
         * Run a request, and return a list of ItemData - this same format is used for looks and props 
         */
        private List<ItemData> RunRequest(String url)
        {
            List<ItemData> itemData = new List<ItemData>();

            var propsTask = client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new[] { new { id = new ItemData() } });

            Debug.WriteLine(data);

            foreach (var item in data)
            {
                itemData.Add(item.id);
            }

            return itemData;
        }
        private List<ItemData> RunRequestBasicList(String url)
        {
            List<ItemData> itemData = new List<ItemData>();

            var propsTask = client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new[] { new ItemData() });

            Debug.WriteLine(data);

            itemData.AddRange(data);

            return itemData;
        }
        private List<ItemData> RunRequestItemList(String url)
        {
            List<ItemData> itemData = new List<ItemData>();

            var propsTask = client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new {items = new[] { new ItemData() } });

            Debug.WriteLine(data);

            itemData.AddRange(data.items);

            return itemData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //NOTE: dont need to set the ip and port, they are set as they get validated and changed in the text boxes

            //get the combo box values
            config.PipProp = (ItemData)cboPIPProp.SelectedItem;
            config.BeforeServiceProp = (ItemData)cboBeforeServiceProp.SelectedItem;
            config.BeforeServiceLook = (ItemData)cboBeforeServiceLook.SelectedItem;
            config.NormalLook = (ItemData)cboNormalLook.SelectedItem;
            config.SpeakerNameLibrary = (ItemData)cboSpeakerLibrary.SelectedItem;
            config.SpeakerNameLook = (ItemData)cboSpeakerLook.SelectedItem;
            config.SpeakerNamePresentation = (ItemData)cboSpeakerPresentation.SelectedItem;
            config.SpeakerSleepMilliseconds = int.Parse("0" + txtSpeakerNameDelayMillis.Text);

            //save the config 
            Config.WriteConfig(config);
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow digits and control chars, there must be no alpha chars in the port
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            RefreshPPData();
            ApplyConfig();
            btnRefresh.Enabled = true;
        }

        private void txtIpOrPort_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = (txtIPAddress.Text.Length > 0 && txtPort.Text.Length > 0);
            config.Ip = txtIPAddress.Text.Trim();
            config.Port = txtPort.Text;
        }

        private void cboSpeakerLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSpeakerPresentation.Enabled = true;
            cboSpeakerPresentation.Items.Clear();
            cboSpeakerPresentation.Text = "";
            if (cboSpeakerLibrary.SelectedItem != null)
            {
                var uuid = ((ItemData)cboSpeakerLibrary.SelectedItem).UUID;

                List<ItemData> itemData = RunRequestItemList($"http://{config.Ip}:{config.Port}/v1/library/{uuid}");
                foreach (var item in itemData)
                {
                    cboSpeakerPresentation.Items.Add(item);
                }
            }
        }
    }
}
