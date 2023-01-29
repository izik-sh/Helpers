namespace ApiTest
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.chkTLS = new System.Windows.Forms.CheckBox();
            this.chkServerCertificateValidationCallback = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tv = new System.Windows.Forms.TreeView();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(20, 80);
            this.txtResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(1154, 241);
            this.txtResults.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(1019, 28);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(157, 35);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(58, 31);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(754, 26);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "https://boi.org.il/PublicApi/GetExchangeRates";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(20, 35);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 20);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "Url";
            // 
            // chkTLS
            // 
            this.chkTLS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTLS.AutoSize = true;
            this.chkTLS.Checked = true;
            this.chkTLS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTLS.Location = new System.Drawing.Point(854, 12);
            this.chkTLS.Name = "chkTLS";
            this.chkTLS.Size = new System.Drawing.Size(97, 24);
            this.chkTLS.TabIndex = 4;
            this.chkTLS.Text = "Use TLS";
            this.chkTLS.UseVisualStyleBackColor = true;
            // 
            // chkServerCertificateValidationCallback
            // 
            this.chkServerCertificateValidationCallback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkServerCertificateValidationCallback.AutoSize = true;
            this.chkServerCertificateValidationCallback.Location = new System.Drawing.Point(851, 42);
            this.chkServerCertificateValidationCallback.Name = "chkServerCertificateValidationCallback";
            this.chkServerCertificateValidationCallback.Size = new System.Drawing.Size(140, 24);
            this.chkServerCertificateValidationCallback.TabIndex = 5;
            this.chkServerCertificateValidationCallback.Text = "Use Certificate";
            this.chkServerCertificateValidationCallback.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 554);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1194, 32);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(169, 25);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(20, 350);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(1154, 180);
            this.tv.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 586);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chkServerCertificateValidationCallback);
            this.Controls.Add(this.chkTLS);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Api Test";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.CheckBox chkTLS;
        private System.Windows.Forms.CheckBox chkServerCertificateValidationCallback;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TreeView tv;
    }
}

