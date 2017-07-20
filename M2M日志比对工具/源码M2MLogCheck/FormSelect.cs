using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;//office2010 ,版本14.0
using Microsoft.VisualBasic.Devices;

namespace M2MLogCheck
{
    public partial class FormSelect : Form
    {
        public FormSelect()
        {
            InitializeComponent();
        }
        private string cmbNumText;
           
public string CmbNumText
{
  get { return cmbNumText; }
  set { cmbNumText = value; }
}
//获取ic号
        private static string GetID(string str)
        {
            string strID = null;
            if (str != null)
            {
                string[] strs = str.Split(']');
                strID = strs[2];//数组下标为2
                strID = strID.Trim();
                strID = strID.Replace(" ", "");
                strID = strID.Replace("[", "");
                strID = strID.Replace(",", "");
            }
            return strID;
        }
        //获取写卡站号
        private static int GetNum(string str)
        {
            string strID = null;
            if (str != null)
            {
                string[] strs = str.Split(']');
                strID = strs[3];//数组下表为3
                strID = strID.Trim();
                strID = strID.Replace(" ", "");
                strID = strID.Replace("[", "");
                strID = strID.Replace(",", "");
            }
            return Convert.ToInt32(strID);
        }

        //获取写头ID
        private static int GetHeadID(string str)
        {
            string strID = null;
            if (str != null)
            {
                int point = str.IndexOf("HeadID[", 0)+7;
                int pointEnd = str.IndexOf("]", point);

                strID = str.Substring(point, pointEnd - point);
                
            }
            return Convert.ToInt32(strID);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(textBox1.Text, Encoding.Default);
                string prePath = cmbNum.SelectedItem.ToString();
                
                //MessageBox.Show(prePath);
                string path = Path.GetDirectoryName(textBox1.Text);
                cmbNumText = path;
                //MessageBox.Show(path);
                StreamWriter writerOk = new StreamWriter(path +  @"\写卡成功.txt", false, Encoding.Default);
                StreamWriter writerOther = new StreamWriter(path + @"\失败日志.txt", false, Encoding.Default);
                StreamWriter writerBK = new StreamWriter(path + @"\补卡.txt", false, Encoding.Default);
                StreamWriter writerCheckFailed = new StreamWriter(path + @"\校验失败.txt", false, Encoding.Default);
                
                    
                List<string> listTemp = new List<string>();//临时存储写卡成功的日志
                List<string> listElse = new List<string>();//其他
                List<string> listOther = new List<string>();//其他类别
                List<string> listResetFail = new List<string>();//Error: 0012000000 fail[107]   和  Error: Reset Info []     
                List<string> listCheckFail = new List<string>();//写卡成功，校验失败
                List<string> listAPDU = new List<string>();//APDU
                List<string> listMoreTime = new List<string>();//APDU超时
                List<string> listResetError = new List<string>();//Error: Reset Info [
                List<string> listWriterClose = new List<string>();//写卡板断开

                Dictionary<int, string> dictionary = new Dictionary<int, string>();

                string current = null;
                long currentLine = 0;
                long currentOk = 0;
                long currentOther = 0;
                long currentelse = 0;
                long BKcount = 0;
                int count = 0;
                string ICCIDBeging = null;
                string ICCIDEnd = null;

                while ((current = reader.ReadLine()) != null)
                {

                    currentLine++;
                    if (current.IndexOf("写卡成功", 0) > -1)
                    {
                        if (current.IndexOf("写卡成功，校验失败", 0) > -1)
                        {
                            //写卡成功，校验失败
                            currentOther++;
                            listCheckFail.Add(current);
                            int headID = GetHeadID(current);
                            writerCheckFailed.WriteLine(GetID(dictionary[headID]));

                        }
                        else
                        {
                            currentOk++;//写卡成功计数；
                            /*  —————   起始号和结尾号赋值   ————     */
                            if (currentOk == 1)
                            { 
                                ICCIDBeging =GetID(current);
                                ICCIDEnd = GetID(current);
                            }
                            if (string.Compare(GetID(current),ICCIDBeging)<0 )
                            {
                                ICCIDBeging = GetID(current);
                            }
                            else if (string.Compare(GetID(current), ICCIDEnd) > 0)
                            {
                                ICCIDEnd = GetID(current);
                            }
                            /*   ————  起始号和结尾号   ————   */
                            writerOk.WriteLine(current);
                            if (current.IndexOf("BK", 0) > -1)
                            {
                                BKcount++;
                                writerBK.WriteLine(GetID(current));
                            }
                            if (dictionary.Keys.Contains(GetNum(current)))
                            {
                                dictionary.Remove(GetNum(current));
                                dictionary.Add(GetNum(current), current);

                            }
                            else
                            {

                                dictionary.Add(GetNum(current), current);

                            }


                        }
                        
                    }
                    //错误日志分类输出：
                    else if (current.IndexOf("初始化成功", 0) == -1)
                    {
                        currentOther++;
                        //复位失败
                        if (current.IndexOf("Error: 0012000000 fail[107]", 0) > -1 ||
                            current.IndexOf("Error: Reset Info []", 0) > -1
                            )
                        {
                            listResetFail.Add(current);
                        }
                        //写卡成功，校验失败
                        //else if (current.IndexOf("写卡成功，校验失败", 0) > -1)
                        //{
                        //listCheckFail.Add(current);
                        //}
                        //APDU
                        else if (current.IndexOf("APDU", 0) > -1 && current.IndexOf("]:-", 0) == -1)
                        {
                            listAPDU.Add(current);
                        }
                        //超时
                        else if (current.IndexOf("APDU", 0) > -1 && current.IndexOf("]:-", 0) > -1)
                        {
                            listMoreTime.Add(current);
                        }
                        //复位异常
                        else if (current.IndexOf("Error: Reset Info [", 0) > -1)
                        {
                            listResetError.Add(current);
                        }
                        //写卡板断开
                        else if (current.IndexOf("Recv result from crw", 0) > -1)                        
                        {
                            listWriterClose.Add(current);
                        }                          
                        //其他错误
                        else
                        {
                            listOther.Add(current);
                        }
                        // writerOther.WriteLine(current);
                    }
                    //未分类
                    else
                    {
                        currentelse++;
                        listElse.Add(current);
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                listOther.Sort();
                listResetFail.Sort();
                listCheckFail.Sort();
                listAPDU.Sort();
                listMoreTime.Sort();
                listResetError.Sort();
                //输出错误日志
                writerOther.WriteLine("********************错数误日志分类************************");
                writerOther.WriteLine("错误日志总条数：\t" + currentOther +
                                       "\r\n复位失败：\t\t" + listResetFail.Count +
                                       "\r\n复位值不符：\t\t" + listResetError.Count +
                                       "\r\n写卡成功，校验失败：\t" + listCheckFail.Count +
                                       "\r\nAPDU：\t\t\t" + listAPDU.Count +
                                       "\r\n写卡超时：\t\t" + listMoreTime.Count +
                                       "\r\n写卡板断开：\t\t" + listWriterClose.Count +
                                       "\r\n其他错误：\t\t" + listOther.Count +
                                       "\r\n未分类：\t\t" + listElse.Count
                                        );


                //复位失败
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************复位失败：\t {0}************************", listResetFail.Count);
                foreach (string str in listResetFail)
                {
                    writerOther.WriteLine(str);
                }

                //复位值不符
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************复位值不符：\t {0}************************", listResetError.Count);
                foreach (string str in listResetError)
                {
                    writerOther.WriteLine(str);
                }

                //写卡成功，校验失败
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************写卡成功，校验失败：\t {0}************************", listCheckFail.Count);
                foreach (string str in listCheckFail)
                {
                    writerOther.WriteLine(str);
                }

                //APDU
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************APDU：\t {0}************************", listAPDU.Count);
                foreach (string str in listAPDU)
                {
                    writerOther.WriteLine(str);
                }

                //写卡超时
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************写卡超时：\t {0}************************", listMoreTime.Count);
                foreach (string str in listMoreTime)
                {
                    writerOther.WriteLine(str);
                }

                //写卡板断开
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************写卡板断开：\t {0}************************", listWriterClose.Count);
                foreach (string str in listWriterClose)
                {
                    writerOther.WriteLine(str);
                }


                //其他错误
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************其他错误：\t {0}************************", listOther.Count);
                foreach (string str in listOther)
                {
                    writerOther.WriteLine(str);
                }

                //未分类
                writerOther.WriteLine();
                writerOther.WriteLine();
                writerOther.WriteLine("********************未分类：\t {0}************************", listElse.Count);
                foreach (string str in listElse)
                {
                    writerOther.WriteLine(str);
                }

                reader.Close();
                writerOk.Close();
                writerBK.Close();
                writerOther.Close();
                writerCheckFailed.Close();
                //重命名
                Computer my = new Computer();
                string oldFilename = path + @"\写卡成功.txt";
                string newFilename = prePath + "写卡成功（" + currentOk + "）.txt";
                my.FileSystem.RenameFile(oldFilename, newFilename);

                string BKoldFilename = path + @"\补卡.txt";
                string BKnewFilename = prePath + "补卡卡号（" + BKcount + "）.txt";
                my.FileSystem.RenameFile(BKoldFilename, BKnewFilename);

                string CheckFaildeoldFilename = path + @"\校验失败.txt";
                string CheckFaildenewFilename = prePath + "校验失败卡号（" + listCheckFail.Count + "）.txt";
                my.FileSystem.RenameFile(CheckFaildeoldFilename, CheckFaildenewFilename);

                string FailoldFilename = path + @"\失败日志.txt";
                string FaildnewFilename = prePath + "失败日志（" + currentOther + "）.txt";
                my.FileSystem.RenameFile(FailoldFilename, FaildnewFilename);

                //string RangeoldFilename = path + @"\比对号段.txt";
                //string RangenewFilename = "比对号段: " + ICCIDBeging+"-" + ICCIDEnd + ".txt";
                //my.FileSystem.RenameFile(RangeoldFilename, RangenewFilename);
                
                //输出比对好对号段
                if (checkBoxRange.Checked == true)
                {
                    StreamWriter writerRange = new StreamWriter(path +@"\"+ prePath + @"比对号段：" + ICCIDBeging + " - " + ICCIDEnd + ".txt", false, Encoding.Default);
                    writerRange.Close();
                }

                //检查“写卡成功”重复
                if (checkBoxRepeat.Checked == true)
                {
                    ClassMatch.GetRepeat(path + @"\"+prePath + @"写卡成功（" + currentOk + "）.txt", ICCIDBeging, ICCIDEnd,prePath);
                    //File.Delete(repeatPath);
                }
                /**********************************输入到Excel表格中Beging***************************************/
                string Current;
                Current = System.Windows.Forms.Application.ExecutablePath;//Environment.CurrentDirectory;//获得应用程序的当前路径
                //Current = Directory.GetCurrentDirectory();//获取当前根目录
                string filename = Path.GetDirectoryName(Current) + @"\M2M报错日志分类.xlsx";
                //启动Excel应用程序
                Microsoft.Office.Interop.Excel.Application xls =
                    new Microsoft.Office.Interop.Excel.Application();

                _Workbook book;//定义book变量

                if (File.Exists(filename))
                {
                    //如果表已经存在，可以用下面的命令打开
                    book = xls.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                }
                else
                {
                    //创建一张表，一张表可以包含多个sheet
                    //book = xls.Workbooks.Add(Missing.Value);
                    MessageBox.Show("Excel模板不存在！" + filename);
                    return;
                }

                _Worksheet sheet;//定义sheet变量
                xls.Visible = false;//设置Excel后台运行
                xls.DisplayAlerts = false;//设置不显示确认修改提示

                //for (int i =1; i < 11; i++)//循环创建并写入数据到sheet
                {
                    //int i = 1;
                    try
                    {
                        sheet = (_Worksheet)book.Worksheets.get_Item(1);//获得第1个sheet，准备写入
                    }
                    catch (Exception ex)//不存在就增加一个sheet
                    {
                        sheet = (_Worksheet)book.Worksheets.Add(Missing.Value, book.Worksheets[book.Sheets.Count], 1, Missing.Value);
                    }
                    //sheet.Name = "第" + i.ToString() + "页";//设置当前sheet的Name
                    /*for (int row = 1; row < 20; row++)//循环设置每个单元格的值
                    {
                        for (int offset = 1; offset < 10; offset++)
                            sheet.Cells[row, offset] = "( " + row.ToString() + "," + offset.ToString() + " )";
                    }
                     */
                    /*错误日志总条数：currentOther +
                      复位失败：listResetFail.Count +
                      复位值不符：  listResetError.Count +
                      写卡成功，校验失败 listCheckFail.Count +
                      APDU： listAPDU.Count +
                      写卡超时：listMoreTime.Count +
                      其他错误：listOther.Count+
                      未分类： listElse.Count
                     * */
                    //复位值不符
                    sheet.Cells[2, 2] = listResetError.Count;
                    //复位失败
                    sheet.Cells[2, 3] = listResetFail.Count;
                    //写入不完整
                    sheet.Cells[2, 4] = 0;
                    //APDU 指令返回状态字与期望值不符
                    sheet.Cells[2, 5] = listAPDU.Count;
                    //AOOO文件判断不一致
                    sheet.Cells[2, 6] = 0;
                    //超时
                    sheet.Cells[2, 7] = listMoreTime.Count;
                    //写卡板断开
                    sheet.Cells[2, 8] = listWriterClose.Count;
                    //写入成功校验失败
                    sheet.Cells[2, 9] = listCheckFail.Count;
                    //其他
                    sheet.Cells[2, 10] = listOther.Count;
                }

                for (int i = 2; i < 11; i++)//循环创建并写入数据到sheet
                {
                    //int i = 1;
                    try
                    {
                        sheet = (_Worksheet)book.Worksheets.get_Item(i);//获得第1个sheet，准备写入
                    }
                    catch (Exception ex)//不存在就增加一个sheet
                    {
                        sheet = (_Worksheet)book.Worksheets.Add(Missing.Value, book.Worksheets[book.Sheets.Count], 1, Missing.Value);
                    }
                    //sheet.Name = "第" + i.ToString() + "页";//设置当前sheet的Name

                    /*错误日志总条数：currentOther +
                
                    2-复位值不符：  listResetError.Count +
                    3-复位失败：listResetFail.Count +
                    4-写入不完整               
                    5-APDU： listAPDU.Count +
                    6-A000不一致               
                    7-写卡超时：listMoreTime.Count +
                    8-写卡板断开listWriterClose.Count +
                    9-写卡成功，校验失败 listCheckFail.Count +
                    10-其他错误：listOther.Count+
                    未分类： listElse.Count
                     */
                    List<string> list;
                    switch (i)
                    {
                        case 2:
                            list = new List<string>(listResetError);
                            break;
                        case 3:
                            list = new List<string>(listResetFail);
                            break;
                        case 4:
                            list = new List<string>();
                            break;
                        case 5:
                            list = new List<string>(listAPDU);
                            break;
                        case 6:
                            list = new List<string>();
                            break;
                        case 7:
                            list = new List<string>(listMoreTime);
                            break;
                        case 8:
                            list = new List<string>(listWriterClose);
                            break;
                        case 9:
                            list = new List<string>(listCheckFail);
                            break;
                        case 10:
                            list = new List<string>(listOther);
                            break;

                        default:
                            list = new List<string>();
                            break;
                    }
                    long j = 0;
                    foreach (string str in list)//循环设置每个单元格的值
                    {
                        j++;
                        sheet.Cells[j, 1] = str;
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                /* if (File.Exists(filename))
                 {
                     //如果表已经存在，直接用下面的命令保存即可
                     book.Save();
                 }
                 else
                 {
                     //将表另存为
                     book.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                 }
                 */
                //另存为
                try
                {
                    book.SaveCopyAs(path + @"\"+prePath+@"报错日志分类.xlsx");
                }
                catch
                {
                    MessageBox.Show("报错日志分类保存失败！");
                }


                book.Close(false, Missing.Value, Missing.Value);//关闭打开的表
                xls.Quit();//Excel程序退出
                //sheet,book,xls设置为null，防止内存泄露
                sheet = null;
                book = null;
                xls = null;
                GC.Collect();//系统回收资源
                //return true;


                /**********************************输入到Excel表格中End***************************************/

                string message = "原文件行数： \t" + currentLine +
                                "\r\n写卡成功行数： \t" + currentOk +
                                "\r\n失败日志行数： \t" + currentOther +
                                "\r\n其他行数： \t" + currentelse;
                label2.Text = message;
                MessageBox.Show("查找完成！\r\n" + message);
            }
            catch 
            {
                MessageBox.Show("出错啦！请检查");
            }
        }

        private void FormSelect_Load(object sender, EventArgs e)
        {
            textBox2.Text = "写卡成功";
            label2.Text = "";
            
            //初始化组合框，附加到生成的文件名前缀
            string[] cmbItems = new string[] { "M2M", "M2M-1", "M2M-2", "M2M-3", "M2M-4" };
            foreach (string str in cmbItems)
            {
                cmbNum.Items.Add(str);
            }
            cmbNum.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cmbNum.SelectedItem.ToString());
        }
    }
}
