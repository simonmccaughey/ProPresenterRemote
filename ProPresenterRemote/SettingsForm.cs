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
            if (File.Exists("config.json"))
            {
                var configJson = File.ReadAllText("config.json");
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            refreshPPData();
            applyConfig();

        }

        private void applyConfig()
        {
            //need to keep this variable separate, as the event fires when ip address txt is set, clearing the port config variable
            var configPort = config.Port;
            txtIPAddress.Text = config.Ip;
            txtPort.Text = configPort;
            setCombo(cboBeforeServiceLook, config.BeforeServiceLook);
            setCombo(cboNormalLook, config.NormalLook);
            setCombo(cboPIPProp, config.PipProp);
            setCombo(cboBeforeServiceProp, config.BeforeServiceProp);

        }

        private void setCombo(ComboBox combo, ItemData item)
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

        private void refreshPPData()
        {
            cboBeforeServiceProp.Enabled = false;
            cboPIPProp.Enabled = false;
            cboNormalLook.Enabled = false;
            cboBeforeServiceLook.Enabled = false;
            btnSave.Enabled = false;

            if (config.Ip == null || config.Ip.Length == 0)
            {
                return;
            }
            try
            {
                List<ItemData> itemData = runRequest($"http://{config.Ip}:{config.Port}/v1/props");
                cboBeforeServiceProp.Enabled = true;
                cboBeforeServiceProp.Items.Clear();
                cboPIPProp.Enabled = true;
                cboPIPProp.Items.Clear();
                foreach (var item in itemData)
                {
                    cboBeforeServiceProp.Items.Add(item);
                    cboPIPProp.Items.Add(item);
                }

                cboNormalLook.Enabled = true;
                cboNormalLook.Items.Clear();
                cboBeforeServiceLook.Enabled = true;
                cboBeforeServiceLook.Items.Clear();
                itemData = runRequest($"http://{config.Ip}:{config.Port}/v1/looks");
                foreach (var item in itemData)
                {
                    cboBeforeServiceLook.Items.Add(item);
                    cboNormalLook.Items.Add(item);
                }

                btnSave.Enabled = true;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("error connecting to propresenter: " + ex);
            }



        }

        private List<ItemData> runRequest(String url)
        {
            List<ItemData> itemData = new List<ItemData>();

            var propsTask = client.GetStringAsync(url);

            var result = propsTask.GetAwaiter().GetResult();
            Debug.WriteLine(result);

            var data = JsonConvert.DeserializeAnonymousType(result, new[] { new { id = new ItemData() } });

            //Debug.WriteLine(data);

            foreach (var item in data)
            {
                itemData.Add(item.id);
            }

            return itemData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("pip prop    : " + ((ItemData)cboPIPProp.SelectedItem)?.Name + " " + ((ItemData)cboPIPProp.SelectedItem)?.UUID);
            Debug.WriteLine("before prop : " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.Name + " " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.UUID);


            config.PipProp = (ItemData)cboPIPProp.SelectedItem;
            config.BeforeServiceProp = (ItemData)cboBeforeServiceProp.SelectedItem;
            config.BeforeServiceLook = (ItemData)cboBeforeServiceLook.SelectedItem;
            config.NormalLook = (ItemData)cboNormalLook.SelectedItem;


            var configJson = JsonConvert.SerializeObject(config, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Debug.WriteLine(configJson);
            File.WriteAllText("config.json", configJson);
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshPPData();
            applyConfig();
        }

        private void txtIpOrPort_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = (txtIPAddress.Text.Length > 0 && txtPort.Text.Length > 0);
            config.Ip = txtIPAddress.Text.Trim();
            config.Port = txtPort.Text;
        }
    }
}
