namespace X_Live_SD_Splitter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sdCardOpener = new System.Windows.Forms.OpenFileDialog();
            this.channelList = new System.Windows.Forms.CheckedListBox();
            this.sdData1 = new System.Windows.Forms.DataGridView();
            this.card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.outputFolderOpener = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.sdData1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sdCardOpener
            // 
            this.sdCardOpener.DefaultExt = "bin";
            this.sdCardOpener.FileName = "SE_LOG.BIN";
            this.sdCardOpener.Filter = "XLive Session files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // channelList
            // 
            this.channelList.CheckOnClick = true;
            this.channelList.Dock = System.Windows.Forms.DockStyle.Right;
            this.channelList.FormattingEnabled = true;
            this.channelList.Location = new System.Drawing.Point(845, 0);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(202, 688);
            this.channelList.TabIndex = 1;
            this.channelList.DoubleClick += new System.EventHandler(this.channelList_DoubleClick);
            // 
            // sdData1
            // 
            this.sdData1.AllowUserToAddRows = false;
            this.sdData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sdData1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card,
            this.timeStamp,
            this.channels,
            this.bitRate,
            this.fileCount,
            this.length,
            this.path,
            this.frames});
            this.sdData1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sdData1.Location = new System.Drawing.Point(0, 0);
            this.sdData1.Name = "sdData1";
            this.sdData1.ReadOnly = true;
            this.sdData1.Size = new System.Drawing.Size(845, 99);
            this.sdData1.TabIndex = 2;
            this.sdData1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.sdData1_RowsAdded);
            this.sdData1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.sdData1_RowsRemoved);
            // 
            // card
            // 
            this.card.HeaderText = "Card";
            this.card.Name = "card";
            this.card.ReadOnly = true;
            // 
            // timeStamp
            // 
            this.timeStamp.HeaderText = "Time Stamp";
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.ReadOnly = true;
            // 
            // channels
            // 
            this.channels.HeaderText = "Channels";
            this.channels.Name = "channels";
            this.channels.ReadOnly = true;
            // 
            // bitRate
            // 
            this.bitRate.HeaderText = "Bit Rate";
            this.bitRate.Name = "bitRate";
            this.bitRate.ReadOnly = true;
            // 
            // fileCount
            // 
            this.fileCount.HeaderText = "Files";
            this.fileCount.Name = "fileCount";
            this.fileCount.ReadOnly = true;
            // 
            // length
            // 
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            // 
            // path
            // 
            this.path.HeaderText = "Path";
            this.path.Name = "path";
            this.path.ReadOnly = true;
            // 
            // frames
            // 
            this.frames.HeaderText = "Frames";
            this.frames.Name = "frames";
            this.frames.ReadOnly = true;
            // 
            // fileList
            // 
            this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(3, 3);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(391, 537);
            this.fileList.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 39);
            this.panel1.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(736, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Clear All";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(655, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Check All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(255, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Process";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Validate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Verify_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Card";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(-1, 3);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(433, 540);
            this.logBox.TabIndex = 8;
            this.logBox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 141);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logBox);
            this.splitContainer1.Size = new System.Drawing.Size(845, 547);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sdData1);
            this.Controls.Add(this.channelList);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "XLive SD Splitter";
            ((System.ComponentModel.ISupportInitialize)(this.sdData1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog sdCardOpener;
        private System.Windows.Forms.CheckedListBox channelList;
        private System.Windows.Forms.DataGridView sdData1;
        private System.Windows.Forms.DataGridViewTextBoxColumn card;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn channels;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn frames;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.FolderBrowserDialog outputFolderOpener;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

