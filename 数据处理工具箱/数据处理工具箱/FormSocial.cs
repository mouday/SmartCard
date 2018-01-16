#define Debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using Excel=Microsoft.Office.Interop.Excel;
using FormApp = System.Windows.Forms.Application;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using FileNameSortBySys;

namespace DataHandle
{
    public partial class FormSocial : Form
    {
        public FormSocial()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = folderBrowserDialog.SelectedPath;
            }
        }

       

        private delegate void DelMessage(string str);
        private DelMessage delmessage;
        private struct MyPath
        {
            public string InputPath;
            public string OutputPath;
        }

        private delegate void DelProgress();
        private DelProgress delProgress;
        private void RefreshProgress()
        {
            progressBar1.PerformStep();
        }
        private delegate void DelSetProgress(int value);
        private DelSetProgress delSetProgress;
        private void SetProgress(int value)
        {
            progressBar1.Maximum = value;
        }

    
        private void btnCombine_Click(object sender, EventArgs e)
        {
            MyPath mypath = new MyPath();
            mypath.InputPath = txtInput.Text;
            mypath.OutputPath = txtOutput.Text;

            delmessage = new DelMessage(ShowMessage);
            delProgress = new DelProgress(RefreshProgress);
            delSetProgress = new DelSetProgress(SetProgress);

            Thread t = new Thread(HandleFile);
            t.Start(mypath);
                     
        }
        private void ShowMessage(string str)
        {
            MessageBox.Show(str);
        }
        private  void HandleFile(object path)
        {
            try
            {
                MyPath mypath = (MyPath)path;
                string InputPath = mypath.InputPath;
                string OutputPath = mypath.OutputPath;

                File.WriteAllText(FormApp.StartupPath + "\\path.txt", InputPath + "\r\n" + OutputPath);
                //获取目录树

                DirectoryInfo dirInfo = new DirectoryInfo(InputPath);
                fileList.Clear();
                WalkDirectoryTree(dirInfo);
                File.AppendAllLines(FormApp.StartupPath + "\\AllList.txt", fileList);

                //progressBar1.Maximum = fileList.Count;
                this.Invoke(delSetProgress, fileList.Count);
                //分类
                List<string> jpgList = new List<string>();
                List<string> xlsList = new List<string>();
                List<string> txtList = new List<string>();
                foreach (string file in fileList)
                {
                    if (Path.GetExtension(file) == ".jpg") jpgList.Add(file);
                    if (Path.GetExtension(file) == ".txt") txtList.Add(file);
                    if (Path.GetExtension(file) == ".xls") xlsList.Add(file);
                }
                File.AppendAllLines(FormApp.StartupPath + "\\jpgList.txt", jpgList);
                File.AppendAllLines(FormApp.StartupPath + "\\txtList.txt", txtList);
                File.AppendAllLines(FormApp.StartupPath + "\\xlsList.txt", xlsList);

                //逐个处理
                //拷贝jpg
                if (jpgList.Count > 0)
                {
                    string outputFolder = Path.Combine(OutputPath, "jpg");
                    CopyJpg(jpgList, outputFolder);
                }
                //合并txt
                if (txtList.Count > 0)
                {
                    string datapath = Path.Combine(OutputPath, "合并DATA.txt");
                    //排序后再合并，保持每次合并结果一致
                    CombineTxt(FileNameSort.sortFiles(txtList), datapath);
                }
                //this.Invoke(delmessage,"ok");
                //Invoke((EventHandler)delegate { MessageBox.Show("Something"); });
                
                //合并excel
                if (xlsList.Count > 0)
                {
                    string xlsPath = Path.Combine(OutputPath, "合并Excel.xls");
                    //排序后再合并，保持每次合并结果一致
                    NpoiMergeExcel(FileNameSort.sortFiles(xlsList), xlsPath);
                }
                string message = "合并完成\n合并DATA个数：" + txtList.Count + "\n合并Excel个数：" + xlsList.Count + "\n合并照片个数：" + jpgList.Count;
                MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NpoiMergeExcel(List<string> files, string filePath)
        {
            HSSFWorkbook Workbook1 = new HSSFWorkbook();                              
            ISheet sheet1 = Workbook1.CreateSheet("sheet1"); //添加Worksheet 
            int current = 0; //控制行索引，从零开始
            int count = 0; //文件计数
            foreach (string file in files)
            {
                FileStream fs = new FileStream(file,FileMode.Open,FileAccess.Read);
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);
                count++;
                for (int i = (count == 1)?0:1; i <= sheet.LastRowNum; i++)
                {
                    //如果不是第一个表格，表头行就不复制
                    IRow row = sheet.GetRow(i);
                    IRow newRow = sheet1.CreateRow(current);
                    if (row != null)
                    {
                        int lastColumn = row.LastCellNum;  //获取行最后一个单元格编号
                        for (int j = 0; j <= lastColumn; j++)
                        {
                            ICell cell = row.GetCell(j);
                            ICell newCell = newRow.CreateCell(j);
                            if (cell != null)
                            {
                                string cellvalue = cell.ToString();
                                newCell.SetCellValue(cellvalue);
                            }
                        }
                        
                        //2018年1月16日，增加合并后文件最后一列添加文件名，便于区分数据是哪个文件夹
                        string filename = System.IO.Path.GetFileNameWithoutExtension(file);

                        ICell fileCell = newRow.CreateCell(lastColumn + 1);  //新建单元格，存放文件名

                        if (i == 0)  // 表头单独处理
                        {
                            fileCell.SetCellValue("FILENAME");
                        }
                        else
                        {
                            fileCell.SetCellValue(filename);
                        }

                    }
                    current++;
                }
                fs.Close();
                workbook.Close();
                this.Invoke(delProgress);
            }
            //保存关闭
            FileStream newfs = new FileStream(filePath, FileMode.Create);
            Workbook1.Write(newfs);
            newfs.Close();
            Workbook1.Close();   
        }

       

        //private void MergeExcel(List<string> files, string filePath)
        //{
        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Application xlAppDest = new Excel.Application();
        //    Excel.Workbook xlWorkbookDest = xlAppDest.Workbooks.Add(misValue);//创建工作表
        //    Excel.Worksheet xlWorksheetDest = xlWorkbookDest.Worksheets[1];
        //    int current = 1;
        //    foreach (string file in files)
        //    {
        //        Excel.Application xlApp = new Excel.Application();
        //        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
        //        Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

        //        Excel.Range range = xlWorksheet.UsedRange;
        //        int colnum = range.Columns.Count;
        //        int rownum = range.Rows.Count;
        //        for (int i = 1; i <= rownum; i++)
        //        {
        //            for (int j = 1; j <= colnum; j++)
        //            {
        //                xlWorksheetDest.Cells[current, j] = xlWorksheet.Cells[i, j];
        //            }
        //            current++;
        //        }               
        //        xlApp.Application.DisplayAlerts = false;
        //        xlWorkbook.Close();
        //        xlApp.Quit();
        //        this.Invoke(delProgress);
        //    }
        //    xlWorkbookDest.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    xlWorkbookDest.Close(true, misValue, misValue);
        //    xlAppDest.Quit();

        //    System.Diagnostics.Process[] excelProgress = System.Diagnostics.Process.GetProcessesByName("EXCEL");
        //    foreach (System.Diagnostics.Process p in excelProgress)
        //    {
        //        p.Kill();
        //    }
        //}
        private void CopyJpg(List<string> files,string folder)
        {
            if (!Directory.Exists(folder)) 
                Directory.CreateDirectory(folder);            
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string newPath = Path.Combine(folder, fileName);
                File.Copy(file,newPath);
                this.Invoke(delProgress);
            }
        
        }
        private void CombineTxt(List<string> files,string filePath)
        {          
            StreamWriter writer=new StreamWriter(filePath,true,Encoding.Default);

            foreach (string file in files)
            {
                StreamReader reader = new StreamReader(file,Encoding.Default);
                writer.Write(reader.ReadToEnd());
                reader.Close();
                this.Invoke(delProgress);
            }
            writer.Close();
        }
        //全局变量，使用前记得清空
        private static List<string> fileList = new List<string>();
        //遍历目录树
        private static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }
#pragma warning disable
            catch (Exception ex)
            {

            }
#pragma wraning restore
            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    fileList.Add(fi.FullName);
                }

                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file=@"D:\GitHub\SmartCard\数据处理工具箱\数据处理工具箱\bin\Debug\jpgList.txt";
            string filePath=@"C:\Users\PSY\Desktop";
            string fileName = Path.GetFileName(file);
            MessageBox.Show(fileName);
            string newPath = Path.Combine(filePath, fileName);
            MessageBox.Show(newPath);
            File.Copy(file, newPath);
        }

        private void FormSocial_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            txtOutput.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            lblTips.Visible = false;
            //lblTips.Text = "使用说明：将包含格式为txt、jpg、xls的文件夹放入一个目录下，程序会自动将txt、xls合并为一个文件，jpg会合并在一个文件夹";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
       
    
            

