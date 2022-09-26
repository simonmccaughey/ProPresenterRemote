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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public partial class ProRemote : Form
    {

        private static readonly HttpClient Client = new HttpClient();
        
        private bool _pipOn = false;
        private bool _beforeServiceOn = false;
        private bool _speakerNameOn = false;

        private Config _config = new Config();

        public ProRemote()
        {
            InitializeComponent();
        }

        private void ProRemoteForm_Load(object sender, EventArgs e)
        {
            RestoreState();

            //read the config at startup
            _config = Config.ReadConfig();

            //if there is no IP address configured, open the settings dialog
            if (string.IsNullOrEmpty(_config.Ip))
            {
                settingsToolStripMenuItem_Click(sender, e);
            }
         
        }
        private void ProRemote_Shown(object sender, EventArgs e)
        {
            //run a "get version" command, to check connectivity...
            RunAndWait($"http://{_config.Ip}:{_config.Port}/version");
        }
        private void ProRemote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        private void pipButton_Click(object sender, EventArgs e)
        {
            pipButton.Enabled = false;
            if (_pipOn)
            {
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/prop/{_config.PipProp.Uuid}/clear");
                pipButton.BackColor = Control.DefaultBackColor;
            }
            else
            {
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/prop/{_config.PipProp.Uuid}/trigger");
                pipButton.BackColor = Color.Red;
            }
            _pipOn = !_pipOn;

            pipButton.Enabled = true;
        }
        private void btnBeforeService_Click(object sender, EventArgs e)
        {
            btnBeforeService.Enabled = false;

            if (_beforeServiceOn)
            {
                //change the look to normal
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/look/{_config.NormalLook.Uuid}/trigger");

                //clear the prop
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/prop/{_config.BeforeServiceProp.Uuid}/clear");

                btnBeforeService.BackColor = Control.DefaultBackColor;
            }
            else
            {
                //change the look to the before service look
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/look/{_config.BeforeServiceLook.Uuid}/trigger");

                //set the prop for before service
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/prop/{_config.BeforeServiceProp.Uuid}/trigger");

                btnBeforeService.BackColor = Color.Red;
            }
            _beforeServiceOn = !_beforeServiceOn;

            btnBeforeService.Enabled = true;
        }

        private void btnSpeakerName_Click(object sender, EventArgs e)
        {
            btnSpeakerName.Enabled = false;

            if (_speakerNameOn)
            {
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/library/{_config.SpeakerNameLibrary.Uuid}/{_config.SpeakerNamePresentation.Uuid}/trigger");

                MessageBox.Show(@"Take 'on air' off now");

                //clear the slide, if configured
                if (_config.SpeakerNameClearSlide)
                {
                    RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/clear/layer/slide");
                }

                //change the look back to normal
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/look/{_config.NormalLook.Uuid}/trigger");

                btnSpeakerName.BackColor = Control.DefaultBackColor;

            }
            else
            {
                // run the speaker name animation...
                //change the look 
                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/look/{_config.SpeakerNameLook.Uuid}/trigger");

                //clear the slide, if configured
                if (_config.SpeakerNameClearSlide)
                {
                    RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/clear/layer/slide");
                }

                MessageBox.Show(@"Put 'on air' on now");

                RunAndWait($"http://{_config.Ip}:{_config.Port}/v1/library/{_config.SpeakerNameLibrary.Uuid}/{_config.SpeakerNamePresentation.Uuid}/trigger");
                btnSpeakerName.BackColor = Color.Red;

            }

            _speakerNameOn = !_speakerNameOn;

            btnSpeakerName.Enabled = true;
        }

        private void RunAndWait(String url)
        {
            try
            {
                var task = Client.GetStringAsync(url);
                task.GetAwaiter().GetResult();
                
                Debug.WriteLine("complete: " + task.IsCompleted);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine($@"Error running request: {url} with exception: {e}");
                MessageBox.Show($@"Error running request: {url} with exception: {e}");
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
                _config = Config.ReadConfig();
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
