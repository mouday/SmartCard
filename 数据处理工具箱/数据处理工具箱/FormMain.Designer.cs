namespace DataHandle
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabPageAddData = new System.Windows.Forms.TabPage();
            this.gpbAddData = new System.Windows.Forms.GroupBox();
            this.gbBack = new System.Windows.Forms.GroupBox();
            this.lblGbBackstart = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBackTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBackStart = new System.Windows.Forms.TextBox();
            this.txtBackStep = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbFront = new System.Windows.Forms.GroupBox();
            this.lblGbFrontstart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFrontTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrontStart = new System.Windows.Forms.TextBox();
            this.txtFrontStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnMcaPath = new System.Windows.Forms.Button();
            this.txtMcaPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageCombineMCA = new System.Windows.Forms.TabPage();
            this.gbCombine = new System.Windows.Forms.GroupBox();
            this.checkBoxSelect = new System.Windows.Forms.CheckBox();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCombine = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtOutFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInFolder = new System.Windows.Forms.TextBox();
            this.btnInfolder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePetroData = new System.Windows.Forms.TabPage();
            this.panelPetroData = new System.Windows.Forms.Panel();
            this.tabPageSocial = new System.Windows.Forms.TabPage();
            this.panelSocial = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageAddData.SuspendLayout();
            this.gpbAddData.SuspendLayout();
            this.gbBack.SuspendLayout();
            this.gbFront.SuspendLayout();
            this.tabPageCombineMCA.SuspendLayout();
            this.gbCombine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPagePetroData.SuspendLayout();
            this.tabPageSocial.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabPageAddData
            // 
            this.tabPageAddData.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAddData.Controls.Add(this.gpbAddData);
            this.tabPageAddData.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddData.Name = "tabPageAddData";
            this.tabPageAddData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddData.Size = new System.Drawing.Size(706, 442);
            this.tabPageAddData.TabIndex = 1;
            this.tabPageAddData.Text = "追加流水号";
            this.tabPageAddData.Click += new System.EventHandler(this.tabPageAddData_Click);
            // 
            // gpbAddData
            // 
            this.gpbAddData.Controls.Add(this.gbBack);
            this.gpbAddData.Controls.Add(this.gbFront);
            this.gpbAddData.Controls.Add(this.btnConfirm);
            this.gpbAddData.Controls.Add(this.btnMcaPath);
            this.gpbAddData.Controls.Add(this.txtMcaPath);
            this.gpbAddData.Controls.Add(this.label2);
            this.gpbAddData.Location = new System.Drawing.Point(30, 19);
            this.gpbAddData.Name = "gpbAddData";
            this.gpbAddData.Size = new System.Drawing.Size(650, 340);
            this.gpbAddData.TabIndex = 9;
            this.gpbAddData.TabStop = false;
            this.gpbAddData.Enter += new System.EventHandler(this.gpbAddData_Enter);
            // 
            // gbBack
            // 
            this.gbBack.Controls.Add(this.lblGbBackstart);
            this.gbBack.Controls.Add(this.label8);
            this.gbBack.Controls.Add(this.txtBackTitle);
            this.gbBack.Controls.Add(this.label9);
            this.gbBack.Controls.Add(this.txtBackStart);
            this.gbBack.Controls.Add(this.txtBackStep);
            this.gbBack.Controls.Add(this.label10);
            this.gbBack.Location = new System.Drawing.Point(343, 78);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(280, 152);
            this.gbBack.TabIndex = 18;
            this.gbBack.TabStop = false;
            this.gbBack.Text = "列后追加";
            // 
            // lblGbBackstart
            // 
            this.lblGbBackstart.AutoSize = true;
            this.lblGbBackstart.Location = new System.Drawing.Point(220, 70);
            this.lblGbBackstart.Name = "lblGbBackstart";
            this.lblGbBackstart.Size = new System.Drawing.Size(89, 12);
            this.lblGbBackstart.TabIndex = 20;
            this.lblGbBackstart.Text = "lblGbBackstart";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "表头名称：";
            // 
            // txtBackTitle
            // 
            this.txtBackTitle.Location = new System.Drawing.Point(93, 24);
            this.txtBackTitle.Name = "txtBackTitle";
            this.txtBackTitle.Size = new System.Drawing.Size(121, 21);
            this.txtBackTitle.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "起始位：";
            // 
            // txtBackStart
            // 
            this.txtBackStart.Location = new System.Drawing.Point(93, 66);
            this.txtBackStart.Name = "txtBackStart";
            this.txtBackStart.Size = new System.Drawing.Size(121, 21);
            this.txtBackStart.TabIndex = 13;
            this.txtBackStart.TextChanged += new System.EventHandler(this.txtBackStart_TextChanged);
            // 
            // txtBackStep
            // 
            this.txtBackStep.Location = new System.Drawing.Point(93, 108);
            this.txtBackStep.Name = "txtBackStep";
            this.txtBackStep.Size = new System.Drawing.Size(121, 21);
            this.txtBackStep.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "步长：";
            // 
            // gbFront
            // 
            this.gbFront.Controls.Add(this.lblGbFrontstart);
            this.gbFront.Controls.Add(this.label7);
            this.gbFront.Controls.Add(this.txtFrontTitle);
            this.gbFront.Controls.Add(this.label4);
            this.gbFront.Controls.Add(this.txtFrontStart);
            this.gbFront.Controls.Add(this.txtFrontStep);
            this.gbFront.Controls.Add(this.label5);
            this.gbFront.Location = new System.Drawing.Point(43, 78);
            this.gbFront.Name = "gbFront";
            this.gbFront.Size = new System.Drawing.Size(280, 152);
            this.gbFront.TabIndex = 13;
            this.gbFront.TabStop = false;
            this.gbFront.Text = "列前追加";
            // 
            // lblGbFrontstart
            // 
            this.lblGbFrontstart.AutoSize = true;
            this.lblGbFrontstart.Location = new System.Drawing.Point(226, 70);
            this.lblGbFrontstart.Name = "lblGbFrontstart";
            this.lblGbFrontstart.Size = new System.Drawing.Size(95, 12);
            this.lblGbFrontstart.TabIndex = 19;
            this.lblGbFrontstart.Text = "lblGbFrontstart";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "表头名称：";
            // 
            // txtFrontTitle
            // 
            this.txtFrontTitle.Location = new System.Drawing.Point(90, 24);
            this.txtFrontTitle.Name = "txtFrontTitle";
            this.txtFrontTitle.Size = new System.Drawing.Size(130, 21);
            this.txtFrontTitle.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "起始位：";
            // 
            // txtFrontStart
            // 
            this.txtFrontStart.Location = new System.Drawing.Point(90, 66);
            this.txtFrontStart.Name = "txtFrontStart";
            this.txtFrontStart.Size = new System.Drawing.Size(130, 21);
            this.txtFrontStart.TabIndex = 13;
            this.txtFrontStart.TextChanged += new System.EventHandler(this.txtFrontStart_TextChanged);
            // 
            // txtFrontStep
            // 
            this.txtFrontStep.Location = new System.Drawing.Point(90, 108);
            this.txtFrontStep.Name = "txtFrontStep";
            this.txtFrontStep.Size = new System.Drawing.Size(130, 21);
            this.txtFrontStep.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "步长：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfirm.Location = new System.Drawing.Point(296, 257);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(85, 39);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "确定追加";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnMcaPath
            // 
            this.btnMcaPath.Location = new System.Drawing.Point(548, 35);
            this.btnMcaPath.Name = "btnMcaPath";
            this.btnMcaPath.Size = new System.Drawing.Size(75, 23);
            this.btnMcaPath.TabIndex = 9;
            this.btnMcaPath.Text = "<<";
            this.btnMcaPath.UseVisualStyleBackColor = true;
            this.btnMcaPath.Click += new System.EventHandler(this.btnMcaPath_Click);
            // 
            // txtMcaPath
            // 
            this.txtMcaPath.Location = new System.Drawing.Point(110, 36);
            this.txtMcaPath.Name = "txtMcaPath";
            this.txtMcaPath.Size = new System.Drawing.Size(425, 21);
            this.txtMcaPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "MCA数据：";
            // 
            // tabPageCombineMCA
            // 
            this.tabPageCombineMCA.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCombineMCA.Controls.Add(this.gbCombine);
            this.tabPageCombineMCA.Location = new System.Drawing.Point(4, 22);
            this.tabPageCombineMCA.Name = "tabPageCombineMCA";
            this.tabPageCombineMCA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCombineMCA.Size = new System.Drawing.Size(706, 442);
            this.tabPageCombineMCA.TabIndex = 0;
            this.tabPageCombineMCA.Text = "MCA数据合并";
            // 
            // gbCombine
            // 
            this.gbCombine.BackColor = System.Drawing.Color.Transparent;
            this.gbCombine.Controls.Add(this.checkBoxSelect);
            this.gbCombine.Controls.Add(this.lblSelectedCount);
            this.gbCombine.Controls.Add(this.label6);
            this.gbCombine.Controls.Add(this.btnCombine);
            this.gbCombine.Controls.Add(this.button3);
            this.gbCombine.Controls.Add(this.dataGridView1);
            this.gbCombine.Controls.Add(this.txtOutFolder);
            this.gbCombine.Controls.Add(this.label3);
            this.gbCombine.Controls.Add(this.btnOutFolder);
            this.gbCombine.Controls.Add(this.label1);
            this.gbCombine.Controls.Add(this.txtInFolder);
            this.gbCombine.Controls.Add(this.btnInfolder);
            this.gbCombine.Location = new System.Drawing.Point(3, 3);
            this.gbCombine.Name = "gbCombine";
            this.gbCombine.Size = new System.Drawing.Size(700, 433);
            this.gbCombine.TabIndex = 0;
            this.gbCombine.TabStop = false;
            this.gbCombine.Enter += new System.EventHandler(this.gbCombine_Enter);
            // 
            // checkBoxSelect
            // 
            this.checkBoxSelect.AutoSize = true;
            this.checkBoxSelect.Location = new System.Drawing.Point(462, 47);
            this.checkBoxSelect.Name = "checkBoxSelect";
            this.checkBoxSelect.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelect.TabIndex = 11;
            this.checkBoxSelect.Text = "全选";
            this.checkBoxSelect.UseVisualStyleBackColor = true;
            this.checkBoxSelect.CheckedChanged += new System.EventHandler(this.checkBoxSelect_CheckedChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedCount.Location = new System.Drawing.Point(555, 86);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(101, 12);
            this.lblSelectedCount.TabIndex = 10;
            this.lblSelectedCount.Text = "lblSelectedCount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "已选数据条数：";
            // 
            // btnCombine
            // 
            this.btnCombine.Location = new System.Drawing.Point(575, 32);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(81, 40);
            this.btnCombine.TabIndex = 8;
            this.btnCombine.Text = "合并选中";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(748, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "添加数据测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(18, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(666, 317);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // txtOutFolder
            // 
            this.txtOutFolder.Location = new System.Drawing.Point(103, 71);
            this.txtOutFolder.Name = "txtOutFolder";
            this.txtOutFolder.Size = new System.Drawing.Size(256, 21);
            this.txtOutFolder.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "输出路径：";
            // 
            // btnOutFolder
            // 
            this.btnOutFolder.Location = new System.Drawing.Point(365, 69);
            this.btnOutFolder.Name = "btnOutFolder";
            this.btnOutFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOutFolder.TabIndex = 3;
            this.btnOutFolder.Text = "<<";
            this.btnOutFolder.UseVisualStyleBackColor = true;
            this.btnOutFolder.Click += new System.EventHandler(this.btnOutFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择文件夹：";
            // 
            // txtInFolder
            // 
            this.txtInFolder.Location = new System.Drawing.Point(103, 34);
            this.txtInFolder.Name = "txtInFolder";
            this.txtInFolder.Size = new System.Drawing.Size(256, 21);
            this.txtInFolder.TabIndex = 1;
            // 
            // btnInfolder
            // 
            this.btnInfolder.Location = new System.Drawing.Point(365, 32);
            this.btnInfolder.Name = "btnInfolder";
            this.btnInfolder.Size = new System.Drawing.Size(75, 23);
            this.btnInfolder.TabIndex = 0;
            this.btnInfolder.Text = "<<";
            this.btnInfolder.UseVisualStyleBackColor = true;
            this.btnInfolder.Click += new System.EventHandler(this.btnInfolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCombineMCA);
            this.tabControl1.Controls.Add(this.tabPageAddData);
            this.tabControl1.Controls.Add(this.tabPagePetroData);
            this.tabControl1.Controls.Add(this.tabPageSocial);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(714, 468);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPagePetroData
            // 
            this.tabPagePetroData.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePetroData.Controls.Add(this.panelPetroData);
            this.tabPagePetroData.Location = new System.Drawing.Point(4, 22);
            this.tabPagePetroData.Name = "tabPagePetroData";
            this.tabPagePetroData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePetroData.Size = new System.Drawing.Size(706, 442);
            this.tabPagePetroData.TabIndex = 2;
            this.tabPagePetroData.Text = "中石油数据生成";
            // 
            // panelPetroData
            // 
            this.panelPetroData.Location = new System.Drawing.Point(61, 26);
            this.panelPetroData.Name = "panelPetroData";
            this.panelPetroData.Size = new System.Drawing.Size(590, 380);
            this.panelPetroData.TabIndex = 0;
            // 
            // tabPageSocial
            // 
            this.tabPageSocial.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSocial.Controls.Add(this.panelSocial);
            this.tabPageSocial.Location = new System.Drawing.Point(4, 22);
            this.tabPageSocial.Name = "tabPageSocial";
            this.tabPageSocial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSocial.Size = new System.Drawing.Size(706, 442);
            this.tabPageSocial.TabIndex = 3;
            this.tabPageSocial.Text = "社保合并";
            // 
            // panelSocial
            // 
            this.panelSocial.Location = new System.Drawing.Point(97, 37);
            this.panelSocial.Name = "panelSocial";
            this.panelSocial.Size = new System.Drawing.Size(520, 360);
            this.panelSocial.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(164, 17);
            this.toolStripStatusLabel1.Text = "北京银证信通智能卡有限公司";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 520);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据处理工具箱";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageAddData.ResumeLayout(false);
            this.gpbAddData.ResumeLayout(false);
            this.gpbAddData.PerformLayout();
            this.gbBack.ResumeLayout(false);
            this.gbBack.PerformLayout();
            this.gbFront.ResumeLayout(false);
            this.gbFront.PerformLayout();
            this.tabPageCombineMCA.ResumeLayout(false);
            this.gbCombine.ResumeLayout(false);
            this.gbCombine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPagePetroData.ResumeLayout(false);
            this.tabPageSocial.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabPageAddData;
        private System.Windows.Forms.TabPage tabPageCombineMCA;
        private System.Windows.Forms.GroupBox gbCombine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInFolder;
        private System.Windows.Forms.Button btnInfolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtOutFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOutFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMcaPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbAddData;
        private System.Windows.Forms.Button btnMcaPath;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox gbBack;
        private System.Windows.Forms.Label lblGbBackstart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBackTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBackStart;
        private System.Windows.Forms.TextBox txtBackStep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbFront;
        private System.Windows.Forms.Label lblGbFrontstart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFrontTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFrontStart;
        private System.Windows.Forms.TextBox txtFrontStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxSelect;
        private System.Windows.Forms.TabPage tabPagePetroData;
        private System.Windows.Forms.Panel panelPetroData;
        private System.Windows.Forms.TabPage tabPageSocial;
        private System.Windows.Forms.Panel panelSocial;
    }
}

