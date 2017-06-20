namespace ChatServer
{
    partial class ServerMainForm
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
            this.btStartServer = new System.Windows.Forms.Button();
            this.btStopServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(99, 67);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(75, 23);
            this.btStartServer.TabIndex = 0;
            this.btStartServer.Text = "Start Server";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Location = new System.Drawing.Point(99, 97);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(75, 23);
            this.btStopServer.TabIndex = 1;
            this.btStopServer.Text = "Stop Server";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btStopServer);
            this.Controls.Add(this.btStartServer);
            this.Name = "ServerMainForm";
            this.Text = "Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
    }
}

