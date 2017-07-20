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
    public partial class FormGetColumn : Form
    {
        public FormGetColumn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            StreamReader streamReader = new StreamReader(textBox1.Text, Encoding.Default);

            string path = Path.GetDirectoryName(textBox1.Text);

            StreamWriter streamWriter = new StreamWriter(path + @"\提取列数据.txt", false, Encoding.Default);
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
                streamWriter.WriteLine(current);
                //streamWriter.WriteLine(current);
            }
            streamReader.Close();

   
            //结果输出
            string outMessage = "\r\n日志文件条数：\t" + logCount;

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void FormGetColumn_Load(object sender, EventArgs e)
        {
            txtSplit.Text = "]";
            txtNum.Text = "3";
        }

    }
}
