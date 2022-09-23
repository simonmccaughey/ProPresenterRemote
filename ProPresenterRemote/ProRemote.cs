﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public partial class ProRemote : Form
    {

        private static readonly HttpClient client = new HttpClient();
        Boolean pipOn = false;
        Boolean beforeServiceOn = false;
        Boolean SpeakerNameOn = false;

        private Config config = new Config();

        public ProRemote()
        {
            InitializeComponent();
        }

        private void ProRemoteForm_Load(object sender, EventArgs e)
        {
            RestoreState();

            //read the config at startup
            config = Config.ReadConfig();

            //if there is no IP address configured, open the settings dialog
            if (config.Ip == null || config.Ip.Length == 0)
            {
                settingsToolStripMenuItem_Click(sender, e);
            }

            //run a "get version" command, to check connectivity...
            RunAndWait($"http://{config.Ip}:{config.Port}/version");

        }
        private void ProRemote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        private void pipButton_Click(object sender, EventArgs e)
        {
            pipButton.Enabled = false;
            if (pipOn)
            {
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.PipProp.UUID}/clear");
                pipButton.BackColor = Control.DefaultBackColor;
            }
            else
            {
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.PipProp.UUID}/trigger");
                pipButton.BackColor = Color.Red;
            }
            pipOn = !pipOn;

            pipButton.Enabled = true;
        }
        private void btnBeforeService_Click(object sender, EventArgs e)
        {
            btnBeforeService.Enabled = false;

            if (beforeServiceOn)
            {
                //change the look to normal
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/look/{config.NormalLook.UUID}/trigger");

                //clear the prop
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.BeforeServiceProp.UUID}/clear");

                btnBeforeService.BackColor = Control.DefaultBackColor;
            }
            else
            {
                //change the look to the before service look
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/look/{config.BeforeServiceLook.UUID}/trigger");

                //set the prop for before service
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/prop/{config.BeforeServiceProp.UUID}/trigger");

                btnBeforeService.BackColor = Color.Red;
            }
            beforeServiceOn = !beforeServiceOn;

            btnBeforeService.Enabled = true;
        }

        private void btnSpeakerName_Click(object sender, EventArgs e)
        {
            btnSpeakerName.Enabled = false;

            if (SpeakerNameOn)
            {
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/library/{config.SpeakerNameLibrary.UUID}/{config.SpeakerNamePresentation.UUID}/trigger");

                MessageBox.Show("Take 'on air' off now");

                //change the look back to normal
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/look/{config.NormalLook.UUID}/trigger");
                btnSpeakerName.BackColor = Control.DefaultBackColor;

            }
            else
            {
                // run the speaker name animation...
                //change the look 
                RunAndWait($"http://{config.Ip}:{config.Port}/v1/look/{config.SpeakerNameLook.UUID}/trigger");

                MessageBox.Show("Put 'on air' on now");

                RunAndWait($"http://{config.Ip}:{config.Port}/v1/library/{config.SpeakerNameLibrary.UUID}/{config.SpeakerNamePresentation.UUID}/trigger");
                btnSpeakerName.BackColor = Color.Red;

            }

            SpeakerNameOn = !SpeakerNameOn;

            btnSpeakerName.Enabled = true;
        }

        private void RunAndWait(String url)
        {
            try
            {
                var task = client.GetStringAsync(url);
                task.GetAwaiter().GetResult();
                
                Debug.WriteLine("complete: " + task.IsCompleted);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("failed getting: " + url + " with exception: " + e);
                MessageBox.Show("Error running request: " + url + " with exception: " + e);
            }

        }


        /**
         * Open the settings dialog.
         */
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var settingsForm = new SettingsForm();
            var result = settingsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                config = Config.ReadConfig();
            }
            this.Enabled = true;
        }

        private void SaveState()
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainFormLocation = Location;
                Properties.Settings.Default.MainFormSize = Size;
            }
            else
            {
                Properties.Settings.Default.MainFormLocation = RestoreBounds.Location;
                Properties.Settings.Default.MainFormSize = RestoreBounds.Size;
            }
            Properties.Settings.Default.Save();
        }

        private void RestoreState()
        {
            if (Properties.Settings.Default.MainFormSize == new Size(0, 0))
            {
                return; // state has never been saved
            }
            StartPosition = FormStartPosition.Manual;
            Location = Properties.Settings.Default.MainFormLocation;
            Size = Properties.Settings.Default.MainFormSize;
        }


    }
}
