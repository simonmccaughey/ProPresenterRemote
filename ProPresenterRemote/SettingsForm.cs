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
            var propsTask = client.GetStringAsync("http://localhost:1025/v1/props");
            try
            {
                var result = propsTask.GetAwaiter().GetResult();
                Debug.WriteLine(result);

                var data = JsonConvert.DeserializeAnonymousType(result, new[] { new { id = new ItemData() } });

                Debug.WriteLine(data);

                cboBeforeServiceProp.Items.Clear();
                cboPIPProp.Items.Clear();
                foreach (var item in data)
                {
                    cboBeforeServiceProp.Items.Add(item.id);
                    cboPIPProp.Items.Add(item.id);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("error connecting to propresenter: " + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("pip prop    : " + ((ItemData)cboPIPProp.SelectedItem)?.Name + " " + ((ItemData)cboPIPProp.SelectedItem)?.UUID);
            Debug.WriteLine("before prop : " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.Name + " " + ((ItemData)cboBeforeServiceProp.SelectedItem)?.UUID);
        }
    }
}
