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
            this.channelPanel = new System.Windows.Forms.Panel();
            this.channelList = new System.Windows.Forms.CheckedListBox();
            this.presetCombo = new System.Windows.Forms.ComboBox();
            this.btnLoadPreset = new System.Windows.Forms.Button();
            this.btnSavePreset = new System.Windows.Forms.Button();
            this.btnRenamePreset = new System.Windows.Forms.Button();
            this.btnDeletePreset = new System.Windows.Forms.Button();
            this.gridSdCards = new System.Windows.Forms.DataGridView();
            this.card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileList = new System.Windows.Forms.ListBox();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.lblBufferSeconds = new System.Windows.Forms.Label();
            this.bufferSeconds = new System.Windows.Forms.NumericUpDown();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnAddCard = new System.Windows.Forms.Button();
            this.btnClearAllChannels = new System.Windows.Forms.Button();
            this.btnCheckAllChannels = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.outputFolderOpener = new System.Windows.Forms.FolderBrowserDialog();
            this.splitFilesAndLog = new System.Windows.Forms.SplitContainer();
            this.presetPanel = new System.Windows.Forms.Panel();
            this.channelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSdCards)).BeginInit();
            this.toolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bufferSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilesAndLog)).BeginInit();
            this.splitFilesAndLog.Panel1.SuspendLayout();
            this.splitFilesAndLog.Panel2.SuspendLayout();
            this.splitFilesAndLog.SuspendLayout();
            this.presetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sdCardOpener
            // 
            this.sdCardOpener.DefaultExt = "bin";
            this.sdCardOpener.FileName = "SE_LOG.BIN";
            this.sdCardOpener.Filter = "XLive Session files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // channelPanel
            // 
            this.channelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelPanel.Controls.Add(this.channelList);
            this.channelPanel.Location = new System.Drawing.Point(850, 112);
            this.channelPanel.Name = "channelPanel";
            this.channelPanel.Size = new System.Drawing.Size(196, 428);
            this.channelPanel.TabIndex = 10;
            // 
            // channelList
            // 
            this.channelList.CheckOnClick = true;
            this.channelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelList.FormattingEnabled = true;
            this.channelList.Location = new System.Drawing.Point(0, 0);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(196, 428);
            this.channelList.TabIndex = 3;
            this.channelList.DoubleClick += new System.EventHandler(this.channelList_DoubleClick);
            // 
            // presetCombo
            // 
            this.presetCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetCombo.FormattingEnabled = true;
            this.presetCombo.Location = new System.Drawing.Point(3, 32);
            this.presetCombo.Name = "presetCombo";
            this.presetCombo.Size = new System.Drawing.Size(192, 21);
            this.presetCombo.TabIndex = 0;
            // 
            // btnLoadPreset
            // 
            this.btnLoadPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPreset.Location = new System.Drawing.Point(3, 3);
            this.btnLoadPreset.Name = "btnLoadPreset";
            this.btnLoadPreset.Size = new System.Drawing.Size(95, 23);
            this.btnLoadPreset.TabIndex = 1;
            this.btnLoadPreset.Text = "Load Preset";
            this.btnLoadPreset.UseVisualStyleBackColor = true;
            this.btnLoadPreset.Click += new System.EventHandler(this.btnLoadPreset_Click);
            // 
            // btnSavePreset
            // 
            this.btnSavePreset.Location = new System.Drawing.Point(101, 3);
            this.btnSavePreset.Name = "btnSavePreset";
            this.btnSavePreset.Size = new System.Drawing.Size(95, 23);
            this.btnSavePreset.TabIndex = 2;
            this.btnSavePreset.Text = "Save Preset";
            this.btnSavePreset.UseVisualStyleBackColor = true;
            this.btnSavePreset.Click += new System.EventHandler(this.btnSavePreset_Click);
            // 
            // btnRenamePreset
            // 
            this.btnRenamePreset.Location = new System.Drawing.Point(3, 56);
            this.btnRenamePreset.Name = "btnRenamePreset";
            this.btnRenamePreset.Size = new System.Drawing.Size(95, 23);
            this.btnRenamePreset.TabIndex = 3;
            this.btnRenamePreset.Text = "Rename Preset";
            this.btnRenamePreset.UseVisualStyleBackColor = true;
            this.btnRenamePreset.Click += new System.EventHandler(this.btnRenamePreset_Click);
            // 
            // btnDeletePreset
            // 
            this.btnDeletePreset.Location = new System.Drawing.Point(101, 56);
            this.btnDeletePreset.Name = "btnDeletePreset";
            this.btnDeletePreset.Size = new System.Drawing.Size(95, 23);
            this.btnDeletePreset.TabIndex = 4;
            this.btnDeletePreset.Text = "Delete Preset";
            this.btnDeletePreset.UseVisualStyleBackColor = true;
            this.btnDeletePreset.Click += new System.EventHandler(this.btnDeletePreset_Click);
            // 
            // gridSdCards
            // 
            this.gridSdCards.AllowDrop = true;
            this.gridSdCards.AllowUserToAddRows = false;
            this.gridSdCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSdCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSdCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card,
            this.timeStamp,
            this.channels,
            this.bitRate,
            this.fileCount,
            this.length,
            this.path,
            this.frames});
            this.gridSdCards.Location = new System.Drawing.Point(0, 87);
            this.gridSdCards.Name = "gridSdCards";
            this.gridSdCards.ReadOnly = true;
            this.gridSdCards.Size = new System.Drawing.Size(844, 125);
            this.gridSdCards.TabIndex = 2;
            this.gridSdCards.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridSdCards_RowsAdded);
            this.gridSdCards.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridSdCards_RowsRemoved);
            this.gridSdCards.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridSdCards_DragDrop);
            this.gridSdCards.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridSdCards_DragEnter);
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
            this.fileList.AllowDrop = true;
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(347, 330);
            this.fileList.TabIndex = 5;
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbarPanel.Controls.Add(this.lblBufferSeconds);
            this.toolbarPanel.Controls.Add(this.bufferSeconds);
            this.toolbarPanel.Controls.Add(this.summaryTextBox);
            this.toolbarPanel.Controls.Add(this.btnProcess);
            this.toolbarPanel.Controls.Add(this.btnValidate);
            this.toolbarPanel.Controls.Add(this.btnAddCard);
            this.toolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(844, 89);
            this.toolbarPanel.TabIndex = 7;
            // 
            // lblBufferSeconds
            // 
            this.lblBufferSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBufferSeconds.AutoSize = true;
            this.lblBufferSeconds.Location = new System.Drawing.Point(511, 52);
            this.lblBufferSeconds.Name = "lblBufferSeconds";
            this.lblBufferSeconds.Size = new System.Drawing.Size(80, 13);
            this.lblBufferSeconds.TabIndex = 12;
            this.lblBufferSeconds.Text = "Buffer Seconds";
            this.lblBufferSeconds.Click += new System.EventHandler(this.lblBufferSeconds_Click);
            // 
            // bufferSeconds
            // 
            this.bufferSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferSeconds.Location = new System.Drawing.Point(597, 49);
            this.bufferSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bufferSeconds.Name = "bufferSeconds";
            this.bufferSeconds.Size = new System.Drawing.Size(38, 20);
            this.bufferSeconds.TabIndex = 11;
            this.bufferSeconds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bufferSeconds.ValueChanged += new System.EventHandler(this.bufferSeconds_ValueChanged);
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryTextBox.Location = new System.Drawing.Point(96, 11);
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.Size = new System.Drawing.Size(745, 20);
            this.summaryTextBox.TabIndex = 8;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(754, 47);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(673, 47);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 6;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnAddCard
            // 
            this.btnAddCard.Location = new System.Drawing.Point(12, 12);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(75, 23);
            this.btnAddCard.TabIndex = 5;
            this.btnAddCard.Text = "Add Card";
            this.btnAddCard.UseVisualStyleBackColor = true;
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // btnClearAllChannels
            // 
            this.btnClearAllChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAllChannels.Location = new System.Drawing.Point(120, 85);
            this.btnClearAllChannels.Name = "btnClearAllChannels";
            this.btnClearAllChannels.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllChannels.TabIndex = 10;
            this.btnClearAllChannels.Text = "Clear All";
            this.btnClearAllChannels.UseVisualStyleBackColor = true;
            this.btnClearAllChannels.Click += new System.EventHandler(this.btnClearAllChannels_Click);
            // 
            // btnCheckAllChannels
            // 
            this.btnCheckAllChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAllChannels.Location = new System.Drawing.Point(3, 85);
            this.btnCheckAllChannels.Name = "btnCheckAllChannels";
            this.btnCheckAllChannels.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAllChannels.TabIndex = 9;
            this.btnCheckAllChannels.Text = "Check All";
            this.btnCheckAllChannels.UseVisualStyleBackColor = true;
            this.btnCheckAllChannels.Click += new System.EventHandler(this.btnCheckAllChannels_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.Control;
            this.logBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(493, 330);
            this.logBox.TabIndex = 8;
            this.logBox.WordWrap = false;
            // 
            // splitFilesAndLog
            // 
            this.splitFilesAndLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitFilesAndLog.Location = new System.Drawing.Point(0, 210);
            this.splitFilesAndLog.Name = "splitFilesAndLog";
            // 
            // splitFilesAndLog.Panel1
            // 
            this.splitFilesAndLog.Panel1.Controls.Add(this.fileList);
            // 
            // splitFilesAndLog.Panel2
            // 
            this.splitFilesAndLog.Panel2.Controls.Add(this.logBox);
            this.splitFilesAndLog.Size = new System.Drawing.Size(844, 330);
            this.splitFilesAndLog.SplitterDistance = 347;
            this.splitFilesAndLog.TabIndex = 9;
            // 
            // presetPanel
            // 
            this.presetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.presetPanel.Controls.Add(this.btnCheckAllChannels);
            this.presetPanel.Controls.Add(this.btnClearAllChannels);
            this.presetPanel.Controls.Add(this.btnRenamePreset);
            this.presetPanel.Controls.Add(this.btnDeletePreset);
            this.presetPanel.Controls.Add(this.btnSavePreset);
            this.presetPanel.Controls.Add(this.presetCombo);
            this.presetPanel.Controls.Add(this.btnLoadPreset);
            this.presetPanel.Location = new System.Drawing.Point(847, 0);
            this.presetPanel.Name = "presetPanel";
            this.presetPanel.Size = new System.Drawing.Size(199, 112);
            this.presetPanel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 540);
            this.Controls.Add(this.presetPanel);
            this.Controls.Add(this.channelPanel);
            this.Controls.Add(this.splitFilesAndLog);
            this.Controls.Add(this.gridSdCards);
            this.Controls.Add(this.toolbarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "XLive SD Splitter";
            this.channelPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSdCards)).EndInit();
            this.toolbarPanel.ResumeLayout(false);
            this.toolbarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bufferSeconds)).EndInit();
            this.splitFilesAndLog.Panel1.ResumeLayout(false);
            this.splitFilesAndLog.Panel2.ResumeLayout(false);
            this.splitFilesAndLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilesAndLog)).EndInit();
            this.splitFilesAndLog.ResumeLayout(false);
            this.presetPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog sdCardOpener;
        private System.Windows.Forms.Panel channelPanel;
        private System.Windows.Forms.ComboBox presetCombo;
        private System.Windows.Forms.Button btnLoadPreset;
        private System.Windows.Forms.Button btnSavePreset;
        private System.Windows.Forms.Button btnRenamePreset;
        private System.Windows.Forms.Button btnDeletePreset;
        private System.Windows.Forms.CheckedListBox channelList;
        private System.Windows.Forms.DataGridView gridSdCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn card;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn channels;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn frames;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnAddCard;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.FolderBrowserDialog outputFolderOpener;
        private System.Windows.Forms.Button btnClearAllChannels;
        private System.Windows.Forms.Button btnCheckAllChannels;
        private System.Windows.Forms.SplitContainer splitFilesAndLog;
        private System.Windows.Forms.Label lblBufferSeconds;
        private System.Windows.Forms.NumericUpDown bufferSeconds;
        private System.Windows.Forms.Panel presetPanel;
    }
}

