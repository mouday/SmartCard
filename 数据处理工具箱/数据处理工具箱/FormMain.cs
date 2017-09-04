using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataHandle
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.ResizeRedraw |
            //  ControlStyles.OptimizedDoubleBuffer |
            //  ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "ces";
            this.dataGridView1.Rows[index].Cells[1].Value = "ces";
            this.dataGridView1.Rows[index].Cells[2].Value = "ces";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].Width = 70;
            //cmbMode.Items.Add("列前");
            //cmbMode.Items.Add("列后");
            //cmbMode.SelectedIndex = 0;
            txtFrontStep.Text = "1";
            txtBackStep.Text = "1";
            lblGbFrontstart.Text = "";
            lblGbBackstart.Text = "";
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
           // dataGridView1.Columns[0].Width = 100;
            //dataGridView1.Columns[1].Width = 100;
            lblSelectedCount.Text = "";
            SumSelectedCount();
            
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            { 
                DataGridViewRow r=this.dataGridView1.Rows[i];
                //r.HeaderCell.Value = String.Format("{0}",i+1);
            }
            //this.dataGridView1.Refresh();
        }

        private void tabPageAddData_Click(object sender, EventArgs e)
        {

        }

        private void gpbAddData_Enter(object sender, EventArgs e)
        {

        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMcaPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "mca|*mca|all|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMcaPath.Text = openFileDialog.FileName;               
            }
        }

        //追加流水号确认按钮
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtMcaPath.Text == String.Empty) return;
            StreamReader reader = new StreamReader(txtMcaPath.Text, Encoding.Default);
            StreamWriter writer = new StreamWriter(txtMcaPath.Text + ".mca", true, Encoding.Default);
            string current = null;
            //read +  write  title
            if ((current = reader.ReadLine()) != null)
            {
                if (txtFrontTitle.Text.Trim() != "")
                {
                    current = txtFrontTitle.Text + "," + current;
                }
                if (txtBackTitle.Text.Trim() != "")
                {
                    current = current + "," + txtBackTitle.Text;
                }
                writer.WriteLine(current);
            }
            //get setup parameters
            long frontStart = 0; ;
            int frontLen = 0;
            int frontStep = 0;
            long backStart = 0;
            int backLen = 0;
            int backStep = 0;

            if (txtFrontTitle.Text.Trim() != "")
            {
                frontStart = Convert.ToInt64(txtFrontStart.Text);
                frontLen = txtFrontStart.Text.Length;
                frontStep = Convert.ToInt32(txtFrontStep.Text);
            }
            if (txtBackTitle.Text.Trim() != "")
            {
                backStart = Convert.ToInt64(txtBackStart.Text);
                backLen = txtBackStart.Text.Length;
                backStep = Convert.ToInt32(txtBackStep.Text);
            }

            //read  + write  content
            while ((current = reader.ReadLine()) != null)
            {
                if (txtFrontTitle.Text.Trim() != "")
                {
                    current = frontStart.ToString().PadLeft(frontLen, '0') + "," + current;
                }
                if (txtBackTitle.Text.Trim() != "")
                {
                    current = current + "," + backStart.ToString().PadLeft(backLen, '0');
                }
                writer.WriteLine(current);
                frontStart += frontStep;
                backStart += backStep;
            }

            reader.Close();
            writer.Close();
            MessageBox.Show("ok");
        }

        private void txtFrontStart_TextChanged(object sender, EventArgs e)
        {
            lblGbFrontstart.Text = txtFrontStart.Text.Length.ToString();
        }

        private void txtBackStart_TextChanged(object sender, EventArgs e)
        {
            lblGbBackstart.Text = txtBackStart.Text.Length.ToString();
        }

        
        private void btnInfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtInFolder.Text = folderBrowserDialog.SelectedPath;
                if(txtInFolder.Text.Substring(txtInFolder.Text.Length-1,1)!=@"\")
                {
                    txtInFolder.Text+=@"\";
                }
                txtOutFolder.Text = txtInFolder.Text+@"new\";
                Application.DoEvents();
                //dataGridView1.Rows.Clear();
                dataGridView1.DataSource = GetFileTable(txtInFolder.Text);
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
            }

        }

        private DataTable GetFileTable(string path)
        {
            List<string> fileList = new List<string>();
            fileList.Clear();
            fileList = mca.GetMcaList(path);
            DataTable dataTable=new DataTable();
            dataTable.Columns.Add("状态", Type.GetType("System.String"));
            
            dataTable.Columns.Add("数量", Type.GetType("System.String"));
            dataTable.Columns.Add("文件名", Type.GetType("System.String"));
            
            foreach (string file in fileList)
            {
                //int index = this.dataGridView1.Rows.Add();
                //this.dataGridView1.Rows[index].Cells[0].Value = "未合并";
                //this.dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.Yellow;
                //this.dataGridView1.Rows[index].Cells[1].Value = mca.GetFileLinesCount(file) - 2;
                //this.dataGridView1.Rows[index].Cells[2].Value = mca.GetFileName(file);
                DataRow row = dataTable.NewRow();
                row[0] = "未合并";
                row[1] = mca.GetFileLinesCount(file) - 2;
                row[2] = mca.GetFileName(file);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private void gbCombine_Enter(object sender, EventArgs e)
        {

        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (txtInFolder.Text == String.Empty) return;
            if (!Directory.Exists(txtOutFolder.Text))
            {
                Directory.CreateDirectory(txtOutFolder.Text);
            }
            List<string> fileLists = new List<string>();
            for (int i = dataGridView1.SelectedRows.Count-1; i >-1; i--)
            {
                fileLists.Add(txtInFolder.Text+dataGridView1.SelectedRows[i].Cells[2].Value);

                dataGridView1.SelectedRows[i].Cells[0].Style.BackColor = Color.Green;
                dataGridView1.SelectedRows[i].Cells[0].Value = "已合并" + (dataGridView1.SelectedRows.Count-i);
            }
            string path = txtOutFolder.Text + "合并数据" +
                 dataGridView1.SelectedRows[dataGridView1.SelectedRows.Count - 1].Cells[2].Value 
                 + "-" + dataGridView1.SelectedRows[0].Cells[2].Value+
                 "(" + lblSelectedCount.Text + ")" + ".mca";
            mca.CombineMCA(fileLists, path);
            MessageBox.Show("     合并完成!\n\n成功合并文件数：" + dataGridView1.SelectedRows.Count+
                "\n数据条数："+lblSelectedCount.Text,"完成提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SumSelectedCount();
        }

        private void checkBoxSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelect.Checked == true)
            {
                dataGridView1.SelectAll();
            }
            else {
                dataGridView1.ClearSelection();
            }
            SumSelectedCount();
        }
        private void SumSelectedCount()
        {
            long count = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                count += Convert.ToInt64(dataGridView1.SelectedRows[i].Cells[1].Value);
            }
            lblSelectedCount.Text = count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOutFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutFolder.Text = folderBrowserDialog.SelectedPath;
                if (txtOutFolder.Text.Substring(txtOutFolder.Text.Length - 1, 1) != @"\")
                {
                    txtOutFolder.Text += @"\";
                }               
                Application.DoEvents();               
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPagePetroData)
            {
                FormPetroChina fm = new FormPetroChina();
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                panelPetroData.Controls.Add(fm);
                fm.Show();
            }
            if (tabControl1.SelectedTab == tabPageSocial)
            {
                FormSocial fm = new FormSocial();
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                panelSocial.Controls.Add(fm);
                fm.Show();
            }
            if (tabControl1.SelectedTab == tabPageChongqingMobile)
            {
                FormLable_ChongqingMobile fm = new FormLable_ChongqingMobile();
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                panelChongqing.Controls.Add(fm);
                fm.Show();
            }
        }

        //private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //{
        //    string colName = this.dataGridView1.Columns[e.ColumnIndex].Name;//读取单元格对应的列名称
        //    if (colName.Equals("状态")) //如果单元格的名称等于序号列，则此单元格的值+1
        //    {       
        //        e.Value = e.RowIndex + 1;
        //    }
        //    else
        //    {
        //    oRst.MoveTo(e.RowIndex + 1);//oRst是表示数据集或记录集即你的数据源，然后移动到当前行。           
        //    e.Value = oRst.GetFieldValueText(colName);//oRst通过列名提取数据集或记录集里的数据，赋值给当前的单元格
        //}

    }
}
