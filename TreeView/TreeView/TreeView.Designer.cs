namespace TreeView
{
    partial class TreeView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("חשבון 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("חשבון 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("נמל חיפה", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Companies", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("חשבון 1");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("חשבון 2");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("בנק 1", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("חשבון 3");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("חשבון 4");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("בנק 2", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Banks", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("חשבון 1");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("חשבון 2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Bank Accounts", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("חשבון 1");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("חשבון 2");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("שקל", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("חשבון 3");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("חשבון 4");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("דולר", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("חשבון 5");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("חשבון 6");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("יורו", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Currencies", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode20,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("שוטף", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode11,
            treeNode14,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("שוטף מנוהל");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("תפר");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("נמל חיפה", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27});
            this.tvAshdod = new System.Windows.Forms.TreeView();
            this.tvHaifa = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvAshdod
            // 
            this.tvAshdod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvAshdod.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvAshdod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tvAshdod.Location = new System.Drawing.Point(12, 12);
            this.tvAshdod.Name = "tvAshdod";
            treeNode1.Name = "Node6";
            treeNode1.Text = "חשבון 1";
            treeNode2.Name = "Node7";
            treeNode2.Text = "חשבון 2";
            treeNode3.Name = "Node5";
            treeNode3.Text = "נמל חיפה";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Companies";
            treeNode5.Name = "Node12";
            treeNode5.Text = "חשבון 1";
            treeNode6.Name = "Node13";
            treeNode6.Text = "חשבון 2";
            treeNode7.Name = "Node10";
            treeNode7.Text = "בנק 1";
            treeNode8.Name = "Node8";
            treeNode8.Text = "חשבון 3";
            treeNode9.Name = "Node14";
            treeNode9.Text = "חשבון 4";
            treeNode10.Name = "Node11";
            treeNode10.Text = "בנק 2";
            treeNode11.Name = "Node9";
            treeNode11.Text = "Banks";
            treeNode12.Name = "Node16";
            treeNode12.Text = "חשבון 1";
            treeNode13.Name = "Node17";
            treeNode13.Text = "חשבון 2";
            treeNode14.Name = "Node15";
            treeNode14.Text = "Bank Accounts";
            treeNode15.Name = "Node22";
            treeNode15.Text = "חשבון 1";
            treeNode16.Name = "Node23";
            treeNode16.Text = "חשבון 2";
            treeNode17.Name = "Node19";
            treeNode17.Text = "שקל";
            treeNode18.Name = "Node24";
            treeNode18.Text = "חשבון 3";
            treeNode19.Name = "Node25";
            treeNode19.Text = "חשבון 4";
            treeNode20.Name = "Node20";
            treeNode20.Text = "דולר";
            treeNode21.Name = "Node26";
            treeNode21.Text = "חשבון 5";
            treeNode22.Name = "Node27";
            treeNode22.Text = "חשבון 6";
            treeNode23.Name = "Node21";
            treeNode23.Text = "יורו";
            treeNode24.Name = "Node18";
            treeNode24.Text = "Currencies";
            treeNode25.Name = "Node1";
            treeNode25.Text = "שוטף";
            treeNode26.Name = "Node2";
            treeNode26.Text = "שוטף מנוהל";
            treeNode27.Name = "Node3";
            treeNode27.Text = "תפר";
            treeNode28.Name = "Node0";
            treeNode28.Text = "נמל חיפה";
            this.tvAshdod.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28});
            this.tvAshdod.Size = new System.Drawing.Size(269, 243);
            this.tvAshdod.TabIndex = 0;
            this.tvAshdod.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tvHaifa
            // 
            this.tvHaifa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvHaifa.Location = new System.Drawing.Point(300, 12);
            this.tvHaifa.Name = "tvHaifa";
            this.tvHaifa.Size = new System.Drawing.Size(269, 243);
            this.tvHaifa.TabIndex = 1;
            // 
            // Class1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 283);
            this.Controls.Add(this.tvHaifa);
            this.Controls.Add(this.tvAshdod);
            this.Name = "Class1";
            this.Text = "Tree View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvAshdod;
        private System.Windows.Forms.TreeView tvHaifa;
    }
}