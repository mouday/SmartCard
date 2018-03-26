using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace SocialDataMerge
{
    //mca文件：
    //格式如下：(表头加内容)
    //ICCID,IMSI,打印数据1,打印数据2
    //89860...,12345...,89860,78890
    //...
    class Mca
    {
        private DataTable dt;
        public Mca()
        {


        }
        public Mca(string path)
        {

        }
        public static List<string> GetMcaList(string folderPath)
        {
            List<string> list = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            foreach (FileInfo file in folder.GetFiles("*.mca"))
            {
                list.Add(file.FullName);
            }
            return list;
        }
        public static string GetFileName(string fileFullName)
        {
            int pos = fileFullName.LastIndexOf(@"\");
            string fileName = fileFullName.Substring(pos + 1, fileFullName.Length - (pos + 1));
            return fileName;
        }
        public static int GetFileLineCount(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string[] lines = reader.ReadToEnd().Split('\n');
            reader.Close();
            return lines.Length;
        }

        public static int CombineMCA(List<string> fileNames, string outPath)
        {
            int count = 0;
            int lines = 0;
            StreamWriter writer = new StreamWriter(outPath, true, Encoding.Default);
            foreach (string fileName in fileNames)
            {
                count++;
                StreamReader reader = new StreamReader(fileName, Encoding.Default);
                string current = null;
                current = reader.ReadLine();//读取首行
                if (count == 1)
                {
                    writer.WriteLine(current);//输出首行
                }
                current = reader.ReadToEnd();
                writer.Write(current);
                reader.Close();

                int line = GetFileLineCount(fileName) - 2;
                lines += line;

            }
            writer.Close();
            //重命名
            string saveFileName =Path.Combine( Path.GetDirectoryName(outPath),Path.GetFileNameWithoutExtension(outPath) + "_" + lines + Path.GetExtension(outPath));
            FileInfo fileInfo = new FileInfo(outPath);
            //MessageBox.Show(saveFileName);
            fileInfo.MoveTo(saveFileName);
            //返回
            return lines;
        }
        /// <summary>
        /// 合并mca，校验每行长度
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="outPath"></param>
        /// <returns></returns>
        public static int CombineMCAByCheck(List<string> fileNames, string outFile)
        {
            int count = 0;//统计文件数量
            int lines = 0;//统计行数量
            int firstLenght = 0;//第一行的长度
            string title = null;//表头参数
            bool isTitleError = false;//表头错误
            string errorTitle = "";//出错文件名
            bool isLineError = false;//行错误

            //合并前删除缓存
            if (File.Exists(outFile)) File.Delete(outFile);

            StreamWriter writer = new StreamWriter(outFile, true, Encoding.Default);
            foreach (string fileName in fileNames)
            {
                count++;
                StreamReader reader = new StreamReader(fileName, Encoding.Default);
                string current = null;
                current = reader.ReadLine();//表头
                if (count == 1)
                {
                    writer.WriteLine(current);//输出第一个表头
                    title = current;
                }
                else
                {
                    if (current != title)//校验表头
                    {
                        isTitleError = true;
                        errorTitle = Mca.GetFileName(fileName);
                        break;
                    }
                }
                //内容
                while ((current = reader.ReadLine()) != null)
                {
                    lines++;
                    if (lines == 1)
                    {
                        firstLenght = current.Length;
                    }
                    else
                    {
                        if (current.Length != firstLenght)//校验行
                        {
                            isLineError = true;
                            errorTitle = Mca.GetFileName(fileName);
                            break;
                        }
                    }
                    writer.WriteLine(current);
                }
                if (isLineError == true) break;
                reader.Close();
            }
            writer.Close();

            if (isTitleError == true)
            {
                System.Windows.Forms.MessageBox.Show("表头不一致" + errorTitle, "错误提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                lines = -1;
            }
            if (isLineError == true)
            {
                System.Windows.Forms.MessageBox.Show("行长度不一致" + errorTitle, "错误提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                lines = -1;
            }
            return lines;//返回总行数
        }
        public static int checkMca(List<string> fileNames)
        {
            int count = 0;//统计文件数量
            int lines = 0;//统计行数量
            int firstLenght = 0;//第一行的长度
            string title = null;//表头参数
            bool isTitleError = false;//表头错误
            string errorInfo = "";//出错文件名
            bool isLineError = false;//行错误
            //=====遍历传入的列表=====
            foreach (string fileName in fileNames)
            {
                count++;
                using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
                {
                    string current = null;
                    current = reader.ReadLine();
                    //检查表头
                    if (count == 1)
                    {
                        title = current;//保存表头
                    }
                    else
                    {
                        if (current != title)//校验表头
                        {
                            isTitleError = true;
                            errorInfo = "表头错误\n" + Mca.GetFileName(fileName);
                            lines = -1;
                            break;
                        }
                    }
                    //检查内容
                    while ((current = reader.ReadLine()) != null)
                    {
                        lines++;
                        if (lines == 1)
                        {
                            firstLenght = current.Length;//保存内容中第一行长度
                        }
                        else
                        {
                            if (current.Length != firstLenght)//校验行
                            {
                                isLineError = true;
                                errorInfo = "行数量错误\n" + Mca.GetFileName(fileName);
                                lines = -1;
                                break;
                            }
                        }
                    }
                }
            }
            if (isTitleError == true || isLineError == true)
            {
                MessageBox.Show(errorInfo, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lines;//返回总行数
        }
    }
}
