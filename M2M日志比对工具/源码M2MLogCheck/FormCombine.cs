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
    public partial class FormCombine : Form
    {
        public FormCombine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }
        public static string CombineTxt(string[] filePaths,string name)
        {
            string combinePath = Path.GetDirectoryName(filePaths[0]) + "\\"+name+"合并日志.txt";
                //Path.GetExtension(filePaths[0]);
                    
            StreamWriter sWriter = new StreamWriter(combinePath, false, Encoding.Default);
            string currentLine;
            long lineNumber = 0;
            foreach (string filePath in filePaths)
            {              
                StreamReader sReader = new StreamReader(filePath, Encoding.Default);
                while ((currentLine = sReader.ReadLine()) != null)
                {
                    lineNumber++;

                    sWriter.WriteLine(currentLine);
                    

                }
                sReader.Close();
            }
            sWriter.Close();
            return combinePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] fileLists = GetFileList(textBox1.Text);
            string combinePath = CombineTxt(fileLists,this.cmbNum.Text);
            MessageBox.Show("ok!");
        }
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="folder">文件夹路径</param>
        /// <param name="exextension">文件扩展名</param>
        /// <returns></returns>
        public static string[] GetFileList(string folder)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            List<string> list = new List<string>();
            foreach (FileInfo file in fileInfos)
            {
                //if (file.Name.IndexOf("Combine") == -1)
                //{
                    list.Add(file.FullName);
                //}
                //else
                //{
                //    File.Delete(file.FullName);
                //}
            }
            list.Sort();
            return list.ToArray();
        }

        private void FormCombine_Load(object sender, EventArgs e)
        {
            this.cmbNum.Items.Add("M2M");
            this.cmbNum.Items.Add("M2M-1");
            this.cmbNum.Items.Add("M2M-2");
            this.cmbNum.Items.Add("M2M-3");
            this.cmbNum.Items.Add("M2M-4");
            //this.cmbNum.Items.Add("");
            this.cmbNum.SelectedIndex = 0;
        }
    }
}
