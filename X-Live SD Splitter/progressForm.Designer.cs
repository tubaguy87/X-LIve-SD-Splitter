namespace X_Live_SD_Splitter
{
    partial class progressForm
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
            this.progressBarCurrentFile = new System.Windows.Forms.ProgressBar();
            this.progressBarOverall = new System.Windows.Forms.ProgressBar();
            this.lblCurrentFileProgress = new System.Windows.Forms.Label();
            this.lblOverallProgress = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarCurrentFile
            // 
            this.progressBarCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCurrentFile.Location = new System.Drawing.Point(0, 35);
            this.progressBarCurrentFile.Name = "progressBarCurrentFile";
            this.progressBarCurrentFile.Size = new System.Drawing.Size(225, 23);
            this.progressBarCurrentFile.TabIndex = 0;
            // 
            // progressBarOverall
            // 
            this.progressBarOverall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarOverall.Location = new System.Drawing.Point(0, 83);
            this.progressBarOverall.Name = "progressBarOverall";
            this.progressBarOverall.Size = new System.Drawing.Size(225, 23);
            this.progressBarOverall.TabIndex = 1;
            // 
            // lblCurrentFileProgress
            // 
            this.lblCurrentFileProgress.AutoSize = true;
            this.lblCurrentFileProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFileProgress.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentFileProgress.Name = "lblCurrentFileProgress";
            this.lblCurrentFileProgress.Size = new System.Drawing.Size(45, 16);
            this.lblCurrentFileProgress.TabIndex = 4;
            this.lblCurrentFileProgress.Text = "label1";
            // 
            // lblOverallProgress
            // 
            this.lblOverallProgress.AutoSize = true;
            this.lblOverallProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverallProgress.Location = new System.Drawing.Point(12, 65);
            this.lblOverallProgress.Name = "lblOverallProgress";
            this.lblOverallProgress.Size = new System.Drawing.Size(45, 16);
            this.lblOverallProgress.TabIndex = 5;
            this.lblOverallProgress.Text = "label2";
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(58, 123);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 6;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // progressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 158);
            this.ControlBox = false;
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblOverallProgress);
            this.Controls.Add(this.lblCurrentFileProgress);
            this.Controls.Add(this.progressBarOverall);
            this.Controls.Add(this.progressBarCurrentFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "progressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.progressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBarCurrentFile;
        public System.Windows.Forms.ProgressBar progressBarOverall;
        private System.Windows.Forms.Label lblCurrentFileProgress;
        private System.Windows.Forms.Label lblOverallProgress;
        private System.Windows.Forms.Button btnHide;
    }
}