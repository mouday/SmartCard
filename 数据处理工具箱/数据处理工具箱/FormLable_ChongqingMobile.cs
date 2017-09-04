using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace DataHandle
{
    public partial class FormLable_ChongqingMobile : Form
    {
        public FormLable_ChongqingMobile()
        {
            InitializeComponent();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文档(txt)|*.txt|所有文件|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTxtPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnXls_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "数据表格(xls)|*.xls|所有文件|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtXlsPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            SplitTxt();
            MessageBox.Show("处理完成！");
        }

        private void FormLable_ChongqingMobile_Load(object sender, EventArgs e)
        {

        }

        private void SplitTxt()
        {
            //判断元素
            if (txtTxtPath.Text == null) return;
            if (txtXlsPath.Text == null) return;
            if (txtTotalBox.Text == null) return;

            //打开excel装机清单

            FileStream fs = new FileStream(txtXlsPath.Text, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            ISheet sheet = workbook.GetSheetAt(0);
            StreamReader reader = new StreamReader(txtTxtPath.Text, Encoding.Default);

            string dirPath = Path.GetDirectoryName(txtTxtPath.Text);//默认保存到文本路径下

            int smallBoxCount = 0;//箱子里边的盒号
            int count = 0;//读取行数计数
            string current = null;//当前行读取内容
            int currentBox = 0; //当前箱号

            //开始读取excel
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                //如果不是第一个表格，表头行就不复制
                count++;
                IRow row = sheet.GetRow(i);//读取行
                if (row != null)
                {
                    //获取表格中必要数值
                    ICell ICCIDBegin = row.GetCell(3);
                    ICell ICCIDEnd = row.GetCell(4);
                    ICell boxNum = row.GetCell(7);

                    if (ICCIDBegin != null && ICCIDEnd != null && boxNum != null)
                    {
                        //箱内盒号累加
                        if (Convert.ToInt32(boxNum.ToString()) == currentBox)
                        {
                            smallBoxCount++;
                        }
                        else
                        {
                            currentBox = Convert.ToInt32(boxNum.ToString());
                            smallBoxCount = 1;
                        }

                        string fileName = txtTotalBox.Text + "-" + boxNum + "-" + smallBoxCount + ".TXT";
                        string path = Path.Combine(dirPath, fileName);
                        StreamWriter writer = new StreamWriter(path, true, Encoding.Default);

                        current = reader.ReadLine();

                        string iccid = current.Split(',')[1];//获取文本首iccid
                        if (iccid == ICCIDBegin.ToString())
                        {
                            writer.WriteLine(current.Split(',')[0] + " " + current.Split(',')[1]);
                            do
                            {
                                current = reader.ReadLine();
                                if (current == null) break;

                                writer.WriteLine(current.Split(',')[0] + " " + current.Split(',')[1]);

                            } while ((iccid = current.Split(',')[1]) != ICCIDEnd.ToString());

                        }
                        writer.Close();
                    }
                }
            }
            reader.Close();
            workbook.Close();
            fs.Close();
        }
        //保存关闭

        //读取txt文本拆分

    }
}
