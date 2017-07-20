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
    public partial class LOGCesccConvertM2M : Form
    {
        public LOGCesccConvertM2M()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(textBox1.Text,Encoding.Default);
            string newPath = Path.GetDirectoryName(textBox1.Text)+"\\output.txt";
            StreamWriter writer = new StreamWriter(newPath,false,Encoding.Default);
            string current=null;
            while ((current = reader.ReadLine()) != null)
            {
                writer.WriteLine(getYL(current));
            }
            writer.Close();
            reader.Close();
            MessageBox.Show("ok");
        }

        private string getYL(string current)
        {
            //06/02/2017 15:58:15 HeadID[1] DataID[1] ICCID[9868706B107109909999] Time[19s] 写卡成功
            //[06-04 00:42:19] [HHSR09_2017_094_09][7B601,17900,82659,][1][10 秒] 写卡成功
            string[] str = current.Split(' ');

            string newStr = "[" + str[0] + " " + str[1] + "]";
            newStr += " [" + textBox2.Text+"]";
            string iccid =swap(str[4]);
            newStr += " [" + iccid + "]";
            string headID = str[2].Replace("HeadID","");
            newStr += " "+headID+" ";
            string Time = str[5].Replace("Time", "");
            Time = Time.Replace("s"," 秒");
            newStr += Time;
            newStr+=" "+str[6];
            return newStr;
        }

        private string swap(string str)
        {
            //ICCID[9868706B107109909999]
            string replaceStr = str.Replace("ICCID[","");
            replaceStr = replaceStr.Replace("]", "");
            string newStr = null;
            //9868706B107109909999
            for (int i = 0; i < replaceStr.Length-1; i+=2)
            {
                newStr += replaceStr.Substring(i + 1, 1) + replaceStr.Substring(i, 1);
            }
            string s1 = newStr.Substring(0, 5);
            string s2 = newStr.Substring(5, 5);
            string s3 = newStr.Substring(10, 5);
            string s4 = newStr.Substring(15, 5);
            string s = s2 + "," + s3 + "," + s4 + ",";
            return s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(swap("ICCID[9868706B107109909999]"));
        }
    }
}
