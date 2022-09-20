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

        private class ItemData
        {
            public string UUID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private class Config
        {
            public string ip;
            public int port;
            public ItemData beforeServiceLook;
            public ItemData normalLook;
            public ItemData beforeServiceProp;
            public ItemData pipProp;

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            refreshPPData();


        }

        private void refreshPPData()
        {

            List<ItemData> itemData = runRequest("http://localhost:1025/v1/props");

            cboBeforeServiceProp.Items.Clear();
            cboPIPProp.Items.Clear();
            foreach (var item in itemData)
            {
                cboBeforeServiceProp.Items.Add(item);
                cboPIPProp.Items.Add(item);
            }

            cboNormalLook.Items.Clear();
            cboBeforeServiceLook.Items.Clear();
            itemData = runRequest("http://localhost:1025/v1/looks");
            foreach (var item in itemData)
            {
                cboBeforeServiceLook.Items.Add(item);
                cboNormalLook.Items.Add(item);
            }


        }

        private List<ItemData> runRequest(String url)
        {
            List<ItemData> itemData = new List<ItemData>();

            var propsTask = client.GetStringAsync(url);
            try
            {
                var result = propsTask.GetAwaiter().GetResult();
                Debug.WriteLine(result);

                var data = JsonConvert.DeserializeAnonymousType(result, new[] { new { id = new ItemData() } });

                //Debug.WriteLine(data);

                foreach (var item in data)
                {
                    itemData.Add(item.id);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("error connecting to propresenter: " + ex);
            }

            return itemData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("pip prop    : " + ((ItemData)cboPIPProp.SelectedItem)?.Name + " " + ((ItemData)cboPIPProp.SelectedItem)?.UUID);
            Debug.WriteLine("before prop : " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.Name + " " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.UUID);


            config.ip = txtIPAddress.Text.Trim();
            config.port = int.Parse("0" + txtPort.Text);
            config.pipProp = (ItemData)cboPIPProp.SelectedItem;
            config.beforeServiceProp = (ItemData)cboBeforeServiceProp.SelectedItem;
            config.beforeServiceLook = (ItemData)cboBeforeServiceLook.SelectedItem;
            config.normalLook = (ItemData)cboNormalLook.SelectedItem;


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
        }
    }
}
