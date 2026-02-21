using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace X_Live_SD_Splitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format("XLive SD Splitter  v{0}.{1}.{2}-{3}", version.Major, version.Minor, version.Build, version.Revision);
            RefreshPresetList();
        }

        private static string GetPresetDirectory()
        {
            string dir = Path.Combine(Application.UserAppDataPath, "XLive SD Splitter", "ChannelPresets");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        private void RefreshPresetList()
        {
            presetCombo.Items.Clear();
            string dir = GetPresetDirectory();
            if (!Directory.Exists(dir)) return;
            foreach (string path in Directory.GetFiles(dir, "*.txt"))
            {
                string name = Path.GetFileNameWithoutExtension(path);
                if (!string.IsNullOrEmpty(name))
                    presetCombo.Items.Add(name);
            }
            if (presetCombo.Items.Count > 0)
                presetCombo.SelectedIndex = 0;
        }

        private void btnSavePreset_Click(object sender, EventArgs e)
        {
            if (channelList.Items.Count == 0)
            {
                MessageBox.Show("No channels in the list. Run Validate first.", "Save Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for this channel preset:", "Save Preset", "My Preset", -1, -1);
            if (string.IsNullOrWhiteSpace(name))
                return;
            string safeName = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
            if (string.IsNullOrEmpty(safeName)) safeName = "Preset";
            string dir = GetPresetDirectory();
            string filePath = Path.Combine(dir, safeName.Trim() + ".txt");
            var checkedIndices = new List<int>();
            for (int i = 0; i < channelList.Items.Count; i++)
            {
                if (channelList.GetItemChecked(i))
                    checkedIndices.Add(i);
            }
            var lines = new string[checkedIndices.Count];
            for (int i = 0; i < checkedIndices.Count; i++)
                lines[i] = checkedIndices[i].ToString();
            File.WriteAllLines(filePath, lines);
            RefreshPresetList();
            for (int i = 0; i < presetCombo.Items.Count; i++)
            {
                if (string.Equals(presetCombo.Items[i].ToString(), safeName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    presetCombo.SelectedIndex = i;
                    break;
                }
            }
            MessageBox.Show("Preset saved.", "Save Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadPreset_Click(object sender, EventArgs e)
        {
            if (channelList.Items.Count == 0)
            {
                MessageBox.Show("No channels in the list. Run Validate first.", "Load Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (presetCombo.SelectedItem == null)
            {
                MessageBox.Show("Select a preset from the list, or save one first.", "Load Preset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = presetCombo.SelectedItem.ToString();
            string safeName = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
            string filePath = Path.Combine(GetPresetDirectory(), safeName.Trim() + ".txt");
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Preset file not found.", "Load Preset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < channelList.Items.Count; i++)
                channelList.SetItemChecked(i, false);
            foreach (string line in lines)
            {
                int idx;
                if (int.TryParse(line.Trim(), out idx) && idx >= 0 && idx < channelList.Items.Count)
                    channelList.SetItemChecked(idx, true);
            }
        }

        public class Bwu
        {
            public int Flag;
            public string s;
            public int i1;
            public int i2;

            public Bwu(int Flag, string s, int i1, int i2)
            {
                this.Flag = Flag;
                this.s = s;
                this.i1 = i1;
                this.i2 = i2;
            }
        }

        BackgroundWorker bw;
        private progressForm pf = new progressForm();
        private delegate void ObjectDelegate(object obj);
        public static string Hexify(int x)
        {
            switch (x)
            {
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
        List<byte[]> inBuf;
        int bufferIter = new int();
        bool isValidated = false;
        bool bwInit = false;
        private void button1_Click(object sender, EventArgs e)
        {
            isValidated = false;
            if (sdCardOpener.ShowDialog() != DialogResult.OK)
                return;
            AddCardFromFile(sdCardOpener.FileName);
        }

        /// <summary>
        /// Reads session header from a card file and adds one row to sdData1. Sets channels1 and bitRate1.
        /// Returns true if the row was added, false if the file could not be read.
        /// </summary>
        private bool AddCardFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return false;
            try
            {
                using (BinaryReader br = new BinaryReader(File.OpenRead(filePath)))
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
                    sdData1.Rows.Add("SD" + sdData1.RowCount, s1, (int)s2, (int)s3, (int)s5, (float)s7 / s3, Path.GetDirectoryName(filePath), s7);
                }
                isValidated = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void sdData1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void sdData1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            int added = 0;
            foreach (string path in paths)
            {
                if (string.IsNullOrWhiteSpace(path)) continue;
                if (File.Exists(path) && string.Equals(Path.GetExtension(path), ".bin", StringComparison.OrdinalIgnoreCase))
                {
                    if (AddCardFromFile(path))
                        added++;
                }
            }
            if (added > 0 && added < paths.Length)
                MessageBox.Show(string.Format("Added {0} card(s). Some files were skipped (not .bin or invalid).", added), "Drag and drop", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                channelList.Items.Add("Channel " + x.ToString("D2"), true);
            }

            foreach (DataGridViewRow dr in sdData1.Rows)
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
            TimeSpan t = TimeSpan.FromSeconds((float)totalFrames / bitRate1);

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
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            //bw.
            //bw.RunWorkerCompleted += Bw_RunWorkerCompleted; //DoIt_Done();

            if (!bwInit)
            {
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
                bw.ProgressChanged += Bw_Update1;
                bw.DoWork += (obj, e) => DoIt(obj, e, p, del);
                bwInit = true;
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

        private void Bw_Update(int Flag, string s, int i1 = -1, int i2 = -1)
        {
            if (Flag == 1)
            {
                if (i2 >= 0)
                {
                    pf.SetBar1(i1, i2);
                }
                else
                {
                    if (i1 >= 0)
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
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoIt_Done();
            //throw new NotImplementedException();
        }
        /*        private void DoIt_Updated(int file,float percent)
                {
                   // progressForm.
                    //throw new NotImplementedException();
                }
        */
        void DoIt(object sender, DoWorkEventArgs e, string p, object obj)
        {

            ObjectDelegate del = (ObjectDelegate)obj;


            // riff + totallen-8 + wav + 4 * totalframes 
            //totallen x-38
            //uint dataLen = totalFrames * 4;
            uint dataLen = totalFrames * 3; //test 24 bit mode
            uint totalLen = dataLen + 38;
            bufferFact = (int)bufferSeconds.Value * (int)bitRate1;
            bufferIter = (int)bitRate1;

            //0x80, 0xBB, 0x00, 0x00
            //byte[] wav2 = new byte[] { 0x00, 0xDC, 0x05, 0x00, 0x04, 0x00, 0x20, 0x00, 0x64, 0x61, 0x74, 0x61 };

            BinaryWriter[] bwa = new BinaryWriter[32];

            bool stat = false ;
            foreach (int cl in channelList.CheckedIndices)
            {
                if (File.Exists(p + "\\" + channelList.Items[cl] + ".wav"))
                {
                    Console.WriteLine(p + "\\" + channelList.Items[cl] + ".wav File Exists....");
                    continue;
                }
                bwa[cl] = new BinaryWriter(File.OpenWrite(p + "\\" + channelList.Items[cl] + ".wav"));
                stat = true;
            }

            if (stat)
            {
                foreach (BinaryWriter b in bwa)
                {
                    if (b == null)
                        continue;
                    Write_Wav_Header(b, bitRate1, totalLen, dataLen);
                }

                int tick = 0;
                bw.ReportProgress(0, new Bwu(2, "", tick++, fileList.Items.Count));
                foreach (string f in fileList.Items)
                {
                    bw.ReportProgress(0, new Bwu(2, f, -1, -1));
                    uint i;
                    // Use a large buffer and SequentialScan for much faster sequential reads
                    const int fileStreamBufferSize = 256 * 1024; // 256 KB read buffer
                    using (var fs = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read, fileStreamBufferSize, FileOptions.SequentialScan))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        br.ReadBytes(32760);
                        string head = br.ReadChars(4).ToString();
                        uint dataChunk = br.ReadUInt32(); //read the datasize chunk
                        i = dataChunk / ((uint)channels1 * 4); // 4 32bit samples per channel
                        del.Invoke(DateTime.Now + " Processing->" + f);
                        int frameSize = channels1 * 4;
                        byte[] intBuf = new byte[bufferFact * 3]; // 24 bit per sample

                        for (uint r = 0; r < i; r += (uint)bufferFact)
                        {
                            int toRead = (int)Math.Min(bufferFact, i - r);
                            // One bulk read instead of thousands of tiny ReadBytes(channelSize) calls
                            byte[] block = br.ReadBytes(toRead * frameSize);
                            if (block.Length == 0) break;

                            foreach (int cl in channelList.CheckedIndices)
                            {
                                int srcOffset = 1 + cl * 4; // skip low byte, take 3 bytes per channel
                                for (int xy = 0; xy < toRead; xy++)
                                {
                                    int off = xy * frameSize + srcOffset;
                                    intBuf[xy * 3] = block[off];
                                    intBuf[xy * 3 + 1] = block[off + 1];
                                    intBuf[xy * 3 + 2] = block[off + 2];
                                }
                                bwa[cl].Write(intBuf, 0, toRead * 3);
                            }

                            bw.ReportProgress(0, new Bwu(1, r + toRead + " of " + i, (int)(r + toRead), (int)i));
                        }
                    }
                    bw.ReportProgress(0, new Bwu(1, i + " of " + i, (int)i, -1));
                    bw.ReportProgress(0, new Bwu(2, tick + " of " + fileList.Items.Count, tick++, -1));
                    del.Invoke(DateTime.Now + " Complete->" + f);
                }
                // Fin .. Let's clean up


                foreach (int cl in channelList.CheckedIndices)
                {
                    bwa[cl].Close();
                    try
                    {
                        bwa[cl].Dispose();
                        bwa[cl] = null;
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                for (int tik = 0; tik < bwa.Length; tik++)
                    bwa[tik] = null;
                bwa = null;
            }
            del.Invoke(DateTime.Now + " Splitting Complete!");
            Thread.Sleep(1000);
        }

        private void Write_Wav_Header(BinaryWriter b, uint br, uint totalLen, uint dataLen)
        {
            byte[] riff = new byte[] { 0x52, 0x49, 0x46, 0x46 };
            byte[] wav = new byte[] { 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20, 0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00 };
            byte[] wav2 = new byte[] { 0x00, 0xDC, 0x05, 0x00, 0x03, 0x00, 0x18, 0x00, 0x64, 0x61, 0x74, 0x61 }; //test 24 bit
            b.Write(riff);
            b.Write(totalLen);
            b.Write(wav);
            b.Write(bitRate1);
            b.Write(wav2);
            b.Write(dataLen);
        }

        private void sdData1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            isValidated = false;
        }

        private void sdData1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            isValidated = false;
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in paths)
            {
                if (string.IsNullOrWhiteSpace(path)) continue;
                if (File.Exists(path))
                {
                    if (string.Equals(Path.GetExtension(path), ".wav", StringComparison.OrdinalIgnoreCase))
                        fileList.Items.Add(path);
                }
                else if (Directory.Exists(path))
                {
                    foreach (string f in Directory.GetFiles(path, "*.wav"))
                        fileList.Items.Add(f);
                }
            }
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
            logBox.AppendText( text + "\r\n");
            //logBox.p
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
                if (se.SelectedIndex < 0)
                    return;
                int chNum = se.SelectedIndex + 1;
                string s = Microsoft.VisualBasic.Interaction.InputBox("Enter new name for channel " + chNum.ToString("D2"), "Name Channel " + chNum.ToString("D2"), se.Text, -1, -1);
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
            pf.Close();
            string p = outputFolderOpener.SelectedPath; //System.IO.Path.GetDirectoryName(sdCard1.FileName);
            ObjectDelegate del = new ObjectDelegate(writeLog);
            {
                bw.RunWorkerCompleted -= Bw_RunWorkerCompleted;
                bw.ProgressChanged -= Bw_Update1;
                bw.DoWork -= (obj, e) => DoIt(obj, e, p, del);
                bwInit = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bufferSeconds_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}