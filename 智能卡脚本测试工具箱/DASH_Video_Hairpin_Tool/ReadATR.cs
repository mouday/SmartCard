using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnicomTool;
using System.IO;

namespace DASH_Video_Hairpin_Tool
{
    public partial class ReadATR : Form
    {
        private static PCSC pcscer = new PCSC();
        DateTime dt = new DateTime();

        public ReadATR()
        {
            InitializeComponent();
        }

        private void ReadATR_Load(object sender, EventArgs e)
        {
            this.lblResult.Text = "";
            this.lblResult.Font=new Font("宋体",12);
            this.GetListOfReaders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //比较ATR
            string ATRresult = reset();
            if (ATRresult == "复位失败")
            {
                this.lblResult.Text = ATRresult;
                this.lblResult.BackColor = Color.Red;
                return;
            }
            if (ATRresult != txtExceptATR.Text)
            {
                this.lblResult.Text = "核对失败\n" + ATRresult;
                this.lblResult.BackColor = Color.Red;
                return;
            }
            else if (ATRresult == txtExceptATR.Text)
            {
                
                this.lblResult.Text = "核对正确\n" + ATRresult;
                this.lblResult.BackColor = Color.Green;
                

                if (txtTitle.Text == "")
                {
                    MessageBox.Show("请输入批次号！");
                }
                else
                {
                    addToLog(txtTitle.Text, txtExceptATR.Text);
                    MessageBox.Show("ATR保存成功！");
                }

            }

        }
        //增加到日志
        private void addToLog(string title, string ATR)
        {
            string path = System.Environment.CurrentDirectory + "\\ATR检验记录.txt";          
            string time = DateTime.Now.ToString("F");//2017年6月22日 14:24:46
            if (!(File.Exists(path)))
            {
                StreamWriter w = new StreamWriter(path, true, Encoding.Default);
                string s = "时间";
                s = s.PadLeft(20, ' ');
                string t = "批次号";
                t = t.PadLeft(25, ' ');
                string a = "ATR";
                a = a.PadLeft(30, ' ');

                w.WriteLine(s+"\t"+t+"\t"+"\t"+a);
                w.Close();
            }
            //title = title.PadRight(30,' ' );
            StreamWriter writer = new StreamWriter(path, true, Encoding.Default);
            writer.WriteLine(time + "\t" + String.Format("{0,-30}", title) + "\t" + ATR);//String.Format("{0,-50}", title)
            writer.Close();
        }
        //reset
        private string reset()
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            ret = ReadATR.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret != 0)
            {
                return "复位失败";
            }
            return strRet;
        }
        private void GetListOfReaders()
        {
            this.cmbReaders.Items.Clear();
            StringBuilder Readers = new StringBuilder(2048);
            string SReader = "";
            int i = 1;
            long R = ReadATR.pcscer.PCSCListOfReader(Readers);
            for (int j = 0; j < Readers.Length; j++)
            {
                char t = Readers[j];
                if (t == ',')
                {
                    if (i == 1)
                    {
                        publicConst.hhcardname1 = SReader;
                        i++;
                    }
                    else
                    {
                        publicConst.hhcardname2 = SReader;
                    }
                    this.cmbReaders.Items.Add(SReader);
                    SReader = "";
                }
                else
                {
                    SReader += t.ToString();
                }
            }
            if (this.cmbReaders.Items.Count != 0)
            {
                try
                {
                    this.cmbReaders.SelectedIndex = 0;
                    PCSC.ReaderN = this.cmbReaders.SelectedIndex + 1;
                }
                catch
                {
                    MessageBox.Show("读卡器选择错误");
                }
            }
            else
            {
                this.cmbReaders.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            this.GetListOfReaders();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.Environment.CurrentDirectory);
        }

        private void 打开ATR记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory + "\\ATR检验记录.txt";
            System.Diagnostics.Process.Start("notepad.exe", path);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            addToLog("R0172364（HHSR09-2017-097-05）", "3B1F9684050380060902031010FFFFFF9000");
            addToLog("WW1213-20170426", "3B1F9684050380060902031010FFFFFF9000");
            addToLog("R0172364", "3B1F9684050380060902031010FFFFFF9000");
            addToLog("预个人化HHYF09-2017-098", "3B1F9684050380060902031010FFFFFF9000");
            addToLog("预个人化HHSR09-2016-030-51", "3B1F9684050380060902031010FFFFFF9000");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmbReaders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
