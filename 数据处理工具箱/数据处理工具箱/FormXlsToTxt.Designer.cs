namespace SocialDataMerge
{
    partial class FormXlsToTxt
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
            this.btnXlsPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbXlsPath = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXlsPath
            // 
            this.btnXlsPath.Location = new System.Drawing.Point(334, 56);
            this.btnXlsPath.Name = "btnXlsPath";
            this.btnXlsPath.Size = new System.Drawing.Size(75, 23);
            this.btnXlsPath.TabIndex = 0;
            this.btnXlsPath.Text = "<<";
            this.btnXlsPath.UseVisualStyleBackColor = true;
            this.btnXlsPath.Click += new System.EventHandler(this.btnXlsPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xls文件：";
            // 
            // tbXlsPath
            // 
            this.tbXlsPath.Location = new System.Drawing.Point(78, 58);
            this.tbXlsPath.Name = "tbXlsPath";
            this.tbXlsPath.Size = new System.Drawing.Size(250, 21);
            this.tbXlsPath.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(166, 161);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(88, 36);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // FormXlsToTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 262);
            this.Controls.Add(this.tbXlsPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnXlsPath);
            this.Name = "FormXlsToTxt";
            this.Text = "单列Xls转Txt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXlsPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbXlsPath;
        private System.Windows.Forms.Button btnConvert;
    }
}