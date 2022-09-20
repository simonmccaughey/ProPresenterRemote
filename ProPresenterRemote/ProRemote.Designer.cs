namespace ProPresenterRemote
{
    partial class ProRemote
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProRemote));
            this.pipButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnBeforeService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pipButton
            // 
            this.pipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pipButton.Location = new System.Drawing.Point(12, 12);
            this.pipButton.Name = "pipButton";
            this.pipButton.Size = new System.Drawing.Size(178, 35);
            this.pipButton.TabIndex = 1;
            this.pipButton.Text = "PIP";
            this.pipButton.UseVisualStyleBackColor = true;
            this.pipButton.Click += new System.EventHandler(this.pipButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnBeforeService
            // 
            this.btnBeforeService.Enabled = false;
            this.btnBeforeService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeforeService.Location = new System.Drawing.Point(12, 53);
            this.btnBeforeService.Name = "btnBeforeService";
            this.btnBeforeService.Size = new System.Drawing.Size(178, 35);
            this.btnBeforeService.TabIndex = 1;
            this.btnBeforeService.Text = "Before Service";
            this.btnBeforeService.UseVisualStyleBackColor = true;
            this.btnBeforeService.Click += new System.EventHandler(this.btnBeforeService_Click);
            // 
            // ProRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 97);
            this.Controls.Add(this.btnBeforeService);
            this.Controls.Add(this.pipButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProRemote";
            this.Text = "ProRemote";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button pipButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnBeforeService;
    }
}

