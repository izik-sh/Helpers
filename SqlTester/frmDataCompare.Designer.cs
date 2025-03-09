namespace SqlTester
{
    partial class frmDataCompare
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
            this.cmbDBListA = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbDBListA
            // 
            this.cmbDBListA.FormattingEnabled = true;
            this.cmbDBListA.Location = new System.Drawing.Point(13, 13);
            this.cmbDBListA.Name = "cmbDBListA";
            this.cmbDBListA.Size = new System.Drawing.Size(121, 21);
            this.cmbDBListA.TabIndex = 0;
            // 
            // frmDataCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbDBListA);
            this.Name = "frmDataCompare";
            this.Text = "frmDataCompare";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDBListA;
    }
}