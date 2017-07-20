using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace M2MLogCheck
{
    class ClassMatch
    {
        public static  string GetRepeat(string str)
        {

            StreamReader streamReader = new StreamReader(str, Encoding.Default);

            string path = Path.GetDirectoryName(str);

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
            //重命名
            Computer my = new Computer();
            string oldFilename = path + @"\重复项.txt";
            string newFilename = "重复项（" + repeatCounts.Count + "）.txt";
            my.FileSystem.RenameFile(oldFilename, newFilename);
            return path + @"\" + newFilename;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startICCID"></param>
        /// <param name="endICCID"></param>
        /// <param name="prePath">文件名前缀</param>
        public static void GetRepeat(string str, string startICCID, string endICCID, string prePath)
        {

            StreamReader streamReader = new StreamReader(str, Encoding.Default);

            string path = Path.GetDirectoryName(str);

            StreamWriter repeatWriter = new StreamWriter(path + @"\重复项.txt", false, Encoding.Default);
            StreamWriter lackWriter = new StreamWriter(path + @"\缺失项.txt", false, Encoding.Default);

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
                System.Windows.Forms.Application.DoEvents();
            }
            
            streamReader.Close();
            //验证日志文件中缺失号段：
            string fixStr = startICCID.Substring(0, startICCID.Length-10);
            long IDBeging = long.Parse(startICCID.Substring(startICCID.Length - 10, 10));
            long IDEnd = long.Parse(endICCID.Substring(endICCID.Length- 10, 10));
            //lackWriter.WriteLine("{0}  {1}  {2}", fixStr, IDBeging, startICCID);        
            long IDCount = 0;
            for (long i = IDBeging; i <= IDEnd; i++)
            {
                IDCount++;
                if (hash.Add(fixStr+i.ToString()))
                {
                    Lacks.Add(fixStr+i.ToString());
                }
                else
                {
                    //ok;
                }
                System.Windows.Forms.Application.DoEvents();
            }

            //计算重复和缺失的数目
            List<Item> repeatCounts = new List<Item>();
            repeatCounts = ClassJYT.GetCount(Repeats);

            repeatWriter.WriteLine("*******************日志重复项***********************");
            foreach (Item item in repeatCounts)
            {
                repeatWriter.WriteLine("卡号：{0}     出现次数：{1}", item.Field, item.Count);
            }
            repeatWriter.WriteLine();
            

            lackWriter.WriteLine("*******************日志缺失项***********************");
            foreach (string s in Lacks)
            {
                lackWriter.WriteLine("卡号：{0}", s);
            }
           

            //结果输出
            string outMessage =
                                         "\r\n日志文件条数：\t" + logCount +

                                        "\r\n重复日志条数：\t" + repeatCounts.Count;

            string lackMessage =
                                         "\r\n日志文件条数：\t" + logCount +
                                         "\r\n比对条数：\t" + IDCount +
                                         "\r\n比对范围：\t" + fixStr + IDBeging + " - " +
                                                              fixStr + IDEnd+
                                        "\r\n缺失日志条数：\t" + Lacks.Count;
            repeatWriter.Write(outMessage);

            
            lackWriter.WriteLine();
            lackWriter.WriteLine();
            lackWriter.Write(lackMessage);

            repeatWriter.Close();
            lackWriter.Close();
            //重命名
            //FormSelect fm =new FormSelect();
            //string prePath=fm.CmbNumText;
            Computer my = new Computer();
            string oldFilename = path + @"\重复项.txt";
            string newFilename = prePath+"重复项（" + repeatCounts.Count + "）.txt";
            my.FileSystem.RenameFile(oldFilename, newFilename);

            string lackoldFilename = path + @"\缺失项.txt";
            string lacknewFilename =prePath+ "缺失项（" + Lacks.Count + "）.txt";
            my.FileSystem.RenameFile(lackoldFilename, lacknewFilename);
           


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
    }
}
