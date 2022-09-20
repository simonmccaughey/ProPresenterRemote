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
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(27, 42);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(166, 20);
            this.txtIPAddress.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(225, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(166, 20);
            this.txtPort.TabIndex = 0;
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
            this.label2.Location = new System.Drawing.Point(222, 26);
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
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "PIP Prop";
            // 
            // cboPIPProp
            // 
            this.cboPIPProp.FormattingEnabled = true;
            this.cboPIPProp.Location = new System.Drawing.Point(27, 92);
            this.cboPIPProp.Name = "cboPIPProp";
            this.cboPIPProp.Size = new System.Drawing.Size(364, 21);
            this.cboPIPProp.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Before Service Prop";
            // 
            // cboBeforeServiceProp
            // 
            this.cboBeforeServiceProp.FormattingEnabled = true;
            this.cboBeforeServiceProp.Location = new System.Drawing.Point(27, 140);
            this.cboBeforeServiceProp.Name = "cboBeforeServiceProp";
            this.cboBeforeServiceProp.Size = new System.Drawing.Size(364, 21);
            this.cboBeforeServiceProp.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Before Service Look";
            // 
            // cboBeforeServiceLook
            // 
            this.cboBeforeServiceLook.FormattingEnabled = true;
            this.cboBeforeServiceLook.Location = new System.Drawing.Point(27, 191);
            this.cboBeforeServiceLook.Name = "cboBeforeServiceLook";
            this.cboBeforeServiceLook.Size = new System.Drawing.Size(364, 21);
            this.cboBeforeServiceLook.TabIndex = 2;
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
            this.cboNormalLook.FormattingEnabled = true;
            this.cboNormalLook.Location = new System.Drawing.Point(27, 242);
            this.cboNormalLook.Name = "cboNormalLook";
            this.cboNormalLook.Size = new System.Drawing.Size(364, 21);
            this.cboNormalLook.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(225, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(316, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 336);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
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
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
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
    }
}