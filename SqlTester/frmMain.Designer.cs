namespace SqlTester
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
            this.lblDataSource = new System.Windows.Forms.Label();
            this.lblInitialCatalog = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(18, 20);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(99, 20);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "Data Source";
            // 
            // lblInitialCatalog
            // 
            this.lblInitialCatalog.AutoSize = true;
            this.lblInitialCatalog.Location = new System.Drawing.Point(18, 60);
            this.lblInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitialCatalog.Name = "lblInitialCatalog";
            this.lblInitialCatalog.Size = new System.Drawing.Size(105, 20);
            this.lblInitialCatalog.TabIndex = 0;
            this.lblInitialCatalog.Text = "Initial Catalog";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(20, 100);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(61, 20);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User Id";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(18, 138);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(24, 214);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 38);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run Query";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtDataSource
            // 
            this.txtDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSource.Location = new System.Drawing.Point(156, 20);
            this.txtDataSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(949, 26);
            this.txtDataSource.TabIndex = 2;
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialCatalog.Location = new System.Drawing.Point(156, 60);
            this.txtInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(949, 26);
            this.txtInitialCatalog.TabIndex = 2;
            // 
            // txtUserId
            // 
            this.txtUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserId.Location = new System.Drawing.Point(156, 100);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(949, 26);
            this.txtUserId.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(156, 138);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(949, 26);
            this.txtPassword.TabIndex = 2;
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvData.Location = new System.Drawing.Point(22, 283);
            this.gvData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvData.Name = "gvData";
            this.gvData.ReadOnly = true;
            this.gvData.RowHeadersWidth = 62;
            this.gvData.Size = new System.Drawing.Size(1083, 135);
            this.gvData.TabIndex = 3;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(20, 178);
            this.lblQuery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(51, 20);
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "Query";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(156, 178);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(949, 74);
            this.txtQuery.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 432);
            this.Controls.Add(this.gvData);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtInitialCatalog);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblInitialCatalog);
            this.Controls.Add(this.lblDataSource);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Sql Tester";
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblInitialCatalog;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtQuery;
    }
}

