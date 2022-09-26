namespace ProPresenterRemote
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPIPProp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBeforeServiceProp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBeforeServiceLook = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNormalLook = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSpeakerLibrary = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSpeakerPresentation = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSpeakerLook = new System.Windows.Forms.ComboBox();
            this.cbClearSlideAfterSpeaker = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(27, 42);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(135, 20);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIpOrPort_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(183, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(91, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.TextChanged += new System.EventHandler(this.txtIpOrPort_TextChanged);
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ProPresenter IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ProPresenter Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Picture In Picture (PIP) Prop";
            // 
            // cboPIPProp
            // 
            this.cboPIPProp.Enabled = false;
            this.cboPIPProp.FormattingEnabled = true;
            this.cboPIPProp.Location = new System.Drawing.Point(27, 92);
            this.cboPIPProp.Name = "cboPIPProp";
            this.cboPIPProp.Size = new System.Drawing.Size(364, 21);
            this.cboPIPProp.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Before Service Prop";
            // 
            // cboBeforeServiceProp
            // 
            this.cboBeforeServiceProp.Enabled = false;
            this.cboBeforeServiceProp.FormattingEnabled = true;
            this.cboBeforeServiceProp.Location = new System.Drawing.Point(27, 144);
            this.cboBeforeServiceProp.Name = "cboBeforeServiceProp";
            this.cboBeforeServiceProp.Size = new System.Drawing.Size(364, 21);
            this.cboBeforeServiceProp.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Before Service Look";
            // 
            // cboBeforeServiceLook
            // 
            this.cboBeforeServiceLook.Enabled = false;
            this.cboBeforeServiceLook.FormattingEnabled = true;
            this.cboBeforeServiceLook.Location = new System.Drawing.Point(27, 188);
            this.cboBeforeServiceLook.Name = "cboBeforeServiceLook";
            this.cboBeforeServiceLook.Size = new System.Drawing.Size(364, 21);
            this.cboBeforeServiceLook.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Normal Look";
            // 
            // cboNormalLook
            // 
            this.cboNormalLook.Enabled = false;
            this.cboNormalLook.FormattingEnabled = true;
            this.cboNormalLook.Location = new System.Drawing.Point(27, 242);
            this.cboNormalLook.Name = "cboNormalLook";
            this.cboNormalLook.Size = new System.Drawing.Size(364, 21);
            this.cboNormalLook.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(226, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 462);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(295, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Speaker Name Library";
            // 
            // cboSpeakerLibrary
            // 
            this.cboSpeakerLibrary.Enabled = false;
            this.cboSpeakerLibrary.FormattingEnabled = true;
            this.cboSpeakerLibrary.Location = new System.Drawing.Point(27, 297);
            this.cboSpeakerLibrary.Name = "cboSpeakerLibrary";
            this.cboSpeakerLibrary.Size = new System.Drawing.Size(364, 21);
            this.cboSpeakerLibrary.TabIndex = 6;
            this.cboSpeakerLibrary.SelectedIndexChanged += new System.EventHandler(this.cboSpeakerLibrary_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Speaker Name Presentation";
            // 
            // cboSpeakerPresentation
            // 
            this.cboSpeakerPresentation.Enabled = false;
            this.cboSpeakerPresentation.FormattingEnabled = true;
            this.cboSpeakerPresentation.Location = new System.Drawing.Point(27, 343);
            this.cboSpeakerPresentation.Name = "cboSpeakerPresentation";
            this.cboSpeakerPresentation.Size = new System.Drawing.Size(364, 21);
            this.cboSpeakerPresentation.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Speaker Name Look";
            // 
            // cboSpeakerLook
            // 
            this.cboSpeakerLook.Enabled = false;
            this.cboSpeakerLook.FormattingEnabled = true;
            this.cboSpeakerLook.Location = new System.Drawing.Point(27, 389);
            this.cboSpeakerLook.Name = "cboSpeakerLook";
            this.cboSpeakerLook.Size = new System.Drawing.Size(364, 21);
            this.cboSpeakerLook.TabIndex = 6;
            // 
            // cbClearSlideAfterSpeaker
            // 
            this.cbClearSlideAfterSpeaker.AutoSize = true;
            this.cbClearSlideAfterSpeaker.Location = new System.Drawing.Point(27, 416);
            this.cbClearSlideAfterSpeaker.Name = "cbClearSlideAfterSpeaker";
            this.cbClearSlideAfterSpeaker.Size = new System.Drawing.Size(220, 17);
            this.cbClearSlideAfterSpeaker.TabIndex = 9;
            this.cbClearSlideAfterSpeaker.Text = "Clear Slide After Speaker Name Removal";
            this.cbClearSlideAfterSpeaker.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 497);
            this.Controls.Add(this.cbClearSlideAfterSpeaker);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboSpeakerLook);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboSpeakerPresentation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboSpeakerLibrary);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboNormalLook);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboBeforeServiceLook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboBeforeServiceProp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPIPProp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPIPProp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBeforeServiceProp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBeforeServiceLook;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNormalLook;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSpeakerLibrary;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSpeakerPresentation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboSpeakerLook;
        private System.Windows.Forms.CheckBox cbClearSlideAfterSpeaker;
    }
}