using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace DataHandle
{
    public partial class FormFindCard : Form
    {
        public FormFindCard()
        {
            InitializeComponent();
        }

        private void btnSourceData_Click(object sender, EventArgs e)
        {
            //选择单个文件
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MCA数据|*.mca|所有数据|*.*";
            //openFileDialog.FilterIndex = 1;
            //openFileDialog.FileName = "";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    txtSourceData.Text = openFileDialog.FileName;
            //}
            //选择一个文件夹
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "选择原始数据文件夹";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtSourceData.Text = folder.SelectedPath;
            }
        }

        private void btnFindData_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "文本文档|*.txt|MCA数据|*.mca|所有数据|*.*";
            //openFileDialog.FilterIndex = 1;
            //openFileDialog.FileName = "";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    txtFindData.Text = openFileDialog.FileName;
            //}

            //选择一个文件夹
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "选择补卡卡号文件夹";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtFindData.Text = folder.SelectedPath;
            }
        }
        struct myPath
        {
            public string pathone;
            public string pathtwo;
        }
        //定义一个全局变量，判断是否完全结束
        int Threadcount = 0;
        int Threadcounts = 0;
        string combineMcaPath = "";//全局变量保存临时合并mca的路径，所有线程执行完毕之后删除。
        private void btnCereate_Click(object sender, EventArgs e)
        {
            if (txtFindData.Text == "") return;
            if (txtSourceData.Text == "") return;
                   
            //保存路径
            //string combineMca = "Combine" + Path.GetFileNameWithoutExtension(txtSourceData.Text) + ".tmp";
            //string filePath = Path.GetDirectoryName(txtSourceData.Text);
            combineMcaPath = Path.Combine(txtSourceData.Text, "Combine.tmp");
            //获取mca文件列表
            List<string> sourceFiles = Mca.GetMcaList(txtSourceData.Text);
            Mca.CombineMCA(sourceFiles, combineMcaPath);

            //获取补卡卡号文件列表
            FileHandle fileHandle = new FileHandle(txtFindData.Text);
            List<string> findFiles=fileHandle.GetFileList("*.*");
            Threadcounts = findFiles.Count;//补卡文件总和
            //同时开启多线程工作
            foreach (string files in findFiles)
            {
                myPath mypath = new myPath();
                mypath.pathone = combineMcaPath;//txtSourceData.Text;
                mypath.pathtwo = files;//txtFindData.Text;

                Thread t = new Thread(FindDataAll);
                t.Start(mypath);
            }
            //string path=TrimMca(txtFindData.Text);
            //MessageBox.Show(path);
        }
       
        /// <summary>
        /// 生成补卡数据：方案1-1，先打开补卡卡号，逐个去查找
        /// </summary>
        /// <param name="mypath">原始数据路径,补卡卡号路径</param>
        private void FindData(object mypath)
        {
            myPath objmypath = (myPath)mypath;
            string sourcePath = objmypath.pathone;
            string findSource = objmypath.pathtwo;
            StreamReader reader = new StreamReader(findSource, Encoding.Default);
            string sourceName = Path.GetFileName(findSource);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outFile = Path.Combine(desktop, "BK_" + sourceName);
            StreamWriter writer = new StreamWriter(outFile, false, Encoding.Default);
            string key = null;
            string value = "";
            int failCount = 0;
            int successCount = 0;
            while ((key = reader.ReadLine()) != null)
            {
                value = findLine(sourcePath, key);
                if (value != null)
                {
                    writer.WriteLine(value);
                    successCount++;
                }
                else
                {
                    failCount++;
                }
            }
            writer.Close();
            reader.Close();
            MessageBox.Show("补卡数据生成完成！\n成功：" + successCount + "\n失败：" + failCount);
        }
        /// <summary>
        /// 查找单条补卡数据：方案1-2，通过补卡卡号查找单条数据
        /// </summary>
        /// <param name="path">原始数据路径</param>
        /// <param name="key">补卡卡号</param>
        /// <returns>返回查找到的字符串</returns>
        private string findLine(string path, string key)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            string current = null;
            while ((current = reader.ReadLine()) != null)
            {
                int pos = current.IndexOf(key);
                if (pos > -1)
                    break;
            }
            reader.Close();
            reader.Dispose();
            return current;
        }
        /// <summary>
        /// 通过输入原始文件和补卡卡号输出补卡数据：方案二
        /// </summary>
        /// <param name="mypath">原始数据路径,补卡卡号路径</param>
        private void FindDataAll(object mypath)
        {
            //解析路径
            myPath objmypath = (myPath)mypath;
            string sourcePath = objmypath.pathone;
            string findPath = objmypath.pathtwo;
            //判断文件是否存在
            if (!File.Exists(sourcePath)) return;
            if (!File.Exists(findPath)) return;
            //读取补卡文件
            string sortPath = SortMca(findPath);//排序，从小到大
            string trimPath = TrimMca(sortPath);//去重，去空白行
            StreamReader readerFind = new StreamReader(trimPath, Encoding.Default);
            //读取原始文件
            StreamReader readerSource = new StreamReader(sourcePath, Encoding.Default);
            //保存补卡数据
            string findName = Path.GetFileNameWithoutExtension(findPath);
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string saveDir = Path.GetDirectoryName(findPath);
            string outFile = Path.Combine(saveDir, "BK_" + findName + ".mca");
            StreamWriter writer = null;
            try
            {
                //定义必要的变量          
                string current = null;
                string keyTitle = "";

                string key = readerFind.ReadLine();//先读取补卡卡号的表头
                if (key != null && key != "")
                {
                    keyTitle = key;
                }
                else
                {
                    MessageBox.Show("文件："+ Path.GetFileName(findPath) + "\n表头参数不对！不能为空值");
                    
                    return;
                }
                //校验原始数据中表头参数匹配
                current = readerSource.ReadLine();
                if (!((current.IndexOf(keyTitle)) > -1))
                {
                    MessageBox.Show("文件：" + Path.GetFileName(findPath) + "\n原始数据中没有表头参数：\n" + keyTitle);
                    return;
                }
                //输出表头
                writer = new StreamWriter(outFile, false, Encoding.Default);
                writer.WriteLine(current);

                //确定关键字在数据行中以逗号分隔的索引
                int index = -1;
                string[] keys = current.Split(',');
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keyTitle == keys[i])
                    {
                        index = i;
                    }
                }
                //创建原始数据，以keytitle为键，当前行为值的，字典数据
                Dictionary<string, string> dict = new Dictionary<string, string>();
                while ((current = readerSource.ReadLine()) != null)
                {
                    dict.Add(current.Split(',')[index], current);//可能会下标越界
                    //Debug.WriteLine(current.Split(',')[index], current);
                    //File.AppendAllText("log.txt", current+" | "+current.Split(',')[index]+"\r\n");
                }

                //通过关键字在原始数组字典中查找对应的值
                int failCount = 0;
                int successCount = 0;
                while ((key = readerFind.ReadLine()) != null)
                {
                    //value = findLine(sourcePath, key);
                    if (dict.ContainsKey(key))
                    {
                        writer.WriteLine(dict[key]);
                        successCount++;
                    }
                    else
                    {
                        failCount++;
                    }
                }
                if (failCount > 0)
                {
                    MessageBox.Show("文件：" + findName + "\n补卡数据生成完成！\n成功：" + successCount + "\n失败：" + failCount, "查找结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //else
                //{
                //    MessageBox.Show("补卡数据生成完成！\n成功：" + successCount + "\n失败：" + failCount, "查找结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                readerSource.Close();
                if(writer!=null) writer.Close();
                readerFind.Close();
                if (File.Exists(sortPath)) File.Delete(sortPath);//删除排序临时文件
                if (File.Exists(trimPath)) File.Delete(trimPath);//删除去重临时文件
                Threadcount++;
                if (Threadcount == Threadcounts)//所有线程执行完毕
                {
                    if (File.Exists(combineMcaPath)) File.Delete(combineMcaPath);//删除合并临时文件
                    MessageBox.Show("补卡数据生成完成！","查找结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// 对mca排序，由小到大输出，返回输出路径
        /// </summary>
        /// <param name="mcaPath">输入mca文件路径</param>
        /// <returns>返回排序后mca路径</returns>
        private string SortMca(string mcaPath)
        {
            if (!File.Exists(mcaPath)) return "";//先判断文件是否存在，否则会抛出异常
            StreamReader reader = new StreamReader(mcaPath, Encoding.Default);
            string title = reader.ReadLine();//先读取一行，表头不参与排序
            if (title == null) return "";
            List<string> list = new List<string>();
            string current = null;
            while ((current = reader.ReadLine()) != null)
            {
                list.Add(current);
            }
            reader.Close();
            list.Sort();
            //排序后的保存路径
            string fileName = "Sort_" + Path.GetFileNameWithoutExtension(mcaPath) + ".tmp";
            string filePath = Path.GetDirectoryName(mcaPath);
            string sortMcaPath = Path.Combine(filePath, fileName);
            //保存输出
            StreamWriter writer = new StreamWriter(sortMcaPath, false, Encoding.Default);
            writer.WriteLine(title);
            foreach (string line in list)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            return sortMcaPath;
        }
        /// <summary>
        /// 删除重复项和空白行，返回一个临时文件路径
        /// </summary>
        /// <param name="mcaPath">mca文件路径</param>
        /// <returns>删除重复项和空白项的mca路径</returns>
        private string TrimMca(string mcaPath)
        {
            if (!File.Exists(mcaPath)) return "";
            //排序后的保存路径
            string fileName = "Trim_" + Path.GetFileNameWithoutExtension(mcaPath) + ".tmp";
            string filePath = Path.GetDirectoryName(mcaPath);
            string trimMcaPath = Path.Combine(filePath, fileName);
            HashSet<string> hashset = new HashSet<string>();
            StreamReader reader = new StreamReader(mcaPath, Encoding.Default);
            string current = null;
            int repeatCount = 0;
            int blankCount = 0;
            while ((current = reader.ReadLine()) != null)
            {
                if (current != "")
                {
                    if (hashset.Add(current))
                    {
                        //成功加入，不重复
                    }
                    else
                    {
                        repeatCount++;
                    }
                }
                else
                {
                    blankCount++;
                }
            }
            reader.Close();
            File.WriteAllLines(trimMcaPath, hashset, Encoding.Default);//保存
            if (repeatCount > 0 || blankCount > 0)
            {
                //先去除上一步中加入的前缀和扩展名。
                MessageBox.Show("文件："+ Path.GetFileName(mcaPath).Replace("Sort_","").Replace(".tmp","") + 
                    "\n补卡数据：\n去重：" + repeatCount + "\n去除空行：" + blankCount,
                    "提示|点击继续", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return trimMcaPath;

        }
    }
}
