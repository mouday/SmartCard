using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DASH_Video_Hairpin_Tool
{
    class MCAhandler
    {
        public static Dictionary<string,string > getAMDB(string mcaPath)
        {
            Dictionary<string, string> dit = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(mcaPath,Encoding.Default);
            string current = "";
            current=reader.ReadLine();
            string[] titles = current.Split(',');
            int indexICCID = -1;
            int indexADMB = -1;
            for (int i = 0; i < titles.Length; i++)
            {
                if (titles[i] == "ICCID")
                {
                    indexICCID = i;
                }
                if (titles[i] == "ADMB")
                {
                    indexADMB = i;
                } 
            }
            if (indexICCID > -1 & indexADMB > -1)
            {
                while ((current = reader.ReadLine()) != null)
                {
                    string[] strs = current.Split(',');
                    dit.Add(strs[indexICCID], strs[indexADMB]);
                }
            }
            else
            { 
                
            }
            reader.Close();
            return dit;
           
        }
        public static List<string[]> getMca(string mcaPath)
        {
            List<string[]> list = new List<string[]>();
            StreamReader reader = new StreamReader(mcaPath, Encoding.Default);
            string current = "";
                                 
                while ((current = reader.ReadLine()) != null)
                {
                    string[] strs = current.Split(',');
                    list.Add(strs);
                }
           reader.Close();
            return list;
           
        }
    }
}
