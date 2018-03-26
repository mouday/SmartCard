namespace SocialDataMerge
{
    partial class FormFindCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindCard));
            this.btnCereate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindData = new System.Windows.Forms.TextBox();
            this.txtSourceData = new System.Windows.Forms.TextBox();
            this.btnFindData = new System.Windows.Forms.Button();
            this.btnSourceData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCereate
            // 
            this.btnCereate.Location = new System.Drawing.Point(221, 184);
            this.btnCereate.Name = "btnCereate";
            this.btnCereate.Size = new System.Drawing.Size(105, 33);
            this.btnCereate.TabIndex = 2;
            this.btnCereate.Text = "生成补卡数据";
            this.btnCereate.UseVisualStyleBackColor = true;
            this.btnCereate.Click += new System.EventHandler(this.btnCereate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFindData);
            this.groupBox1.Controls.Add(this.txtSourceData);
            this.groupBox1.Controls.Add(this.btnFindData);
            this.groupBox1.Controls.Add(this.btnSourceData);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "补卡卡号文件夹：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "原始数据文件夹：";
            // 
            // txtFindData
            // 
            this.txtFindData.Location = new System.Drawing.Point(127, 78);
            this.txtFindData.Name = "txtFindData";
            this.txtFindData.Size = new System.Drawing.Size(299, 21);
            this.txtFindData.TabIndex = 10;
            // 
            // txtSourceData
            // 
            this.txtSourceData.Location = new System.Drawing.Point(127, 31);
            this.txtSourceData.Name = "txtSourceData";
            this.txtSourceData.Size = new System.Drawing.Size(298, 21);
            this.txtSourceData.TabIndex = 9;
            // 
            // btnFindData
            // 
            this.btnFindData.Location = new System.Drawing.Point(431, 77);
            this.btnFindData.Name = "btnFindData";
            this.btnFindData.Size = new System.Drawing.Size(75, 23);
            this.btnFindData.TabIndex = 8;
            this.btnFindData.Text = "<<";
            this.btnFindData.UseVisualStyleBackColor = true;
            this.btnFindData.Click += new System.EventHandler(this.btnFindData_Click);
            // 
            // btnSourceData
            // 
            this.btnSourceData.Location = new System.Drawing.Point(431, 30);
            this.btnSourceData.Name = "btnSourceData";
            this.btnSourceData.Size = new System.Drawing.Size(75, 23);
            this.btnSourceData.TabIndex = 7;
            this.btnSourceData.Text = "<<";
            this.btnSourceData.UseVisualStyleBackColor = true;
            this.btnSourceData.Click += new System.EventHandler(this.btnSourceData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "提示：补卡数据会在补卡卡号同文件下生成“BK_”开头的mca文件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "开发：彭世瑜（QQ：1940607002）";
            // 
            // FormFindCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 312);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCereate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(570, 350);
            this.MinimumSize = new System.Drawing.Size(570, 350);
            this.Name = "FormFindCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提取补卡数据工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCereate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindData;
        private System.Windows.Forms.TextBox txtSourceData;
        private System.Windows.Forms.Button btnFindData;
        private System.Windows.Forms.Button btnSourceData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}