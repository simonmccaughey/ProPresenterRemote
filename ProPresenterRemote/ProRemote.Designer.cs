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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBeforeService = new System.Windows.Forms.Button();
            this.contextMenu.SuspendLayout();
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
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.btnBeforeService);
            this.Controls.Add(this.pipButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProRemote";
            this.Text = "ProRemote";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button pipButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Button btnBeforeService;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

