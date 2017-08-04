using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataHandle
{
    class mca
    {
        public static List<string> GetFileList(string folderPath)
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
        public static int GetFileLinesCount(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string[] lines = reader.ReadToEnd().Split('\n');
            reader.Close();
            return lines.Length;
        }
        public static void CombineMCA(List<string> fileNames,string outPath)
        {
            int count = 0;
            StreamWriter writer = new StreamWriter(outPath, true, Encoding.Default);
            foreach (string fileName in fileNames)
            {
                count++;
                StreamReader reader = new StreamReader(fileName, Encoding.Default);               
                string current = null;
                current = reader.ReadLine();
                if (count == 1)
                {                  
                    writer.WriteLine(current);
                }
                current = reader.ReadToEnd();
                writer.Write(current);
                reader.Close();               
            }
            writer.Close();
        }
        

    }
}
