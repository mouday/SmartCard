using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrgTxtTransform
{
    class PrgToTxt
    {
        private const string reset="0012000000SW9000";
        public static void GetPrgLine(string sLine, ref string text)
        {
            int SWLocal = 0;
            int RESULTLocal = 0;
            string send = null;
            string assert = null;
            string result = null;
            string stateWord = null;

            //拆分sw前后
            if (sLine.IndexOf("SW", 0) > -1)
            {
                SWLocal = sLine.IndexOf("SW", 0);
                send = sLine.Substring(0, SWLocal);
                send = "SEND " + send;
                assert = sLine.Substring(SWLocal + 2);
            }

            if (assert.IndexOf("OUTPUT", 0) > -1)
            {
                int output = assert.IndexOf("OUTPUT", 0);
                assert = assert.Substring(0,output);
            }
            //assert保存了sw之后的内容
            if (assert.IndexOf("RESULT", 0) > -1)
            {
                RESULTLocal = assert.IndexOf("RESULT", 0);
                stateWord = assert.Substring(0, RESULTLocal);
                result = assert.Substring(RESULTLocal + 6);
            }
            else
            {
                stateWord = assert;
            }

            if (send == "SEND 0012000000")
            {
                send = "RESET";
                if (result != null)
                {
                    stateWord = "";
                }
               
            }
            
            text = send + "\r\n" + "ASSERT " + result + stateWord;
            text = text.Replace("<", " $");
            text = text.Replace(">", "$ ");
            //text = text.Replace("OUTPUT00000020", "");//去除不兼容指令
            text = text.Replace("RESET\r\nASSERT 9000", "RESET");//修复：去除复位后面的9000，RESET\r\nASSERT 9000
            
        }
        public static void GetMcaField(string sLine)
        { 
            
        }

        public static string[] GetMcaVariables(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);

            //string current = null;

            string[] firstLines = reader.ReadLine().Split(',');
            for (int i = 0; i < firstLines.Length; i++)
            {
                firstLines[i] = "<" + firstLines[i] + ">";
            }
            reader.Close();
            return firstLines;
        }
        //获取整个prg脚本的变量
        public static string[] GetPrgVariables(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            HashSet<string> hashSet = new HashSet<string>();
            string current = null;
            while ((current = reader.ReadLine()) != null)
            {
                List<string> list = GetCmdVariables(current);
                foreach (string s in list)
                {
                    hashSet.Add(s);
                }

            }
            reader.Close();
            return hashSet.ToArray();
        }

        //获取单条指令的参数
        public static List<string> GetCmdVariables(string strcmd)
        {
            List<string> list = new List<string>();
            int pos = 0;
            int posStart = 0;
            while ((posStart = strcmd.IndexOf("<", pos)) > -1)
            {
                int posEnd = strcmd.IndexOf(">", posStart);
                string parameter = strcmd.Substring(posStart, posEnd - posStart + 1);
                list.Add(parameter);
                strcmd = strcmd.Replace(parameter, "");

            }
            return list;
        }
        public static void CheckMca(string path,ref int firstLength,ref int secondLength)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            string[] firstLines = reader.ReadLine().Split(',');
            string[] secondLines = reader.ReadLine().Split(',');
            reader.Close();
            firstLength=firstLines.Length ;
            secondLength = secondLines.Length;
            
        }
        public static string ReplaceLabel(string strcmd)
        {
            int pos = 0;
            int posStart = 0;
            while ((posStart = strcmd.IndexOf("$", pos)) > -1)
            {
                int posEnd = strcmd.IndexOf("$", posStart+1);
                string parameter = strcmd.Substring(posStart, posEnd - posStart + 1);
                string s=parameter.Substring(1,parameter.Length-2);
                string str = "<" + s + ">";
                strcmd = strcmd.Replace(parameter, str);

            }
            return strcmd;
            
        }
        public static string Swap(string str)
        {
            StringBuilder builder =new StringBuilder();
            if (str.Length % 2 != 0) return builder.ToString();
            for (int i = 0; i < str.Length / 2; i++)
            {               
                builder.Append(str[2 * i + 1]);
                builder.Append(str[2 * i]);
            }
            return builder.ToString();
        }
    }
}
