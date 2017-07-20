using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnicomTool;
using System.IO;
using System.Windows.Forms;
namespace DASH_Video_Hairpin_Tool
{
    class runPCSC
    {
        private static PCSC pcscer = new PCSC();
        public static string readICCID(int readN,string mode)
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            runPCSC.pcscer.Reader_ClosePort();
            ret = runPCSC.pcscer.Reader_OpenPort();
            if (lgRet != 0)
            {
                
                return "读卡器端口打开失败！";
            }
            else
            {
                //MessageBox.Show(strRet);
            }
            ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret !=0)
            {
                return "复位失败";
            }
            string cmd3F00="00A4000C023F00";
            string cmd2FE2="00A4000C022FE2";
            string cmd2F02="00A4000C022F02";
        
            string strCmd="";
            string strRes="";
            string strSW="";
             
            strCmd=cmd3F00;
             runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
            if (strSW !="9000")
            {
                return strCmd+"SW"+strSW;
            }
            if (mode=="2F02")
            {
                strCmd=cmd2F02;
            }
            else if (mode=="2FE2" )
            {
                 strCmd=cmd2FE2;
            }
             runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
             if (strSW !="9000")
            {
                return strCmd+"SW"+strSW;
            }
            strCmd="00B000000A";
            runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
             if (strSW !="9000")
            {
                return strCmd+"SW"+strSW;
            }
           
