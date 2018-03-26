using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocialDataMerge
{

    public partial class FormMergeMca : Form
    {
        //修改主界面
        public delegate void PerformStep();
        public delegate void ProgressInit(int count);
        public delegate void ShowCount(object obj);
        public delegate void ShowStatus(string str);
        public delegate void AddListView(object obj);
        public PerformStep myPerformStep;
        public ProgressInit myProgressInit;
        public ShowCount myShowCount;
        public ShowStatus myShowStatus;
        public AddListView myAddListView;
        public void progressAdd()
        {
            tsProgressBar.PerformStep();
        }
        public void progressSetMax(int count)
        {
            tsProgressBar.Value = 0;
            tsProgressBar.Maximum = count;
            tsProgressBar.Step = 1;

        }
        public void showStatus(string str)
        {
            tslblStatus.Text = str;
        }
        public void showCount(object obj)
        {
            parameters p = (parameters)obj;
            string fileCount = p.one;
            string lineCount = p.two;

            lblCount.Text = fileCount;
            lblLines.Text = lineCount;
            btnCombine.Enabled = true;//合并按钮可用
        }
        public void addListView(object obj)
        {
            List<ThreeParameters> list = (List<ThreeParameters>)obj;
            //数据更新，UI暂时挂起，直到EndUpdate绘制控件，
            //可以有效避免闪烁并大大提高加载速度
            lvList.BeginUpdate();
            foreach (ThreeParameters threePara in list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = threePara.one;
                lvi.SubItems.Add(threePara.two);
                lvi.SubItems.Add(threePara.three);
                lvList.Items.Add(lvi);
            }
            //结束数据处理，UI界面一次性绘制。
            lvList.EndUpdate();
        }

        public FormMergeMca()
        {
            InitializeComponent();
        }

        private void FormMergeMca_Load(object sender, EventArgs e)
        {
            lblCount.Text = "";
            lblLines.Text = "";
            tslblStatus.Text = "等待数据";
            btnCombine.Enabled = false;
            myPerformStep = new PerformStep(progressAdd);
            myProgressInit = new ProgressInit(progressSetMax);
            myShowCount = new ShowCount(showCount);
            myShowStatus = new ShowStatus(showStatus);
            myAddListView = new AddListView(addListView);
        }
        struct parameters
        {
            public string one;
            public string two;
        }
        struct ThreeParameters
        {
            public string one;
            public string two;
            public string three;
        }
        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            //选择一个文件夹
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "选择数据文件夹";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = folder.SelectedPath;
                LoadList();
            }

        }
        private void LoadList()
        {
            //检查路径是否为空
            if (txtFolderPath.Text.Trim() == "") return;
            if (txtFilePath.Text.Trim() == "") return;
            lvList.Items.Clear();
            lblCount.Text = "0";
            lblLines.Text = "0";
            btnCombine.Enabled = false;//合并按钮不可用
            //AddListViewItems(txtFolderPath.Text);
            parameters p = new parameters();
            p.one = txtFolderPath.Text;
            p.two = txtFilePath.Text;
            Thread t = new Thread(AddListViewItems);
            t.Start(p);

        }
        private void AddListViewItems(object obj)
        {
            //拆箱
            parameters p = (parameters)obj;
            string path = p.one;
            string filePath = p.two;

            if (filePath.Trim() == "") return;
            if (path.Trim() == "") return;
            //开始加载数据
            this.Invoke(myShowStatus, "数据加载中");
            string[] files = File.ReadAllLines(filePath, Encoding.Default);
            this.Invoke(myProgressInit, files.Length * 2);

            //显示数据列表
            int fileCount = 0;
            int lineCount = 0;
            int listNum = 0;//文件列表序号
            List<string> existList = new List<string>();
            List<ThreeParameters> list = new List<ThreeParameters>();
            //加载数据列表，显示
            foreach (string file in files)
            {
                string fullName = Path.Combine(path, file);

                listNum++;
                ThreeParameters threePara = new ThreeParameters();
                threePara.one = listNum.ToString();
                if (File.Exists(fullName)) //文件存在检查
                {
                    fileCount++;//文件计数
                    existList.Add(fullName);
                    threePara.two = Mca.GetFileName(fullName);
                    int lines = Mca.GetFileLineCount(fullName) - 2;
                    lineCount += lines;
                    threePara.three = lines.ToString();
                }
                else
                {
                    threePara.two = "";
                    threePara.three = "";
                }
                list.Add(threePara);
                this.Invoke(myPerformStep);
            }
            //校验数据
            this.Invoke(myShowStatus, "数据校验中");
            int counts = Mca.checkMca(existList);
            if (counts == -1)//校验出错
            {
                this.Invoke(myProgressInit, 0);
                this.Invoke(myShowStatus, "数据校验出错");
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                { this.Invoke(myPerformStep); }
                parameters pLbl = new parameters();
                pLbl.one = fileCount.ToString();
                pLbl.two = lineCount.ToString();
                this.Invoke(myShowCount, pLbl);

                //             显示数据列表
                this.Invoke(myAddListView, list);
                this.Invoke(myShowStatus, "数据加载完成");
            }

        }
        private void AddListViewItems(string path)
        {
            lvList.Items.Clear();
            if (path.Trim() == "") return;

            List<string> fileLists = Mca.GetMcaList(path);
            int count = 0;
            //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.lvList.BeginUpdate();
            foreach (string file in fileLists)
            {
                count++;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = count.ToString();
                lvi.SubItems.Add(Mca.GetFileName(file));
                lvi.SubItems.Add((Mca.GetFileLineCount(file) - 2).ToString());
                lvList.Items.Add(lvi);
            }
            this.lvList.EndUpdate();//结束数据处理，UI界面一次性绘制。

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文档|*.txt|MCA数据|*.mca|所有数据|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
                //AddListViewItems(txtFolderPath.Text, txtFilePath.Text);
                LoadList();
            }

        }


        private void btnCombine_Click(object sender, EventArgs e)
        {
            //检查输入文件路径
            if (txtFolderPath.Text.Trim().Length == 0)
            {
                MessageBox.Show("未选择数据文件夹", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lvList.Items.Count <= 0)
            {
                MessageBox.Show("未选择要合并的文件", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //从文件列表中获取文件子列表
            List<string> files = new List<string>();
            for (int i = 0; i < lvList.Items.Count; i++)
            {
                ListViewItem lvi = lvList.Items[i];
                string file = lvi.SubItems[1].Text;
                files.Add(file);
            }
            files.Add("");//作为结尾标志位
                          //string outPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            listpath p = new listpath();
            p.list = files;
            p.path = txtFolderPath.Text;
            Thread t = new Thread(combineThread);
            t.Start(p);


        }
        struct listpath
        {
            public List<string> list;
            public string path;
        }

        private void combineThread(object obj)
        {
            //拆箱
            listpath p = (listpath)obj;
            List<string> list = p.list;
            string path = p.path;
            this.Invoke(myProgressInit, list.Count);
            this.Invoke(myShowStatus, "合并中...");
            //建立合并文件夹，存在则删除重建
            string saveFolder = Path.Combine(path, "合并文件");
            if (Directory.Exists(saveFolder))
            {
                Directory.Delete(saveFolder, true);
            }
            Directory.CreateDirectory(saveFolder);
            //开始合并
            List<string> files = new List<string>();
            int combineNum = 0;//文件名计数
            int counts = 0;//总行数，最后比对
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != "")
                {
                    string filePath = Path.Combine(path, list[i]);
                    files.Add(filePath);
                }
                if (list[i] == "" && files.Count > 0)
                {
                    combineNum++;
                    string outPath = Path.Combine(saveFolder, combineNum.ToString() + ".mca");
                    int count = Mca.CombineMCA(files, outPath);
                    counts += count;
                    files.Clear();
                }
                this.Invoke(myPerformStep);
            }
            this.Invoke(myShowStatus, "合并完成");
            MessageBox.Show("合并完成!\n文件数：" + combineNum + "\n数据：" + counts, "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //catch
            //{
            //    MessageBox.Show("诶呀！出问题了");
            //}
        }
        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserHelp fm = new FormUserHelp();
            fm.text = "1、选择包含MCA数据的文件夹；\n\n"+
                "2、选择txt格式的合并顺序文件，按照需要合并的顺序，文件名从上至下\n\n排列，需要带“.mca”；\n\n" +
                "3、点击合并，稍等片刻之后合并完成；\n\n"+
                "4、合并完成的文件夹在数据文件路径下“合并数据”文件夹下，\n\n\t命名为：“序号_数量.mca”\n\n";
            fm.ShowDialog();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fm = new FormAbout();
            fm.text = "软件名称：Mca数据合并工具-按指定顺序\n\n开发：彭世瑜\n\n联系方式：1940607002@qq.com\n\n公司：北京银证信通智能卡有限公司\n\n@2017年9月";
            fm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
