using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Live_SD_Splitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public class Bwu
        {
            public int Flag;
            public string s;
            public int i1;
            public int i2;

            public Bwu(int Flag,string s, int i1,int i2)
            {
                this.Flag = Flag;
                this.s = s;
                this.i1 = i1;
                this.i2 = i2;
            }


        }

        BackgroundWorker bw = new BackgroundWorker();
        private progressForm pf = new progressForm();
        private delegate void ObjectDelegate(object obj);
        public static string Hexify(int x)
        {
            switch (x) { 
                case 1: return "01";
                case 2: return "02";
                case 3: return "03";
                case 4: return "04";
                case 5: return "05";
                case 6: return "06";
                case 7: return "07";
                case 8: return "08";
                case 9: return "09";
                case 10: return "0A";
                case 11: return "0B";
                case 12: return "0C";
                case 13: return "0D";
                case 14: return "0E";
                case 15: return "0F";
                case 16: return "10";
                case 17: return "11";
                case 18: return "12";
                case 19: return "13";
                case 20: return "14";
                case 21: return "15";
                case 22: return "16";
                case 23: return "17";
                case 24: return "18";
                case 25: return "19";
                case 26: return "1A";
                case 27: return "1B";
                case 28: return "1C";
                case 29: return "1D";
                case 30: return "1E";
                case 31: return "1F";
                case 32: return "20";
                case 33: return "21";
                case 34: return "22";
                case 35: return "23";
                case 36: return "24";
                case 37: return "25";
                case 38: return "26";
                case 39: return "27";
                case 40: return "28";
                case 41: return "29";
                case 42: return "2A";
                case 43: return "2B";
                case 44: return "2C";
                case 45: return "2D";
                case 46: return "2E";
                case 47: return "2F";

                default: return "";



            }

        }

        uint totalFrames = new uint();
        uint bitRate1 = new uint();
        int channels1 = new int();
        int bufferFact = new int();
        int bufferIter = new int();
        bool isValidated = false;
        bool bwInit = false;
        List<byte[]> inBuf;
        private void button1_Click(object sender, EventArgs e)
        {
            isValidated = false;
            if (sdCardOpener.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //StreamReader sr = new StreamReader(sdCardOpener.FileName);
            //BinaryReader br = new BinaryReader(sr.BaseStream);
            using (BinaryReader br = new BinaryReader(File.OpenRead(sdCardOpener.FileName)))
            {
                uint s1 = br.ReadUInt32(); // session
                uint s2 = br.ReadUInt32(); // channels
                channels1 = (int)s2;
                uint s3 = br.ReadUInt32(); // bitrate
                bitRate1 = s3;
                uint s4 = br.ReadUInt32(); // session again
                uint s5 = br.ReadUInt32(); // files
                uint s6 = br.ReadUInt32(); // something
                uint s7 = br.ReadUInt32(); // total frames

                uint s8 = br.ReadUInt32(); // samples in file 1
                //br.Close();
                sdData1.Rows.Add("SD" + sdData1.RowCount, s1, (int)s2, (int)s3, (int)s5, (float)s7 / s3, System.IO.Path.GetDirectoryName(sdCardOpener.FileName), s7);
            }
        }


        private void Verify_Click(object sender, EventArgs e)
        {
            channelList.Items.Clear();
            fileList.Items.Clear();
            totalFrames = 0;
            if (sdData1.Rows.Count < 1)
            {
                MessageBox.Show("Add Card(s) First");
                return;
            }

            for (int x = 1; x <= (int)sdData1.Rows[0].Cells[2].Value; x++)
            {

                channelList.Items.Add("Channel " + x, true);
            }

            foreach(DataGridViewRow dr in sdData1.Rows)
            {
                if (dr.Cells[1].Value == null)
                    continue;
                totalFrames += (uint)dr.Cells[7].Value;
                string dp = (string)dr.Cells[6].Value;
                for (int x = 1; x <= (int)dr.Cells[4].Value; x++)
                {
                    string fName = dp + "\\000000" + Hexify(x) + ".WAV";
                    if (File.Exists(fName))
                    {
                        fileList.Items.Add(fName);
                    }
                    else
                        MessageBox.Show("File " + fName + " is invalid");
                }
            }
            TimeSpan t = TimeSpan.FromSeconds((float)totalFrames/bitRate1);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            textBox1.Text = "Total Frames: " + totalFrames + " Total Time: " + answer;
            isValidated = true;
        }

        private void button3_Click(object sender, EventArgs ef)
        {
            if (!isValidated)
            {
                MessageBox.Show("Validate First Please");
                return;
            }
            if (channelList.CheckedItems.Count < 1)
            {
                MessageBox.Show("No Channels Selected");
                return;
            }
            if (outputFolderOpener.ShowDialog() != DialogResult.OK)
                return;
            string p = outputFolderOpener.SelectedPath; //System.IO.Path.GetDirectoryName(sdCard1.FileName);
            ObjectDelegate del = new ObjectDelegate(writeLog);
            del.Invoke(DateTime.Now + " Saving to " + p);

            /*
            Thread DoItThread = new Thread(() =>
            {
                DoIt(p,del);
            });
            */
            bw.WorkerReportsProgress = true;
            //bw.
            //bw.RunWorkerCompleted += Bw_RunWorkerCompleted; //DoIt_Done();
            
            if (!bwInit)
            {
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
                bw.ProgressChanged += Bw_Update1;
                bw.DoWork += (obj, e) => DoIt(obj, e, p, del);
                bwInit=true;
            }
            //bw.ProgressChanged += Bw_Update1;
            //object d = new{ p, del };
            //DoItThread.
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            if (pf.IsDisposed)
                pf = new progressForm();
            pf.Show();
            bw.RunWorkerAsync();
            //DoItThread.Start();
        }


        private void Bw_Update1(object sender, ProgressChangedEventArgs s)
        {
            int a = s.ProgressPercentage;
            Bwu z = s.UserState as Bwu;
            Bw_Update(z.Flag, z.s, z.i1, z.i2);
          
        }

        private void Bw_Update(int Flag,string s,int i1=-1,int i2=-1)
        {
            if (Flag == 1)
            {
                if (i2 >= 0)
                {
                    pf.SetBar1(i1, i2);
                }
                else
                {
                    if (i1 >=0)
                        pf.SetBar1(i1);
                }
                if (s.Length > 0)
                    pf.SetText1(s);

            }
            if (Flag == 2)
            {
                if (i2 >= 0)
                {
                    pf.SetBar2(i1, i2);
                }
                else
                {
                    if (i1 >= 0)
                        pf.SetBar2(i1);
                }
                if (s.Length > 0)
                    pf.SetText2(s);

            }
            //  zed = e.Argument;
            //DoIt((string).p, (object)zed.del);
            //throw new NotImplementedException();
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoIt_Done();
            //throw new NotImplementedException();
        }
        private void DoIt_Updated(int file,float percent)
        {
           // progressForm.
            //throw new NotImplementedException();
        }

        void DoIt(object sender, DoWorkEventArgs e ,string p,object obj) {

            ObjectDelegate del = (ObjectDelegate)obj;


            // riff + totallen-8 + wav + 4 * totalframes 
            //totallen x-38
            //uint dataLen = totalFrames * 4;
            uint dataLen = totalFrames * 3; //test 24 bit mode
            uint totalLen = dataLen + 38;
            bufferFact = 10 * (int)bitRate1;
            bufferIter = (int)bitRate1;
           
            byte[] riff = new byte[] { 0x52, 0x49, 0x46, 0x46 };
            byte[] wav = new byte[] { 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20, 0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00 };
            //0x80, 0xBB, 0x00, 0x00
            //byte[] wav2 = new byte[] { 0x00, 0xDC, 0x05, 0x00, 0x04, 0x00, 0x20, 0x00, 0x64, 0x61, 0x74, 0x61 };
            byte[] wav2 = new byte[] { 0x00, 0xDC, 0x05, 0x00, 0x03, 0x00, 0x18, 0x00, 0x64, 0x61, 0x74, 0x61 }; //test 24 bit

            //System.IO.StreamWriter[] swa =new System.IO.StreamWriter[32];
            System.IO.BinaryWriter[] bwa = new System.IO.BinaryWriter[32];

            foreach (  int cl in channelList.CheckedIndices)
            {
                //swa[cl] = new System.IO.StreamWriter(p + "\\" + channelList.Items[cl] + ".wav");
                //bwa[cl] = new System.IO.BinaryWriter(swa[cl].BaseStream);
                bwa[cl] = new System.IO.BinaryWriter(File.OpenWrite(p + "\\" + channelList.Items[cl] + ".wav"));
            }

            foreach (System.IO.BinaryWriter b in bwa )
            {
                if (b == null)
                    continue;
                b.Write(riff);
                b.Write(totalLen);
                b.Write(wav);
                b.Write(bitRate1);
                b.Write(wav2);
                b.Write(dataLen);
            }
            inBuf = new List<byte[]>();
            for (int x=0; x<bufferFact; x++)
                inBuf.Add(new byte[]{});
            int tick = 0;
            bw.ReportProgress(0, new Bwu(2, "", tick++, fileList.Items.Count));
            foreach (string f in fileList.Items)
            {
                
                bw.ReportProgress(0, new Bwu(2, f, -1, -1));
                //StreamReader sr = new StreamReader(f);
                BinaryReader br = new BinaryReader(File.OpenRead(f));
                br.ReadBytes(32760);
                string head = br.ReadChars(4).ToString();
                uint i = br.ReadUInt32(); //read the datasize chunk
                i = i/ ((uint)channels1*4); // 4 32bit samples per channel
                 del.Invoke(DateTime.Now + " Processing->" + f);
                byte[] dataBuf = new byte[channels1 * 4];
                byte[] intBuf = new byte[bufferFact * 3]; // test 24 bit

                for (int r = 0; r  < i; r+=bufferFact)
                {

                    bw.ReportProgress(0, new Bwu(1, r + " of " + i, r, (int)i));
                    if ((i - r) < bufferFact)
                    {
                        for (int x = 0; x < (i-r); x++)
                            inBuf[x] = br.ReadBytes(channels1 * 4);
                        foreach (int cl in channelList.CheckedIndices)
                        {
                            for (int xy = 0; xy < (i - r); xy++)
                            {
                                inBuf[xy].CopyTo(dataBuf, 0);
                                intBuf[xy * 3] = dataBuf[1 + cl * 4 ];
                                intBuf[xy * 3+1] = dataBuf[2 + cl * 4];
                                intBuf[xy * 3 + 2] = dataBuf[3 + cl * 4];
                            }
                            bwa[cl].Write(intBuf, 0, ((int)i - r) * 3);
                        }
                    }
                    else
                    {
                        for (int x = 0; x < bufferFact; x++)
                            inBuf[x] = br.ReadBytes(channels1 * 4);
                        foreach (int cl in channelList.CheckedIndices)
                        {
                            for (int xy = 0; xy < bufferFact; xy++)
                            {
                                inBuf[xy].CopyTo(dataBuf, 0);
                                intBuf[xy * 3] = dataBuf[1 + cl * 4];
                                intBuf[xy * 3 + 1] = dataBuf[2 + cl * 4];
                                intBuf[xy * 3 + 2] = dataBuf[3 + cl * 4];
                            }
                            bwa[cl].Write(intBuf);
                        }
                    }
                    bw.ReportProgress(0, new Bwu(1, r + " of " + i, r, -1));

                }

                bw.ReportProgress(0, new Bwu(1, i + " of " + i, (int)i,-1));
                bw.ReportProgress(0, new Bwu(2, tick + " of " + fileList.Items.Count, tick++, -1));
                del.Invoke(DateTime.Now + " Complete->" + f);
            }

            foreach (int cl in channelList.CheckedIndices)
            {
                bwa[cl].Close();
                try
                {
                    bwa[cl].Dispose();
                }
                catch
                {
                    
                }
            }

            del.Invoke(DateTime.Now + " Splitting Complete!");
            Thread.Sleep(1000);
        }

   
        private void sdData1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            isValidated = false;
        }

        private void sdData1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            isValidated = false;
        }

        private void writeLog(object obj)
        {
            if (InvokeRequired)
            {
               
                // we then create the delegate again
                // if you've made it global then you won't need to do this
                ObjectDelegate method = new ObjectDelegate(writeLog);
                // we then simply invoke it and return
                Invoke(method, obj);
                return;
            }
            // ok so now we're here, this means we're able to update the control
            // so we unbox the object into a string
            string text = (string)obj;
            logBox.Text += text + "\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < channelList.Items.Count; i++)
            {
                channelList.SetItemChecked(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < channelList.Items.Count; i++)
            {
                channelList.SetItemChecked(i, false);
            }

        }

        private void ReadX32Scene()
        {
            /* 
             * /config/routing/CARD AN1-8 AN9-16 AUX/TB OUT1-8
             *
             * /ch/01/config "KICK" 1 CY 1    (input is the digit at the end)
             * 
             */
        }

        private void channelList_DoubleClick(object sender, EventArgs e)
        {

            CheckedListBox se = (CheckedListBox)sender;
            {
                //MessageBox.Show(se.Text);
                string s = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", se.Text, -1, -1);
                if (s.Length > 0)
                {
                    channelList.Items[se.SelectedIndex] = s;
                }
                channelList.SetItemChecked(se.SelectedIndex, true);
            }
        }

        private void DoIt_Done()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
    }
}   