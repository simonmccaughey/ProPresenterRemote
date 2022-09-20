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
    public partial class ProRemote : Form
    {

        private static readonly HttpClient client = new HttpClient();
        Boolean pipOn = false;
        private Config config = new Config();

        public ProRemote()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            config = Config.ReadConfig();
            if(config.Ip == null || config.Ip.Length == 0)
            {
                settingsToolStripMenuItem_Click(sender, e);
            }
        }



        private void pipButton_Click(object sender, EventArgs e)
        {
            if (pipOn)
            {
                runAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.PipProp.UUID}/clear");
                pipButton.BackColor = Control.DefaultBackColor;
            }
            else
            {
                runAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.PipProp.UUID}/trigger");
                pipButton.BackColor = Color.Red;
            }
            pipOn = !pipOn;
        }

        private async void runAndWait(String url)
        {
            try
            {

                var task = client.GetStringAsync(url);
                await task;
                Debug.WriteLine("complete: " + task.IsCompleted);

            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("failed: " + e);
            }

        }


        private void btnBeforeService_Click(object sender, EventArgs e)
        {

        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var settingsForm = new SettingsForm();
           var result= settingsForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                config = Config.ReadConfig();
            }
            this.Enabled = true;
        }
    }
}
