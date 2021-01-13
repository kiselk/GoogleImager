namespace GoogleImager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.saveSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.eWidth = new System.Windows.Forms.TextBox();
            this.eHeight = new System.Windows.Forms.TextBox();
            this.rSizeAny = new System.Windows.Forms.RadioButton();
            this.rSizeSmall = new System.Windows.Forms.RadioButton();
            this.rSizeMedium = new System.Windows.Forms.RadioButton();
            this.rSizeLarge = new System.Windows.Forms.RadioButton();
            this.rSizeLarger = new System.Windows.Forms.RadioButton();
            this.rSizeExact = new System.Windows.Forms.RadioButton();
            this.cbSizeLarger = new System.Windows.Forms.ComboBox();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rTypeBarcode = new System.Windows.Forms.RadioButton();
            this.rTypeClipArt = new System.Windows.Forms.RadioButton();
            this.rTypePhoto = new System.Windows.Forms.RadioButton();
            this.rTypeFace = new System.Windows.Forms.RadioButton();
            this.rTypeAny = new System.Windows.Forms.RadioButton();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.rColorExact = new System.Windows.Forms.RadioButton();
            this.rColorBW = new System.Windows.Forms.RadioButton();
            this.rColorColor = new System.Windows.Forms.RadioButton();
            this.rColorAny = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.lFound = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTileSize = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.gbSize.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbColor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.Location = new System.Drawing.Point(122, 56);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(725, 537);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSelectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 26);
            // 
            // saveSelectedToolStripMenuItem
            // 
            this.saveSelectedToolStripMenuItem.Name = "saveSelectedToolStripMenuItem";
            this.saveSelectedToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveSelectedToolStripMenuItem.Text = "Save Selected";
            this.saveSelectedToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(772, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(122, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(644, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eWidth
            // 
            this.eWidth.Location = new System.Drawing.Point(17, 184);
            this.eWidth.Name = "eWidth";
            this.eWidth.Size = new System.Drawing.Size(39, 20);
            this.eWidth.TabIndex = 4;
            this.eWidth.TextChanged += new System.EventHandler(this.eWidth_TextChanged);
            // 
            // eHeight
            // 
            this.eHeight.Location = new System.Drawing.Point(64, 184);
            this.eHeight.Name = "eHeight";
            this.eHeight.Size = new System.Drawing.Size(36, 20);
            this.eHeight.TabIndex = 5;
            this.eHeight.TextChanged += new System.EventHandler(this.eHeight_TextChanged);
            // 
            // rSizeAny
            // 
            this.rSizeAny.AutoSize = true;
            this.rSizeAny.Checked = true;
            this.rSizeAny.Location = new System.Drawing.Point(6, 19);
            this.rSizeAny.Name = "rSizeAny";
            this.rSizeAny.Size = new System.Drawing.Size(43, 17);
            this.rSizeAny.TabIndex = 9;
            this.rSizeAny.TabStop = true;
            this.rSizeAny.Text = "Any";
            this.rSizeAny.UseVisualStyleBackColor = true;
            // 
            // rSizeSmall
            // 
            this.rSizeSmall.AutoSize = true;
            this.rSizeSmall.Location = new System.Drawing.Point(6, 42);
            this.rSizeSmall.Name = "rSizeSmall";
            this.rSizeSmall.Size = new System.Drawing.Size(50, 17);
            this.rSizeSmall.TabIndex = 10;
            this.rSizeSmall.Text = "Small";
            this.rSizeSmall.UseVisualStyleBackColor = true;
            // 
            // rSizeMedium
            // 
            this.rSizeMedium.AutoSize = true;
            this.rSizeMedium.Location = new System.Drawing.Point(6, 65);
            this.rSizeMedium.Name = "rSizeMedium";
            this.rSizeMedium.Size = new System.Drawing.Size(62, 17);
            this.rSizeMedium.TabIndex = 11;
            this.rSizeMedium.Text = "Medium";
            this.rSizeMedium.UseVisualStyleBackColor = true;
            // 
            // rSizeLarge
            // 
            this.rSizeLarge.AutoSize = true;
            this.rSizeLarge.Location = new System.Drawing.Point(6, 88);
            this.rSizeLarge.Name = "rSizeLarge";
            this.rSizeLarge.Size = new System.Drawing.Size(52, 17);
            this.rSizeLarge.TabIndex = 12;
            this.rSizeLarge.Text = "Large";
            this.rSizeLarge.UseVisualStyleBackColor = true;
            // 
            // rSizeLarger
            // 
            this.rSizeLarger.AutoSize = true;
            this.rSizeLarger.Location = new System.Drawing.Point(6, 111);
            this.rSizeLarger.Name = "rSizeLarger";
            this.rSizeLarger.Size = new System.Drawing.Size(83, 17);
            this.rSizeLarger.TabIndex = 13;
            this.rSizeLarger.Text = "Larger Than";
            this.rSizeLarger.UseVisualStyleBackColor = true;
            this.rSizeLarger.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rSizeExact
            // 
            this.rSizeExact.AutoSize = true;
            this.rSizeExact.Location = new System.Drawing.Point(6, 161);
            this.rSizeExact.Name = "rSizeExact";
            this.rSizeExact.Size = new System.Drawing.Size(75, 17);
            this.rSizeExact.TabIndex = 14;
            this.rSizeExact.Text = "Exact Size";
            this.rSizeExact.UseVisualStyleBackColor = true;
            // 
            // cbSizeLarger
            // 
            this.cbSizeLarger.FormattingEnabled = true;
            this.cbSizeLarger.Items.AddRange(new object[] {
            "400 x 300",
            "640 x 480",
            "800 x 600",
            "1024 x 768",
            "1600 x 1200",
            "2272 x 1704",
            "2816 x 2112",
            "3264 x 2448",
            "3648 x 2736",
            "4096 x 3072",
            "4480 x 3360",
            "5120 x 3840",
            "7216 x 5412",
            "9600 x 7200"});
            this.cbSizeLarger.Location = new System.Drawing.Point(17, 134);
            this.cbSizeLarger.Name = "cbSizeLarger";
            this.cbSizeLarger.Size = new System.Drawing.Size(83, 21);
            this.cbSizeLarger.TabIndex = 15;
            this.cbSizeLarger.SelectedIndexChanged += new System.EventHandler(this.cbSizeLarger_SelectedIndexChanged);
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.rSizeAny);
            this.gbSize.Controls.Add(this.eWidth);
            this.gbSize.Controls.Add(this.cbSizeLarger);
            this.gbSize.Controls.Add(this.eHeight);
            this.gbSize.Controls.Add(this.rSizeExact);
            this.gbSize.Controls.Add(this.rSizeSmall);
            this.gbSize.Controls.Add(this.rSizeLarger);
            this.gbSize.Controls.Add(this.rSizeMedium);
            this.gbSize.Controls.Add(this.rSizeLarge);
            this.gbSize.Location = new System.Drawing.Point(8, 49);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(106, 211);
            this.gbSize.TabIndex = 16;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rTypeBarcode);
            this.gbType.Controls.Add(this.rTypeClipArt);
            this.gbType.Controls.Add(this.rTypePhoto);
            this.gbType.Controls.Add(this.rTypeFace);
            this.gbType.Controls.Add(this.rTypeAny);
            this.gbType.Location = new System.Drawing.Point(8, 262);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(106, 134);
            this.gbType.TabIndex = 17;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // rTypeBarcode
            // 
            this.rTypeBarcode.AutoSize = true;
            this.rTypeBarcode.Location = new System.Drawing.Point(6, 111);
            this.rTypeBarcode.Name = "rTypeBarcode";
            this.rTypeBarcode.Size = new System.Drawing.Size(57, 17);
            this.rTypeBarcode.TabIndex = 4;
            this.rTypeBarcode.Text = "Lineart";
            this.rTypeBarcode.UseVisualStyleBackColor = true;
            // 
            // rTypeClipArt
            // 
            this.rTypeClipArt.AutoSize = true;
            this.rTypeClipArt.Location = new System.Drawing.Point(6, 88);
            this.rTypeClipArt.Name = "rTypeClipArt";
            this.rTypeClipArt.Size = new System.Drawing.Size(54, 17);
            this.rTypeClipArt.TabIndex = 3;
            this.rTypeClipArt.Text = "Clipart";
            this.rTypeClipArt.UseVisualStyleBackColor = true;
            // 
            // rTypePhoto
            // 
            this.rTypePhoto.AutoSize = true;
            this.rTypePhoto.Location = new System.Drawing.Point(6, 65);
            this.rTypePhoto.Name = "rTypePhoto";
            this.rTypePhoto.Size = new System.Drawing.Size(53, 17);
            this.rTypePhoto.TabIndex = 2;
            this.rTypePhoto.Text = "Photo";
            this.rTypePhoto.UseVisualStyleBackColor = true;
            // 
            // rTypeFace
            // 
            this.rTypeFace.AutoSize = true;
            this.rTypeFace.Location = new System.Drawing.Point(6, 42);
            this.rTypeFace.Name = "rTypeFace";
            this.rTypeFace.Size = new System.Drawing.Size(49, 17);
            this.rTypeFace.TabIndex = 1;
            this.rTypeFace.Text = "Face";
            this.rTypeFace.UseVisualStyleBackColor = true;
            // 
            // rTypeAny
            // 
            this.rTypeAny.AutoSize = true;
            this.rTypeAny.Checked = true;
            this.rTypeAny.Location = new System.Drawing.Point(6, 19);
            this.rTypeAny.Name = "rTypeAny";
            this.rTypeAny.Size = new System.Drawing.Size(43, 17);
            this.rTypeAny.TabIndex = 0;
            this.rTypeAny.TabStop = true;
            this.rTypeAny.Text = "Any";
            this.rTypeAny.UseVisualStyleBackColor = true;
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.cbColor);
            this.gbColor.Controls.Add(this.rColorExact);
            this.gbColor.Controls.Add(this.rColorBW);
            this.gbColor.Controls.Add(this.rColorColor);
            this.gbColor.Controls.Add(this.rColorAny);
            this.gbColor.Location = new System.Drawing.Point(8, 398);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(106, 142);
            this.gbColor.TabIndex = 18;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "red",
            "orange",
            "yellow",
            "green",
            "teal",
            "blue",
            "purple",
            "pink",
            "white",
            "gray",
            "black",
            "brown"});
            this.cbColor.Location = new System.Drawing.Point(18, 111);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(82, 21);
            this.cbColor.TabIndex = 4;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            // 
            // rColorExact
            // 
            this.rColorExact.AutoSize = true;
            this.rColorExact.Location = new System.Drawing.Point(7, 88);
            this.rColorExact.Name = "rColorExact";
            this.rColorExact.Size = new System.Drawing.Size(79, 17);
            this.rColorExact.TabIndex = 3;
            this.rColorExact.Text = "Exact Color";
            this.rColorExact.UseVisualStyleBackColor = true;
            // 
            // rColorBW
            // 
            this.rColorBW.AutoSize = true;
            this.rColorBW.Location = new System.Drawing.Point(7, 65);
            this.rColorBW.Name = "rColorBW";
            this.rColorBW.Size = new System.Drawing.Size(72, 17);
            this.rColorBW.TabIndex = 2;
            this.rColorBW.Text = "Grayscale";
            this.rColorBW.UseVisualStyleBackColor = true;
            // 
            // rColorColor
            // 
            this.rColorColor.AutoSize = true;
            this.rColorColor.Location = new System.Drawing.Point(7, 42);
            this.rColorColor.Name = "rColorColor";
            this.rColorColor.Size = new System.Drawing.Size(49, 17);
            this.rColorColor.TabIndex = 1;
            this.rColorColor.Text = "Color";
            this.rColorColor.UseVisualStyleBackColor = true;
            // 
            // rColorAny
            // 
            this.rColorAny.AutoSize = true;
            this.rColorAny.Checked = true;
            this.rColorAny.Location = new System.Drawing.Point(7, 19);
            this.rColorAny.Name = "rColorAny";
            this.rColorAny.Size = new System.Drawing.Size(43, 17);
            this.rColorAny.TabIndex = 0;
            this.rColorAny.TabStop = true;
            this.rColorAny.Text = "Any";
            this.rColorAny.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 44);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(146, 35);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(108, 13);
            this.lStatus.TabIndex = 20;
            this.lStatus.Text = "Enter text to search...";
            // 
            // lFound
            // 
            this.lFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lFound.AutoSize = true;
            this.lFound.Location = new System.Drawing.Point(662, 35);
            this.lFound.Name = "lFound";
            this.lFound.Size = new System.Drawing.Size(0, 13);
            this.lFound.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTileSize);
            this.groupBox1.Location = new System.Drawing.Point(8, 544);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 49);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiles";
            // 
            // cbTileSize
            // 
            this.cbTileSize.FormattingEnabled = true;
            this.cbTileSize.Items.AddRange(new object[] {
            "64x64",
            "128x128",
            "256x256"});
            this.cbTileSize.Location = new System.Drawing.Point(17, 19);
            this.cbTileSize.Name = "cbTileSize";
            this.cbTileSize.Size = new System.Drawing.Size(83, 21);
            this.cbTileSize.TabIndex = 0;
            this.cbTileSize.Text = "128x128";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lFound);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Google Imager";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.gbColor.ResumeLayout(false);
            this.gbColor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox eWidth;
        private System.Windows.Forms.TextBox eHeight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedToolStripMenuItem;
        private System.Windows.Forms.RadioButton rSizeAny;
        private System.Windows.Forms.RadioButton rSizeSmall;
        private System.Windows.Forms.RadioButton rSizeMedium;
        private System.Windows.Forms.RadioButton rSizeLarge;
        private System.Windows.Forms.RadioButton rSizeLarger;
        private System.Windows.Forms.RadioButton rSizeExact;
        private System.Windows.Forms.ComboBox cbSizeLarger;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rTypeBarcode;
        private System.Windows.Forms.RadioButton rTypeClipArt;
        private System.Windows.Forms.RadioButton rTypePhoto;
        private System.Windows.Forms.RadioButton rTypeFace;
        private System.Windows.Forms.RadioButton rTypeAny;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.RadioButton rColorExact;
        private System.Windows.Forms.RadioButton rColorBW;
        private System.Windows.Forms.RadioButton rColorColor;
        private System.Windows.Forms.RadioButton rColorAny;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lFound;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTileSize;
    }
}

