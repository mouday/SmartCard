namespace DataHandle
{
    partial class FormLable_ChongqingMobile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTxt = new System.Windows.Forms.Button();
            this.btnXls = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTxtPath = new System.Windows.Forms.TextBox();
            this.txtXlsPath = new System.Windows.Forms.TextBox();
            this.btnCmd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTxt
            // 
            this.btnTxt.Location = new System.Drawing.Point(334, 32);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(75, 23);
            this.btnTxt.TabIndex = 0;
            this.btnTxt.Text = "<<";
            this.btnTxt.UseVisualStyleBackColor = true;
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);
            // 
            // btnXls
            // 
            this.btnXls.Location = new System.Drawing.Point(334, 86);
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(75, 23);
            this.btnXls.TabIndex = 1;
            this.btnXls.Text = "<<";
            this.btnXls.UseVisualStyleBackColor = true;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "总装箱单：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "标签数据：";
            // 
            // txtTxtPath
            // 
            this.txtTxtPath.Location = new System.Drawing.Point(97, 33);
            this.txtTxtPath.Name = "txtTxtPath";
            this.txtTxtPath.Size = new System.Drawing.Size(222, 21);
            this.txtTxtPath.TabIndex = 4;
            // 
            // txtXlsPath
            // 
            this.txtXlsPath.Location = new System.Drawing.Point(97, 87);
            this.txtXlsPath.Name = "txtXlsPath";
            this.txtXlsPath.Size = new System.Drawing.Size(222, 21);
            this.txtXlsPath.TabIndex = 5;
            // 
            // btnCmd
            // 
            this.btnCmd.Location = new System.Drawing.Point(162, 178);
            this.btnCmd.Name = "btnCmd";
            this.btnCmd.Size = new System.Drawing.Size(91, 34);
            this.btnCmd.TabIndex = 6;
            this.btnCmd.Text = "一键拆分";
            this.btnCmd.UseVisualStyleBackColor = true;
            this.btnCmd.Click += new System.EventHandler(this.btnCmd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "总箱数：";
            // 
            // txtTotalBox
            // 
            this.txtTotalBox.Location = new System.Drawing.Point(97, 132);
            this.txtTotalBox.Name = "txtTotalBox";
            this.txtTotalBox.Size = new System.Drawing.Size(100, 21);
            this.txtTotalBox.TabIndex = 8;
            // 
            // FormLable_ChongqingMobile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.txtTotalBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCmd);
            this.Controls.Add(this.txtXlsPath);
            this.Controls.Add(this.txtTxtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnTxt);
            this.Name = "FormLable_ChongqingMobile";
            this.Text = "重庆移动装箱清单生成工具";
            this.Load += new System.EventHandler(this.FormLable_ChongqingMobile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTxt;
        private System.Windows.Forms.Button btnXls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTxtPath;
        private System.Windows.Forms.TextBox txtXlsPath;
        private System.Windows.Forms.Button btnCmd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalBox;
    }
}