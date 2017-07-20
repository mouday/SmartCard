using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

namespace UnicomTool
{
    public class WibAlgrithm
    {
        //public static extern int PCSC_Connect(int NofReaders);
        //函数调用有问题，无法使用
        public static string GetADMB(string iccid)
        {
            string str1 = "";//"700B107109197410";//8456CCAD7CBC13E3
            if (iccid.Substring(0, 4) == "8986")
            {
                iccid = Swap(iccid);
            }
            if (iccid.Length != 16)
            {
                str1 = iccid.Substring(iccid.Length-16,16);
            }
            //return str1;
            byte[] bytes=new byte[60];
            long lng = PCSC.GetSupperAdmin(str1, bytes);
            string admb = Encoding.Default.GetString(bytes);
            //foreach (byte b in bytes)
            //{
            //    str2 += b;
            //}
            return admb;
        }
        public static string Swap(string str)
        {
            StringBuilder builder = new StringBuilder();
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
