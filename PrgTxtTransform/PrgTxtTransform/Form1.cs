using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrgTxtTransform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTxtToPrg_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "脚本文件(*.txt)|*.txt";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();

            string fileName = this.openFileDialog1.FileName;
            if (!(fileName == ""))
            {
                string sOutName = fileName + ".prg";
                Form1.ScriptTrans(fileName, sOutName);
                MessageBox.Show("完成");
            }
        }
        private static void ScriptTrans(string sScriptName, string sOutName)
        {
            StreamReader streamReader = new StreamReader(sScriptName);
            StreamWriter streamWriter = new StreamWriter(sOutName);
            string text = "";
            string sLine;
            int iCount = 0;
            while ((sLine = streamReader.ReadLine()) != null)
            {
                Script.ExcuteLine(sLine, ref text);
                if (text.Length != 0)
                {
                    iCount++;//控制最后一行不输出空行
                    if (iCount == 1)
                    {
                        streamWriter.Write(text);
                    }
                    else
                    {
                        streamWriter.Write("\r\n" + text);
                    }
                    //streamWriter.WriteLine(text);
                }
            }
            streamReader.Dispose();
            streamWriter.Dispose();
        }

        private void btnPrgToTxt_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "脚本文件(*.prg)|*.prg";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();

            string fileName = this.openFileDialog1.FileName;
            if (!(fileName == ""))
            {
                string sOutName = fileName + ".txt";
                Form1.GetPrg(fileName, sOutName);
                MessageBox.Show("完成");
            }

        }
        private static void GetPrg(string sScriptName, string sOutName)
        {
            StreamReader streamReader = new StreamReader(sScriptName);
            StreamWriter streamWriter = new StreamWriter(sOutName);
            string text = "";
            string sLine;
            while ((sLine = streamReader.ReadLine()) != null)
            {
                PrgToTxt.GetPrgLine(sLine, ref text);
                if (text.Length != 0)
                {
                    streamWriter.WriteLine(text);
                }
            }
            streamReader.Dispose();
            streamWriter.Dispose();
        }

        private void btnHcos_Click(object sender, EventArgs e)
        {
            if (txtPrgPath.Text == "") return;
            if (txtMCAPath.Text == "") return;

            StreamReader mcaReader = new StreamReader(txtMCAPath.Text,Encoding.Default);
            StreamReader prgReader = new StreamReader(txtPrgPath.Text,Encoding.Default);
            StreamWriter streamWriter = new StreamWriter(txtPrgPath.Text+".txt");
      
            string sLine;
            //读取mca变量并定义
            streamWriter.WriteLine("clear string");
            streamWriter.WriteLine(";定义");
            sLine = mcaReader.ReadLine();
            string[] variables=sLine.Split(',');
            int count = 0;
            for(int i =0;i<variables.Length;i++)
            {
                if (variables[i].IndexOf("打印数据", 0) == -1)
                {
                    count++;
                    streamWriter.WriteLine("edit Hstring $" + variables[i] + "$"); 
                }
                
            }
            streamWriter.WriteLine();
            streamWriter.WriteLine(";赋值");
            //读取mca数据并输出
            sLine = mcaReader.ReadLine();
            string[] datas = sLine.Split(',');
            for (int i = 0; i < count; i++)
            {
                streamWriter.WriteLine("edit $" + variables[i]+"$"+"="+datas[i]  );
            }
            streamWriter.WriteLine();
            //脚本转换
            string text = "";
            int iCount = 0;
            while ((sLine = prgReader.ReadLine()) != null)
            {
                PrgToTxt.GetPrgLine(sLine, ref text);
                if (text.Length != 0)
                {
                    iCount++;

                    streamWriter.WriteLine(text);


                }
            }

            mcaReader.Dispose();
            prgReader.Dispose();
            streamWriter.Dispose();
            MessageBox.Show("完成");
        }

        private void btnMca_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "数据文件(*.mca)|*.mca";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            string fileName = this.openFileDialog1.FileName;
            if(!(fileName==""))
            {
                txtMCAPath.Text = fileName;
            }
        }

        private void btnPrg_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "脚本文件(*.prg)|*.prg";
            //this.openFileDialog1.ShowDialog();
            this.openFileDialog1.FileName = "";
            //string fileName = this.openFileDialog1.FileName;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                txtPrgPath.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCount.Text = "";
            foreach (Control control in groupBox1.Controls)
            {
                if (typeof(TextBox) == control.GetType())
                {
                    ((TextBox)control).Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1="0012000000SW9000";//0012000000SW9000RESULT3B9F94801FC78031E073FE21135786811586984018BE
            string str2="";
            PrgToTxt.GetPrgLine(str1,ref str2);
            MessageBox.Show(str2);
        }

        private void btnCheckMca_Click(object sender, EventArgs e)
        {
            if (txtMCAPath.Text.Trim() != "")
            {
                
                int firstLength=0;
                int secondLength=0;
                PrgToTxt.CheckMca(txtMCAPath.Text,ref firstLength,ref secondLength);
                
                MessageBox.Show(String.Format("表头变量个数：{0}\n首行数据个数：{1}",
                    firstLength, secondLength));
            }
           
        }

        private void btnCheckPrg_Click(object sender, EventArgs e)
        {
            //读取mca表头变量
            //StreamReader reader = new StreamReader(txtMCAPath.Text, Encoding.Default);
            //string[] firstLines = reader.ReadLine().Split(',');
            //string[] secondLines = reader.ReadLine().Split(',');
            //reader.Close();
            //MessageBox.Show(String.Format("表头变量个数：{0}\n首行数据个数：{1}",
            //    firstLines.Length, secondLines.Length));
            if (txtPrgPath.Text == "") return;
            if (txtMCAPath.Text == "") return;

            string[] PrgVariables = PrgToTxt.GetPrgVariables(txtPrgPath.Text);
            string[] McaVariables = PrgToTxt.GetMcaVariables(txtMCAPath.Text);
            int count = 0;
            int failCount = 0;
            string lack = "";
            //HashSet<string> hashSet = new HashSet<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/脚本校验结果.txt";
            //StreamWriter writer = new StreamWriter(path, false, Encoding.Default);
            foreach (string s in McaVariables)
            {
                dict.Add(s, 1);
                //writer.WriteLine(s);
            }
            foreach (string s in PrgVariables)
            {
                //prg变量数组已经用hashset剔除重复了
                if (dict.ContainsKey(s))
                {
                    count++;

                }
                else
                {
                    failCount++;
                    lack += s;
                }
                //writer.WriteLine(s);
            }
            //writer.Close();
            if (failCount == 0)
            {
                MessageBox.Show("参数匹配","校验结果");
            }
            else
            {
                MessageBox.Show(String.Format("脚本参数：{0} \n数据参数：{1}\n匹配个数：{2}\n缺失个数：{3}\n{4}",
                                                PrgVariables.Length, McaVariables.Length, count, failCount, lack), "校验结果");
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            

        }

        private void btnHCosToPrg_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "脚本文件(*.txt)|*.txt";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();

            string fileName = this.openFileDialog1.FileName;
            if (!(fileName == ""))
            {
                string sOutName = fileName + ".prg";
                //Form1.ScriptTrans(fileName, sOutName);
                StreamReader streamReader = new StreamReader(fileName);
                StreamWriter streamWriter = new StreamWriter(sOutName);
                string text = "";
                string sLine;
                int iCount = 0;
                while ((sLine = streamReader.ReadLine()) != null)
                {
                    Script.ExcuteLine(sLine, ref text);

                    if ((text.Length != 0) && (text.IndexOf("不可识别的关键字",0) == -1))
                    {
                        string newText =PrgToTxt.ReplaceLabel(text);
                        //streamWriter.WriteLine(newText);
                        iCount++;//控制最后一行不输出空行
                        if (iCount == 1)
                        {
                            streamWriter.Write(newText);
                        }
                        else
                        {
                            streamWriter.Write("\r\n" + newText);
                        }
                    }
                }
                streamReader.Dispose();
                streamWriter.Dispose();


                MessageBox.Show("完成");
            }

        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            txtSwapAfter.Text = PrgToTxt.Swap(txtSwapBefor.Text);
        }

        private void txtSwapBefor_TextChanged(object sender, EventArgs e)
        {
            lblCount.Text = txtSwapBefor.Text.Length.ToString();
        }
    }
}
