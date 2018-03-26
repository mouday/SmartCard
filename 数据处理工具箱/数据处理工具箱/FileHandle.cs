using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SocialDataMerge
{
    class FileHandle
    {
        private string folderPath;//文件路径

        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        public FileHandle(string folder)
        {
            folderPath = folder;
        }
        /// <summary>
        /// 获取文件目录下，指定扩展名的文件列表
        /// </summary>
        /// <param name="filter">文件扩展名，筛选器</param>
        /// <returns>指定扩展名文件列表</returns>
        public  List<string> GetFileList(string filter)
        {
            List<string> list = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            foreach (FileInfo file in folder.GetFiles(filter))
            {
                list.Add(file.FullName);
            }
            return list;
        }

    }
}