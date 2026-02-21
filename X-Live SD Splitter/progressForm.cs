using System;
using System.Windows.Forms;


namespace X_Live_SD_Splitter
{
    public partial class progressForm : Form
    {
        public progressForm()
        {
            InitializeComponent();
        }

        public void SetBar1(int v)
        {
            progressBarCurrentFile.Value = v;
        }
        public void SetBar1(int v, int x)
        {
            progressBarCurrentFile.Maximum = x;
            progressBarCurrentFile.Value = v;
        }
        public void SetBar2(int v)
        {
            progressBarOverall.Value = v;
        }
        public void SetBar2(int v, int x)
        {
            progressBarOverall.Maximum = x;
            progressBarOverall.Value = v;
        }

        public void SetText1 (string s)
        {
            lblCurrentFileProgress.Text = s;
        }

        public void SetText2(string s)
        {
            lblOverallProgress.Text = s;

        }
        private void progressForm_Load(object sender, EventArgs e)
        {
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
