namespace WebBrowser
{
    partial class WindowsWebBrowser
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
            this.txtUrlForPanel1 = new System.Windows.Forms.TextBox();
            this.txtUrlForPanel2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.webPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrlForPanel1
            // 
            this.txtUrlForPanel1.Location = new System.Drawing.Point(0, 31);
            this.txtUrlForPanel1.Name = "txtUrlForPanel1";
            this.txtUrlForPanel1.Size = new System.Drawing.Size(390, 31);
            this.txtUrlForPanel1.TabIndex = 1;
            this.txtUrlForPanel1.Leave += new System.EventHandler(this.txtUrlForPanel1_Leave);
            // 
            // txtUrlForPanel2
            // 
            this.txtUrlForPanel2.Location = new System.Drawing.Point(410, 31);
            this.txtUrlForPanel2.Name = "txtUrlForPanel2";
            this.txtUrlForPanel2.Size = new System.Drawing.Size(390, 31);
            this.txtUrlForPanel2.TabIndex = 1;
            this.txtUrlForPanel2.ClientSizeChanged += new System.EventHandler(this.txtUrlForPanel2_ClientSizeChanged);
            this.txtUrlForPanel2.Leave += new System.EventHandler(this.txtUrlForPanel2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Left Panel Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Right Panel Url";
            this.label2.SizeChanged += new System.EventHandler(this.label2_SizeChanged);
            // 
            // webPanel
            // 
            this.webPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webPanel.Controls.Add(this.splitContainer);
            this.webPanel.Location = new System.Drawing.Point(13, 80);
            this.webPanel.Name = "webPanel";
            this.webPanel.Size = new System.Drawing.Size(775, 358);
            this.webPanel.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.ClientSizeChanged += new System.EventHandler(this.splitContainer_Panel2_ClientSizeChanged);
            this.splitContainer.Size = new System.Drawing.Size(775, 358);
            this.splitContainer.SplitterDistance = 256;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.ClientSizeChanged += new System.EventHandler(this.splitContainer_ClientSizeChanged);
            // 
            // WindowsWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrlForPanel2);
            this.Controls.Add(this.txtUrlForPanel1);
            this.Name = "WindowsWebBrowser";
            this.Text = "WindowsWebBrowser";
            this.webPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtUrlForPanel1;
        private TextBox txtUrlForPanel2;
        private Label label1;
        private Label label2;
        private Panel webPanel;
        private SplitContainer splitContainer;
    }
}