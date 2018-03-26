using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocialDataMerge
{
    public partial class FormXlsToTxt : Form
    {
        public FormXlsToTxt()
        {
            InitializeComponent();
        }

        private void btnXlsPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL文件|*.xls;*.xlsx|所有数据|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbXlsPath.Text = openFileDialog.FileName;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (tbXlsPath.Text == "") return;
            int count = NpoiExcelConvertTxt(tbXlsPath.Text);
            MessageBox.Show("导出完毕\n共计：" + count);
        }

        private int NpoiExcelConvertTxt(string filePath)
        {

            string folder = Path.GetDirectoryName(filePath);
            IWorkbook workbook = null;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //MessageBox.Show(Path.GetExtension(filePath));
            if (Path.GetExtension(filePath) == ".xlsx") // 2007版本
            {
                workbook = new XSSFWorkbook();
                //MessageBox.Show("xlsx");
            }
            else if (Path.GetExtension(filePath) == ".xls") // 2003版本
            {
                workbook = new HSSFWorkbook();
                //MessageBox.Show("xls");
            }
            int count = 0;
            //MessageBox.Show(filePath);
            //MessageBox.Show(workbook.NumberOfSheets.ToString());
            //获取sheet总数有问题》》》》》》》》》》》
            //》》》》》》》》》》》》》》》》》
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                count++;
                ISheet sheet = workbook.GetSheetAt(i);
                IRow row = sheet.GetRow(i);
                List<string> list = new List<string>();
                if (row != null)
                {
                    for (int j = 0; j <= row.LastCellNum; j++)
                    {
                        ICell cell = row.GetCell(j);

                        if (cell != null)
                        {
                            string cellvalue = cell.ToString();
                            list.Add(cellvalue);
                        }
                    }
                }
                string filename = workbook.GetSheetName(i).ToString() + ".txt";
                string path = Path.Combine(folder, filename);
                File.WriteAllLines(path, list, Encoding.Default);//写入
            }
            //保存关闭
            fs.Close();
            workbook.Close();
            return count;
        }



    }
}


