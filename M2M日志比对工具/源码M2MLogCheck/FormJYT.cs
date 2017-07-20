using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace M2MLogCheck
{
    public partial class FormJYT : Form
    {
        public FormJYT()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = txtBeging.TextLength.ToString();
        }

        private void FormJYT_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            txtBeging.Text = "";//"98000000000000";
            txtEnd.Text = "";// "98000000000100";
            progressBar1.Visible = false;
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            label5.Text = txtEnd.TextLength.ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "日志文件(*.log)|*.log|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLog.Text = openFileDialog.FileName;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            StreamReader streamReader = new StreamReader(txtLog.Text,Encoding.Default);
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            StreamWriter streamWriter = new StreamWriter(dir + @"\京医通日志比对结果.txt");
            HashSet<string > hash=new HashSet<string>();
            List<string> Lacks = new List <string>();
            List<string> Repeats = new List<string>();
            string current=null;
            long logCount = 0;

            //验证日志文件中的重复性
            while ((current = streamReader.ReadLine()) != null)
            {
                logCount++;
                current = GetID(current);
                if (hash.Add(current))
                {
                    //ok

                }
                else
                {
                    Repeats.Add(current);
                }
                //streamWriter.WriteLine(current);
            }
            streamReader.Close();
            
            //验证日志文件的连续性
            long IDBeging = 0;
            long IDEnd = 0;
            long.TryParse(txtBeging.Text,out IDBeging);
            long.TryParse(txtEnd.Text, out IDEnd);
            long IDCount = 0;
            for (long i = IDBeging; i <= IDEnd; i++)
            {
                IDCount++;
                if (hash.Add(i.ToString()))
                {
                    Lacks.Add(i.ToString());
                }
                else
                { 
                    //ok;
                }
            }
            //计算重复和缺失的数目
            List<Item> repeatCounts = new List<Item>();          
            repeatCounts = ClassJYT.GetCount(Repeats);

            streamWriter.WriteLine("*******************京医通日志比对结果***********************");
            streamWriter.WriteLine("*******************日志重复项***********************");
            foreach (Item item in repeatCounts)
            {
                streamWriter.WriteLine("卡号：{0}     出现次数：{1}",item.Field,item.Count);
            }
            streamWriter.WriteLine();
            streamWriter.WriteLine();

            streamWriter.WriteLine("*******************日志缺失项***********************");
            foreach (string str in Lacks)
            {
                streamWriter.WriteLine("卡号：{0}", str);
            }
            streamWriter.WriteLine();
            streamWriter.WriteLine();
            streamWriter.WriteLine("*******************日志统计汇总***********************");
            //结果输出
            string outMessage="比对范围：\t"+txtBeging.Text+" ~ "+txtEnd.Text+
                                         "\r\n日志文件条数：\t" + logCount +
                                         "\r\n日志比对条数：\t"+IDCount+
                                        "\r\n重复日志条数：\t" + repeatCounts.Count + 
                                        "\r\n缺失日志条数：\t" + Lacks.Count;
            streamWriter.Write(outMessage);

            streamWriter.Close(); 
            progressBar1.Style=ProgressBarStyle.Blocks;
            progressBar1.Visible = false;
            MessageBox.Show(outMessage);
        }

        /// <summary>
        /// 处理日志，提取ID
        /// </summary>
        /// <param name="str">日志单行</param>
        /// <returns>提取的ID</returns>
        private static string GetID(string str)
        { 
            string strID=null;
            if (str != null)
            {
                int point=str.IndexOf(']');
                strID=str.Substring(point+1);
                strID = strID.Trim();
                strID = strID.Replace(" ","");
            }
            return strID;
        }
    }
}
