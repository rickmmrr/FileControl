namespace FileControl {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.textBoxEncrptionKey = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonExit = new System.Windows.Forms.Button();
         this.groupBoxThee = new System.Windows.Forms.GroupBox();
         this.radioButtonBusiness = new System.Windows.Forms.RadioButton();
         this.radioButtonHouseHold = new System.Windows.Forms.RadioButton();
         this.buttonConvert = new System.Windows.Forms.Button();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.treeViewFolders = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.listViewFiles = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.listViewDisplayFiles = new System.Windows.Forms.ListView();
         this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.button1 = new System.Windows.Forms.Button();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.button2 = new System.Windows.Forms.Button();
         this.buttonSearchSS = new System.Windows.Forms.Button();
         this.splitContainer3 = new System.Windows.Forms.SplitContainer();
         this.groupBoxSaveSets = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.listViewEncrypSaveSets = new System.Windows.Forms.ListView();
         this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.textBoxSearchSS = new System.Windows.Forms.TextBox();
         this.groupBoxCurrentSet = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.listViewCurrentEncrypSet = new System.Windows.Forms.ListView();
         this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.textBoxSearchFiles = new System.Windows.Forms.TextBox();
         this.buttonAddFileTypeAndLaunchInfo = new System.Windows.Forms.Button();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.groupBoxThee.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.tabPage2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
         this.splitContainer3.Panel1.SuspendLayout();
         this.splitContainer3.Panel2.SuspendLayout();
         this.splitContainer3.SuspendLayout();
         this.groupBoxSaveSets.SuspendLayout();
         this.groupBoxCurrentSet.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Location = new System.Drawing.Point(12, 4);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(960, 535);
         this.tabControl1.TabIndex = 0;
         this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.textBoxEncrptionKey);
         this.tabPage1.Controls.Add(this.label1);
         this.tabPage1.Controls.Add(this.buttonExit);
         this.tabPage1.Controls.Add(this.groupBoxThee);
         this.tabPage1.Controls.Add(this.buttonConvert);
         this.tabPage1.Controls.Add(this.splitContainer1);
         this.tabPage1.Controls.Add(this.button1);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(800, 509);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Convert Files";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // textBoxEncrptionKey
         // 
         this.textBoxEncrptionKey.Location = new System.Drawing.Point(324, 29);
         this.textBoxEncrptionKey.Name = "textBoxEncrptionKey";
         this.textBoxEncrptionKey.Size = new System.Drawing.Size(310, 20);
         this.textBoxEncrptionKey.TabIndex = 10;
         this.textBoxEncrptionKey.Text = "everygoodboydoesfine";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(240, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(78, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Encryption Key";
         // 
         // buttonExit
         // 
         this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonExit.Location = new System.Drawing.Point(657, 7);
         this.buttonExit.Name = "buttonExit";
         this.buttonExit.Size = new System.Drawing.Size(56, 23);
         this.buttonExit.TabIndex = 1;
         this.buttonExit.Text = "Exit";
         this.buttonExit.UseVisualStyleBackColor = true;
         // 
         // groupBoxThee
         // 
         this.groupBoxThee.Controls.Add(this.radioButtonBusiness);
         this.groupBoxThee.Controls.Add(this.radioButtonHouseHold);
         this.groupBoxThee.Location = new System.Drawing.Point(8, 6);
         this.groupBoxThee.Name = "groupBoxThee";
         this.groupBoxThee.Size = new System.Drawing.Size(226, 48);
         this.groupBoxThee.TabIndex = 8;
         this.groupBoxThee.TabStop = false;
         this.groupBoxThee.Text = "File Name Themes: Pick One";
         // 
         // radioButtonBusiness
         // 
         this.radioButtonBusiness.AutoSize = true;
         this.radioButtonBusiness.Location = new System.Drawing.Point(121, 19);
         this.radioButtonBusiness.Name = "radioButtonBusiness";
         this.radioButtonBusiness.Size = new System.Drawing.Size(67, 17);
         this.radioButtonBusiness.TabIndex = 1;
         this.radioButtonBusiness.Text = "Business";
         this.radioButtonBusiness.UseVisualStyleBackColor = true;
         // 
         // radioButtonHouseHold
         // 
         this.radioButtonHouseHold.AutoSize = true;
         this.radioButtonHouseHold.Checked = true;
         this.radioButtonHouseHold.Location = new System.Drawing.Point(6, 19);
         this.radioButtonHouseHold.Name = "radioButtonHouseHold";
         this.radioButtonHouseHold.Size = new System.Drawing.Size(76, 17);
         this.radioButtonHouseHold.TabIndex = 0;
         this.radioButtonHouseHold.TabStop = true;
         this.radioButtonHouseHold.Text = "Household";
         this.radioButtonHouseHold.UseVisualStyleBackColor = true;
         this.radioButtonHouseHold.CheckedChanged += new System.EventHandler(this.radioButtonHouseHold_CheckedChanged);
         // 
         // buttonConvert
         // 
         this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonConvert.Location = new System.Drawing.Point(710, 35);
         this.buttonConvert.Name = "buttonConvert";
         this.buttonConvert.Size = new System.Drawing.Size(87, 23);
         this.buttonConvert.TabIndex = 7;
         this.buttonConvert.Text = "Encrypt Files";
         this.buttonConvert.UseVisualStyleBackColor = true;
         this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.BackColor = System.Drawing.Color.SkyBlue;
         this.splitContainer1.Location = new System.Drawing.Point(6, 60);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.treeViewFolders);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
         this.splitContainer1.Size = new System.Drawing.Size(794, 443);
         this.splitContainer1.SplitterDistance = 264;
         this.splitContainer1.TabIndex = 6;
         // 
         // treeViewFolders
         // 
         this.treeViewFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treeViewFolders.CheckBoxes = true;
         this.treeViewFolders.ImageIndex = 0;
         this.treeViewFolders.ImageList = this.imageList1;
         this.treeViewFolders.Location = new System.Drawing.Point(3, 3);
         this.treeViewFolders.Name = "treeViewFolders";
         this.treeViewFolders.SelectedImageIndex = 0;
         this.treeViewFolders.Size = new System.Drawing.Size(258, 437);
         this.treeViewFolders.TabIndex = 2;
         this.treeViewFolders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterCheck);
         this.treeViewFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolders_BeforeExpand);
         this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "fol.ico");
         this.imageList1.Images.SetKeyName(1, "doc.ico");
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.listViewFiles);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.listViewDisplayFiles);
         this.splitContainer2.Size = new System.Drawing.Size(526, 443);
         this.splitContainer2.SplitterDistance = 219;
         this.splitContainer2.TabIndex = 0;
         // 
         // listViewFiles
         // 
         this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
         this.listViewFiles.GridLines = true;
         this.listViewFiles.Location = new System.Drawing.Point(3, 3);
         this.listViewFiles.Name = "listViewFiles";
         this.listViewFiles.Size = new System.Drawing.Size(516, 213);
         this.listViewFiles.SmallImageList = this.imageList1;
         this.listViewFiles.TabIndex = 3;
         this.listViewFiles.UseCompatibleStateImageBehavior = false;
         this.listViewFiles.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.DisplayIndex = 1;
         this.columnHeader1.Text = "Original Name";
         this.columnHeader1.Width = 175;
         // 
         // columnHeader2
         // 
         this.columnHeader2.DisplayIndex = 2;
         this.columnHeader2.Text = "New Name";
         this.columnHeader2.Width = 175;
         // 
         // columnHeader3
         // 
         this.columnHeader3.DisplayIndex = 3;
         this.columnHeader3.Text = "Status";
         this.columnHeader3.Width = 110;
         // 
         // columnHeader4
         // 
         this.columnHeader4.DisplayIndex = 0;
         this.columnHeader4.Text = "Count";
         this.columnHeader4.Width = 50;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Location";
         this.columnHeader5.Width = 300;
         // 
         // listViewDisplayFiles
         // 
         this.listViewDisplayFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewDisplayFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
         this.listViewDisplayFiles.GridLines = true;
         this.listViewDisplayFiles.Location = new System.Drawing.Point(0, 3);
         this.listViewDisplayFiles.Name = "listViewDisplayFiles";
         this.listViewDisplayFiles.Size = new System.Drawing.Size(520, 214);
         this.listViewDisplayFiles.SmallImageList = this.imageList1;
         this.listViewDisplayFiles.TabIndex = 5;
         this.listViewDisplayFiles.UseCompatibleStateImageBehavior = false;
         this.listViewDisplayFiles.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Name";
         this.columnHeader6.Width = 400;
         // 
         // columnHeader7
         // 
         this.columnHeader7.Text = "Location";
         this.columnHeader7.Width = 400;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.Location = new System.Drawing.Point(719, 7);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 4;
         this.button1.Text = "Test";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.button2);
         this.tabPage2.Controls.Add(this.buttonSearchSS);
         this.tabPage2.Controls.Add(this.splitContainer3);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage2.Size = new System.Drawing.Size(952, 509);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Restore and Launch Files";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(733, 17);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(59, 23);
         this.button2.TabIndex = 7;
         this.button2.Text = "Search";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // buttonSearchSS
         // 
         this.buttonSearchSS.Location = new System.Drawing.Point(351, 17);
         this.buttonSearchSS.Name = "buttonSearchSS";
         this.buttonSearchSS.Size = new System.Drawing.Size(51, 23);
         this.buttonSearchSS.TabIndex = 4;
         this.buttonSearchSS.Text = "Search";
         this.buttonSearchSS.UseVisualStyleBackColor = true;
         this.buttonSearchSS.Click += new System.EventHandler(this.buttonSearch_Click);
         // 
         // splitContainer3
         // 
         this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer3.BackColor = System.Drawing.Color.SkyBlue;
         this.splitContainer3.Location = new System.Drawing.Point(6, 45);
         this.splitContainer3.Name = "splitContainer3";
         this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer3.Panel1
         // 
         this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Transparent;
         this.splitContainer3.Panel1.Controls.Add(this.groupBoxSaveSets);
         // 
         // splitContainer3.Panel2
         // 
         this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Transparent;
         this.splitContainer3.Panel2.Controls.Add(this.groupBoxCurrentSet);
         this.splitContainer3.Size = new System.Drawing.Size(943, 458);
         this.splitContainer3.SplitterDistance = 226;
         this.splitContainer3.TabIndex = 2;
         // 
         // groupBoxSaveSets
         // 
         this.groupBoxSaveSets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxSaveSets.BackColor = System.Drawing.SystemColors.Window;
         this.groupBoxSaveSets.Controls.Add(this.label2);
         this.groupBoxSaveSets.Controls.Add(this.listViewEncrypSaveSets);
         this.groupBoxSaveSets.Controls.Add(this.textBoxSearchSS);
         this.groupBoxSaveSets.Location = new System.Drawing.Point(3, 4);
         this.groupBoxSaveSets.Name = "groupBoxSaveSets";
         this.groupBoxSaveSets.Size = new System.Drawing.Size(937, 219);
         this.groupBoxSaveSets.TabIndex = 0;
         this.groupBoxSaveSets.TabStop = false;
         this.groupBoxSaveSets.Text = "Encryption Save Sets";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(265, 22);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(225, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Use the Search Box to find specific Save Sets";
         // 
         // listViewEncrypSaveSets
         // 
         this.listViewEncrypSaveSets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewEncrypSaveSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader14});
         this.listViewEncrypSaveSets.FullRowSelect = true;
         this.listViewEncrypSaveSets.Location = new System.Drawing.Point(6, 42);
         this.listViewEncrypSaveSets.Name = "listViewEncrypSaveSets";
         this.listViewEncrypSaveSets.Size = new System.Drawing.Size(925, 171);
         this.listViewEncrypSaveSets.TabIndex = 0;
         this.listViewEncrypSaveSets.UseCompatibleStateImageBehavior = false;
         this.listViewEncrypSaveSets.View = System.Windows.Forms.View.Details;
         this.listViewEncrypSaveSets.SelectedIndexChanged += new System.EventHandler(this.listViewEncrypSaveSets_SelectedIndexChanged);
         // 
         // columnHeader8
         // 
         this.columnHeader8.Text = "Name";
         this.columnHeader8.Width = 120;
         // 
         // columnHeader9
         // 
         this.columnHeader9.Text = "Creation Date";
         this.columnHeader9.Width = 120;
         // 
         // columnHeader10
         // 
         this.columnHeader10.Text = "Comments";
         this.columnHeader10.Width = 300;
         // 
         // columnHeader11
         // 
         this.columnHeader11.Text = "Key";
         // 
         // columnHeader14
         // 
         this.columnHeader14.Text = "Number Of Files";
         this.columnHeader14.Width = 120;
         // 
         // textBoxSearchSS
         // 
         this.textBoxSearchSS.Location = new System.Drawing.Point(6, 19);
         this.textBoxSearchSS.Name = "textBoxSearchSS";
         this.textBoxSearchSS.Size = new System.Drawing.Size(255, 20);
         this.textBoxSearchSS.TabIndex = 3;
         // 
         // groupBoxCurrentSet
         // 
         this.groupBoxCurrentSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxCurrentSet.BackColor = System.Drawing.SystemColors.Window;
         this.groupBoxCurrentSet.Controls.Add(this.buttonAddFileTypeAndLaunchInfo);
         this.groupBoxCurrentSet.Controls.Add(this.label3);
         this.groupBoxCurrentSet.Controls.Add(this.listViewCurrentEncrypSet);
         this.groupBoxCurrentSet.Controls.Add(this.textBoxSearchFiles);
         this.groupBoxCurrentSet.Location = new System.Drawing.Point(3, 7);
         this.groupBoxCurrentSet.Name = "groupBoxCurrentSet";
         this.groupBoxCurrentSet.Size = new System.Drawing.Size(936, 221);
         this.groupBoxCurrentSet.TabIndex = 1;
         this.groupBoxCurrentSet.TabStop = false;
         this.groupBoxCurrentSet.Text = "Current Encryption Set";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(271, 22);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(197, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Use the Search Box to find specific Files";
         // 
         // listViewCurrentEncrypSet
         // 
         this.listViewCurrentEncrypSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewCurrentEncrypSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16});
         this.listViewCurrentEncrypSet.Location = new System.Drawing.Point(6, 45);
         this.listViewCurrentEncrypSet.Name = "listViewCurrentEncrypSet";
         this.listViewCurrentEncrypSet.Size = new System.Drawing.Size(924, 170);
         this.listViewCurrentEncrypSet.TabIndex = 0;
         this.listViewCurrentEncrypSet.UseCompatibleStateImageBehavior = false;
         this.listViewCurrentEncrypSet.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader12
         // 
         this.columnHeader12.Text = "Original File Name";
         this.columnHeader12.Width = 220;
         // 
         // columnHeader13
         // 
         this.columnHeader13.Text = "Encryption File Name";
         this.columnHeader13.Width = 220;
         // 
         // columnHeader15
         // 
         this.columnHeader15.Text = "File Type";
         this.columnHeader15.Width = 90;
         // 
         // columnHeader16
         // 
         this.columnHeader16.Text = "Launch";
         this.columnHeader16.Width = 80;
         // 
         // textBoxSearchFiles
         // 
         this.textBoxSearchFiles.Location = new System.Drawing.Point(6, 19);
         this.textBoxSearchFiles.Name = "textBoxSearchFiles";
         this.textBoxSearchFiles.Size = new System.Drawing.Size(255, 20);
         this.textBoxSearchFiles.TabIndex = 6;
         // 
         // buttonAddFileTypeAndLaunchInfo
         // 
         this.buttonAddFileTypeAndLaunchInfo.Location = new System.Drawing.Point(502, 16);
         this.buttonAddFileTypeAndLaunchInfo.Name = "buttonAddFileTypeAndLaunchInfo";
         this.buttonAddFileTypeAndLaunchInfo.Size = new System.Drawing.Size(231, 23);
         this.buttonAddFileTypeAndLaunchInfo.TabIndex = 8;
         this.buttonAddFileTypeAndLaunchInfo.Text = "Add File Types and Launch Program Info";
         this.buttonAddFileTypeAndLaunchInfo.UseVisualStyleBackColor = true;
         this.buttonAddFileTypeAndLaunchInfo.Click += new System.EventHandler(this.buttonAddFileTypeAndLaunchInfo_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(973, 541);
         this.Controls.Add(this.tabControl1);
         this.Name = "Form1";
         this.Text = "Hidden in Plain Sight";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.groupBoxThee.ResumeLayout(false);
         this.groupBoxThee.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
         this.splitContainer2.ResumeLayout(false);
         this.tabPage2.ResumeLayout(false);
         this.splitContainer3.Panel1.ResumeLayout(false);
         this.splitContainer3.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
         this.splitContainer3.ResumeLayout(false);
         this.groupBoxSaveSets.ResumeLayout(false);
         this.groupBoxSaveSets.PerformLayout();
         this.groupBoxCurrentSet.ResumeLayout(false);
         this.groupBoxCurrentSet.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewDisplayFiles;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.GroupBox groupBoxThee;
        private System.Windows.Forms.RadioButton radioButtonBusiness;
        private System.Windows.Forms.RadioButton radioButtonHouseHold;
        private System.Windows.Forms.GroupBox groupBoxSaveSets;
        private System.Windows.Forms.GroupBox groupBoxCurrentSet;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView listViewEncrypSaveSets;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ListView listViewCurrentEncrypSet;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.TextBox textBoxEncrptionKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button buttonSearchSS;
        private System.Windows.Forms.TextBox textBoxSearchSS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxSearchFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button buttonAddFileTypeAndLaunchInfo;
   }
}

