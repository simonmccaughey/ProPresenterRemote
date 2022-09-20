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

        public ProRemote()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void pipButton_Click(object sender, EventArgs e)
        {
            if (pipOn)
            {
                runAndWait("http://localhost:1025/v1/prop/3787f15d-b205-4432-83e6-4bb2077948da/clear");
                pipButton.BackColor = Control.DefaultBackColor;
            }
            else
            {
                runAndWait("http://localhost:1025/v1/prop/3787f15d-b205-4432-83e6-4bb2077948da/trigger");
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
            settingsForm.ShowDialog();
            this.Enabled = true;
        }
    }
}
