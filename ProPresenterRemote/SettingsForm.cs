using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        }
    }
}
