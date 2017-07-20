namespace PrgTxtTransform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnMca = new System.Windows.Forms.Button();
            this.txtMCAPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHCosToPrg = new System.Windows.Forms.Button();
            this.btnCheckPrgMca = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnHcos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrg = new System.Windows.Forms.Button();
            this.txtPrgPath = new System.Windows.Forms.TextBox();
            this.grpPreInitail = new System.Windows.Forms.GroupBox();
            this.btnPrgToTxt = new System.Windows.Forms.Button();
            this.btnTxtToPrg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.txtSwapAfter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSwapBefor = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpPreInitail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMca
            // 
            this.btnMca.Location = new System.Drawing.Point(344, 20);
            this.btnMca.Name = "btnMca";
            this.btnMca.Size = new System.Drawing.Size(75, 23);
            this.btnMca.TabIndex = 0;
            this.btnMca.Text = "<<";
            this.btnMca.UseVisualStyleBackColor = true;
            this.btnMca.Click += new System.EventHandler(this.btnMca_Click);
            // 
            // txtMCAPath
            // 
            this.txtMCAPath.Location = new System.Drawing.Point(56, 22);
            this.txtMCAPath.Name = "txtMCAPath";
            this.txtMCAPath.Size = new System.Drawing.Size(274, 21);
            this.txtMCAPath.TabIndex = 1;
            this.txtMCAPath.Text = "txtMCAPath";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHCosToPrg);
            this.groupBox1.Controls.Add(this.btnCheckPrgMca);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnHcos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPrg);
            this.groupBox1.Controls.Add(this.txtPrgPath);
            this.groupBox1.Controls.Add(this.txtMCAPath);
            this.groupBox1.Controls.Add(this.btnMca);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人化脚本转换";
            // 
            // btnHCosToPrg
            // 
            this.btnHCosToPrg.Location = new System.Drawing.Point(25, 87);
            this.btnHCosToPrg.Name = "btnHCosToPrg";
            this.btnHCosToPrg.Size = new System.Drawing.Size(75, 23);
            this.btnHCosToPrg.TabIndex = 5;
            this.btnHCosToPrg.Text = "HCos->Prg";
            this.btnHCosToPrg.UseVisualStyleBackColor = true;
            this.btnHCosToPrg.Click += new System.EventHandler(this.btnHCosToPrg_Click);
            // 
            // btnCheckPrgMca
            // 
            this.btnCheckPrgMca.Location = new System.Drawing.Point(225, 87);
            this.btnCheckPrgMca.Name = "btnCheckPrgMca";
            this.btnCheckPrgMca.Size = new System.Drawing.Size(75, 23);
            this.btnCheckPrgMca.TabIndex = 7;
            this.btnCheckPrgMca.Text = "脚本校验";
            this.btnCheckPrgMca.UseVisualStyleBackColor = true;
            this.btnCheckPrgMca.Click += new System.EventHandler(this.btnCheckPrg_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "数据校验";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCheckMca_Click);
            // 
            // btnHcos
            // 
            this.btnHcos.Location = new System.Drawing.Point(344, 87);
            this.btnHcos.Name = "btnHcos";
            this.btnHcos.Size = new System.Drawing.Size(75, 23);
            this.btnHcos.TabIndex = 4;
            this.btnHcos.Text = "->HCos";
            this.btnHcos.UseVisualStyleBackColor = true;
            this.btnHcos.Click += new System.EventHandler(this.btnHcos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "脚本：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "数据：";
            // 
            // btnPrg
            // 
            this.btnPrg.Location = new System.Drawing.Point(344, 49);
            this.btnPrg.Name = "btnPrg";
            this.btnPrg.Size = new System.Drawing.Size(75, 23);
            this.btnPrg.TabIndex = 4;
            this.btnPrg.Text = "<<";
            this.btnPrg.UseVisualStyleBackColor = true;
            this.btnPrg.Click += new System.EventHandler(this.btnPrg_Click);
            // 
            // txtPrgPath
            // 
            this.txtPrgPath.Location = new System.Drawing.Point(56, 49);
            this.txtPrgPath.Name = "txtPrgPath";
            this.txtPrgPath.Size = new System.Drawing.Size(274, 21);
            this.txtPrgPath.TabIndex = 3;
            this.txtPrgPath.Text = "txtPrgPath";
            // 
            // grpPreInitail
            // 
            this.grpPreInitail.Controls.Add(this.btnPrgToTxt);
            this.grpPreInitail.Controls.Add(this.btnTxtToPrg);
            this.grpPreInitail.Location = new System.Drawing.Point(12, 12);
            this.grpPreInitail.Name = "grpPreInitail";
            this.grpPreInitail.Size = new System.Drawing.Size(224, 69);
            this.grpPreInitail.TabIndex = 3;
            this.grpPreInitail.TabStop = false;
            this.grpPreInitail.Text = "预个人化脚本转换";
            // 
            // btnPrgToTxt
            // 
            this.btnPrgToTxt.Location = new System.Drawing.Point(126, 29);
            this.btnPrgToTxt.Name = "btnPrgToTxt";
            this.btnPrgToTxt.Size = new System.Drawing.Size(75, 23);
            this.btnPrgToTxt.TabIndex = 5;
            this.btnPrgToTxt.Text = "Prg->Txt";
            this.btnPrgToTxt.UseVisualStyleBackColor = true;
            this.btnPrgToTxt.Click += new System.EventHandler(this.btnPrgToTxt_Click);
            // 
            // btnTxtToPrg
            // 
            this.btnTxtToPrg.Location = new System.Drawing.Point(25, 29);
            this.btnTxtToPrg.Name = "btnTxtToPrg";
            this.btnTxtToPrg.Size = new System.Drawing.Size(75, 23);
            this.btnTxtToPrg.TabIndex = 0;
            this.btnTxtToPrg.Text = "Txt->Prg";
            this.btnTxtToPrg.UseVisualStyleBackColor = true;
            this.btnTxtToPrg.Click += new System.EventHandler(this.btnTxtToPrg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "GetPrgLine";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "倒置前：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCount);
            this.groupBox2.Controls.Add(this.btnSwap);
            this.groupBox2.Controls.Add(this.txtSwapAfter);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSwapBefor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "辅助工具";
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(343, 52);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 9;
            this.btnSwap.Text = "两两倒置";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // txtSwapAfter
            // 
            this.txtSwapAfter.Location = new System.Drawing.Point(55, 54);
            this.txtSwapAfter.Name = "txtSwapAfter";
            this.txtSwapAfter.Size = new System.Drawing.Size(274, 21);
            this.txtSwapAfter.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "倒置后：";
            // 
            // txtSwapBefor
            // 
            this.txtSwapBefor.Location = new System.Drawing.Point(55, 20);
            this.txtSwapBefor.Name = "txtSwapBefor";
            this.txtSwapBefor.Size = new System.Drawing.Size(274, 21);
            this.txtSwapBefor.TabIndex = 6;
            this.txtSwapBefor.TextChanged += new System.EventHandler(this.txtSwapBefor_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(341, 27);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 12);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 335);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpPreInitail);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "研发数据测试工具包";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPreInitail.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMca;
        private System.Windows.Forms.TextBox txtMCAPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrg;
        private System.Windows.Forms.TextBox txtPrgPath;
        private System.Windows.Forms.GroupBox grpPreInitail;
        private System.Windows.Forms.Button btnPrgToTxt;
        private System.Windows.Forms.Button btnTxtToPrg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnHcos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCheckPrgMca;
        private System.Windows.Forms.Button btnHCosToPrg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TextBox txtSwapAfter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSwapBefor;
        private System.Windows.Forms.Label lblCount;
    }
}

