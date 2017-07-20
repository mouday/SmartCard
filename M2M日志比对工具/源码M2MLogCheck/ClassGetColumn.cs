using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace M2MLogCheck
{
    class ClassGetColumn
    {
        public static void GetColumn(string str)
        {

            StreamReader streamReader = new StreamReader(str, Encoding.Default);

            string path = Path.GetDirectoryName(str);

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