            return strRes;
        }

        /// <summary>
        /// 清卡程序
        /// </summary>
        /// <param name="prgPath">脚本路径</param>
        /// <param name="admb">ADMB秘钥</param>
        /// <returns></returns>
        public static string clearCard(string prgPath, string admb)
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            runPCSC.pcscer.Reader_ClosePort();
            ret = runPCSC.pcscer.Reader_OpenPort();
            if (lgRet != 0)
            {

                return "读卡器端口打开失败！";
            }
            else
            {
                //MessageBox.Show(strRet);
            }
            ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret != 0)
            {
                return "复位失败";
            }
            StreamReader reader = new StreamReader(prgPath,Encoding.Default);
            string strCmd = "";
            string strRes = "";
            string strSW = "";
            string current="";
            long line = 0;
            while ((current = reader.ReadLine()) != null)
            {
                string str = current;
                string cmd = "";
                string sw = "";
                string result = "";
                 line ++;
                runPCSC.splitCMD(str, ref cmd, ref sw, ref result);
                if (cmd == "0012000000")
                {
                    ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
                    if (ret != 0)
                    {
                        return "行号：" + line + "\n\n复位失败";
                    }                 
                    //判断result状态
                    if (result != "")
                    {
                        if (strRet != result)
                        {
                          // return "行号：" + line + "\n\nAPDU：" + cmd + "\n\nRESULT：" + strRet;
                            return "行号：" + line + "\n\nAPDU：" + cmd + "\n\n实际RESULT：" + strRes + "\n\n期望RESULT：" + result;
                        }
                    }
                }
                else
                {
                    strCmd = cmd.Replace("<ADMB>", admb);
                    strRes = "";
                    strSW = "";
                    runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
                    //判断sw状态
                    if (sw != "")
                    {
                        if (strSW != sw)
                        {
                            return "行号：" + line + "\n\nAPDU：" + strCmd + "\n\n实际SW：" + strSW + "\n\n期望SW：" + sw;
                        }
                    }
                    else if (sw == "")
                    {
                        if (strSW != "9000")
                        {
                            return "行号：" + line + "\n\nAPDU：" + strCmd + "\n\n实际SW：" + strSW + "\n\n期望SW：9000" ;
                        }
                    }
                    //判断result状态
                    if (result != "")
                    {
                        if (strRes != result)
                        {
                            return "行号：" + line + "\n\nAPDU：" + strCmd + "\n\n实际RESULT：" + strRes + "\n\n期望RESULT：" + result;
                        }
                    }
                }
                Application.DoEvents();
            }
           reader.Close();
            return "清卡成功";
        }
        public static string PrePersonalization(string prgPath)
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            runPCSC.pcscer.Reader_ClosePort();
            ret = runPCSC.pcscer.Reader_OpenPort();
            if (lgRet != 0)
            {
                return "读卡器端口打开失败！";
            }
            ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret != 0)
            {
                return "复位失败";
            }
            StreamReader reader = new StreamReader(prgPath, Encoding.Default);         
            string current = "";
            long line = 0;
            while ((current = reader.ReadLine()) != null)
            {
                string str = current;
                string cmd = "";
                string sw = "";
                string result = "";
                line++;
                runPCSC.splitCMD(str, ref cmd, ref sw, ref result);
                if (cmd == "0012000000")
                {
                    string resetResult = "";
                    resetResult= runPCSC.cardReset(result);
                    if (resetResult != "复位成功")
                    {
                        return "行号：" + line+"\n\n"+resetResult;
                    }
                }
                else
                {
                    string sendResult = "";
                    sendResult=runPCSC.sendAPDU(cmd,sw,result);
                    if (sendResult != "发送成功")
                    {
                        return "行号：" + line + "\n\n" + sendResult;
                    }
                }
                Application.DoEvents();
            }
            reader.Close();
            return "发卡成功";
        }

        //个人化开始
        public static string Personalization(string prgPath, Dictionary<string, string> dict)
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            runPCSC.pcscer.Reader_ClosePort();
            ret = runPCSC.pcscer.Reader_OpenPort();
            if (lgRet != 0)
            {

                return "读卡器端口打开失败！";
            }
            else
            {
                //MessageBox.Show(strRet);
            }
            ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret != 0)
            {
                return "复位失败";
            }
            StreamReader reader = new StreamReader(prgPath, Encoding.Default);
            string strCmd = "";
            string strRes = "";
            string strSW = "";
            string current = "";
            long line = 0;
            while ((current = reader.ReadLine()) != null)
            {
                string str = "";
                string cmd = "";
                string sw = "";
                string result = "";
                line++;
                str=runPCSC.replaceParameters(current, dict);
                runPCSC.splitCMD(str, ref cmd, ref sw, ref result);
                if (cmd == "0012000000")
                {
                    ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
                    if (ret != 0)
                    {
                        return "line:" + line + "\n复位失败";
                    }
                    //判断result状态
                    if (result != "")
                    {
                        if (strRet != result)
                        {
                            return "line:" + line + "\n" + cmd + "\n" + "实际RESULT" + strRet + "\n期望RESULT" + result;
                        }
                    }
                }
                else
                {
                    //strCmd = cmd.Replace("<ADMB>", admb);
                    strCmd = cmd;
                    strRes = "";
                    strSW = "";
                    runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
                    //判断sw状态
                    if (sw != "")
                    {
                        if (strSW != sw)
                        {
                            return "line:" + line + "\n" + strCmd + "\n" + "SW" + strSW + "\n期望SW" + sw;
                        }
                    }
                    else if (sw == "")
                    {
                        if (strSW != "9000")
                        {
                            return "line:" + line + "\n" + strCmd + "\n" + "实际SW" + strSW + "\n期望SW" + sw;
                        }
                    }
                    //判断result状态
                    if (result != "")
                    {
                        if (strRes != result)
                        {
                            return "line:" + line + "\n" + strCmd + "\n" + "实际RESULT" + strRes + "\n期望RESULT" + result;
                        }
                    }
                }
                Application.DoEvents();
            }
            reader.Close();
            return "写卡成功";
        }
        public static void splitCMD(string str,ref string cmd,ref string sw,ref string result)
        { 
            //0012000000SW9000RESULT3B17968112120F34C300
            if (str.IndexOf("SW") > -1)
            {
                int pos = str.IndexOf("SW");
                cmd = str.Substring(0,pos);             
                sw = str.Substring(pos + 2);
            }
            if (sw.IndexOf("RESULT")>-1)
            {
                int pos=sw.IndexOf("RESULT");
                
                result = sw.Substring(pos + 6);
                sw = sw.Substring(0,pos);
            }
        }
        public static string replaceParameters(string strcmd,Dictionary<string, string> dict)
        {
            int pos=0;
            int posstart = 0;          
            while ((posstart = strcmd.IndexOf("<", pos)) > -1)
            {
                int posend = strcmd.IndexOf(">", posstart);
                string parameter = strcmd.Substring(posstart, posend - posstart + 1);                
                if (dict.ContainsKey(parameter))
                {
                    strcmd = strcmd.Replace(parameter, dict[parameter]);
                }
            }

            //while ((posstart=strcmd.IndexOf("<",pos) )> -1)
            //{
            //    int posend = strcmd.IndexOf(">", posstart);
            //    string parameter = strcmd.Substring(posstart,posend-posstart+1);
            //    pos = posend;
            //    if (dict.ContainsKey(parameter))
            //    {
            //        strcmd = strcmd.Replace(parameter, dict[parameter]);
            //    }
            //}

            return strcmd;
        }
        public  static string cardReset(string result="")
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
            ret = runPCSC.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            if (ret != 0)
            {
                return "复位失败";
            }
            //判断result状态
            if (result != "")
            {
                if (strRet != result)
                {
                    return   "复位失败\n\n实际RESULT：" + strRet + "\n\n期望RESULT：" + result;
                }
            }
            return "复位成功";
        }

        public static string sendAPDU(string cmd,string sw="",string result="") 
        {
            string strCmd = cmd;
            string strRes = "";
            string strSW = "";
            runPCSC.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
            //判断sw状态           
            if (sw != "")
            {
                if (strSW != sw)
                {

                    return "APDU：" + strCmd + "\n\n实际SW：" + strSW + "\n\n期望SW：" + sw;
                }
            }
            //判断result状态
            if (result != "")
            {
                if (strRes != result)
                {
                    return "APDU：" + strCmd + "\n\n实际RESULT：" + strRes + "\n\n期望RESULT：" + result;
                }
            }
            return "发送成功";
        }
    }
}
