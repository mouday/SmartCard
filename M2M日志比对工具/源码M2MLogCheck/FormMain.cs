using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M2MLogCheck
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 提取关键字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelect fm = new FormSelect();
            fm.Show();
        }

        private void m2M日志比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormM2M fm = new FormM2M();
            fm.Show();
        }

        private void 京医通日志比对ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormJYT fm = new FormJYT();
            fm.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //label1.Font.Name = "微软雅黑";
            //label1.Font.Size = 17;
            //this.label1.Font = new Font("微软雅黑", 17, FontStyle.Bold);
            this.label1.ForeColor = Color.Red;

        }

        private void m2M日志比对ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormM2M fm = new FormM2M();
            fm.Show();
        }

        private void 京医通日志比对ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormJYT fm = new FormJYT();
            fm.Show();
        }

        private void 查找重复项ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            FormCheckRepeat fm = new FormCheckRepeat();
            fm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.label1.Left < this.Width)
            {
                this.label1.Left += 1; 
            }
            else
            {
                this.label1.Left=0;
            }
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 获取列数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGetColumn fm = new FormGetColumn();
            fm.Show();
        }

        private void 合并日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCombine fm = new FormCombine();
            fm.Show(); 
        }

        private void m2M日志报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelect fm = new FormSelect();
            fm.Show();
        }

        private void m2M中电转友联ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGCesccConvertM2M fm = new LOGCesccConvertM2M();
            fm.Show();
        }
    }
}
