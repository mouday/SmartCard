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
    public partial class FormCheckRepeat : Form
    {
        public FormCheckRepeat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            StreamReader streamReader = new StreamReader(textBox1.Text, Encoding.Default);
      
            string path = Path.GetDirectoryName(textBox1.Text);

            StreamWriter streamWriter = new StreamWriter(path + @"\重复项.txt", false, Encoding.Default);
            HashSet<string> hash = new HashSet<string>();
            List<string> Lacks = new List<string>();
            List<string> Repeats = new List<string>();
            string current = null;
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

           
            //计算重复和缺失的数目
            List<Item> repeatCounts = new List<Item>();
            repeatCounts = ClassJYT.GetCount(Repeats);

            streamWriter.WriteLine("*******************日志重复项***********************");
            foreach (Item item in repeatCounts)
            {
                streamWriter.WriteLine("卡号：{0}     出现次数：{1}", item.Field, item.Count);
            }
            streamWriter.WriteLine();

           
            //结果输出
            string outMessage =
                                         "\r\n日志文件条数：\t" + logCount +

                                        "\r\n重复日志条数：\t" + repeatCounts.Count;
                                       
            streamWriter.Write(outMessage);

            streamWriter.Close();
            
            MessageBox.Show(outMessage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }
        private static string GetID(string str)
        {
            string strID = null;
            if (str != null)
            {
                string[] strs = str.Split(']');
                strID = strs[2];
                strID = strID.Trim();
                strID = strID.Replace(" ", "");
                strID = strID.Replace("[", "");
                strID = strID.Replace(",", "");
            }
            return strID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
