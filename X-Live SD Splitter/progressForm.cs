using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            progressBar1.Value = v;
        }
        public void SetBar1(int v, int x)
        {
            progressBar1.Maximum = x;
            progressBar1.Value = v;
        }
        public void SetBar2(int v)
        {
            progressBar2.Value = v;
        }
        public void SetBar2(int v, int x)
        {
            progressBar2.Maximum = x;
            progressBar2.Value = v;
        }

        public void SetText1 (string s)
        {
            textBox1.Text = s;
        }

        public void SetText2(string s)
        {
            textBox2.Text = s;

        }
        private void progressForm_Load(object sender, EventArgs e)
        {
        }
    }
}
