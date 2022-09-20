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
        
        public ProRemote()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

        }

        private void Cm_Popup(object sender, EventArgs e)
        {
            var props = new MenuItem("Props");

            getProps(props);



            props.MenuItems.Add("Loading...");
        
        }

        private async void getProps(MenuItem menuItem)
        {

            var stringTask = client.GetStringAsync("http://localhost:1025/v1/props");

            var msg = await stringTask;
            Debug.WriteLine(msg);

            var data = JsonConvert.DeserializeAnonymousType(msg, new[] { new { id = new { uuid = "", name = "" } } });

            menuItem.MenuItems.Clear();
            foreach (var item in data)
            {
                var subItem = menuItem.MenuItems.Add(item.id.name);
                subItem.MenuItems.Add("On").Click += propClick;
                subItem.MenuItems.Add("Off").Click += propClick;
                subItem.Tag = item.id.uuid;

            }

        }

        private void propClick(object sender, EventArgs e)
        {
            if (sender is MenuItem)
            {
                MenuItem menuItem = sender as MenuItem;
                Debug.WriteLine("Prop " + menuItem.Parent.Tag + "  " + menuItem.Text);

            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var stringTask = client.GetStringAsync("http://localhost:1025/v1/props");
            var msg = await stringTask;
            Debug.WriteLine(msg);

            var data = JsonConvert.DeserializeAnonymousType(msg, new[] { new { id = new { uuid = "", name = "" } } });

            Debug.WriteLine(data);

        }


        private void button3_Click(object sender, EventArgs e)
        {
            client.GetStringAsync("http://localhost:1025/v1/prop/3787f15d-b205-4432-83e6-4bb2077948da/clear");

        }

        Boolean pipOn = false;
        private void cbPIP_CheckedChanged(object sender, EventArgs e)
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
    }
}
