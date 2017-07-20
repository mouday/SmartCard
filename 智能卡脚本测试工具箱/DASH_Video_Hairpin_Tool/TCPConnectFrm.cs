using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace DASH_Video_Hairpin_Tool
{
	public class TCPConnectFrm : Form
	{
		private TcpClient tcpclnt = new TcpClient();
		private IContainer components = null;
		private GroupBox GroupBIPConnect;
		private Button BTConnect;
		private TextBox TxtPort;
		private TextBox TxtIP;
		private Label LBPort;
		private Label LBIP;
		private GroupBox GroupBMode;
		private Button BTModeInitialization;
		private TextBox TxtModeName;
		private Label LbMode;
		public TCPConnectFrm()
		{
			this.InitializeComponent();
		}
		private void BTConnect_Click(object sender, EventArgs e)
		{
			if (this.TxtIP.Text == "" || this.TxtPort.Text == "")
			{
				MessageBox.Show("请选择填写IP地址、端口号！！");
			}
			else
			{
				IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(this.TxtIP.Text.Trim()), (int)short.Parse(this.TxtPort.Text.Trim()));
				Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				client.BeginConnect(ipe, delegate(IAsyncResult asyncResult)
				{
					client.EndConnect(asyncResult);
				}, null);
				this.tcpclnt.Connect(this.TxtIP.Text.Trim(), (int)short.Parse(this.TxtPort.Text.Trim()));
			}
		}
		private void BTModeInitialization_Click(object sender, EventArgs e)
		{
			if (this.TxtModeName.Text == "")
			{
				MessageBox.Show("请选择模板名称！！");
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.GroupBIPConnect = new GroupBox();
			this.LBIP = new Label();
			this.LBPort = new Label();
			this.TxtIP = new TextBox();
			this.TxtPort = new TextBox();
			this.BTConnect = new Button();
			this.GroupBMode = new GroupBox();
			this.BTModeInitialization = new Button();
			this.TxtModeName = new TextBox();
			this.LbMode = new Label();
			this.GroupBIPConnect.SuspendLayout();
			this.GroupBMode.SuspendLayout();
			base.SuspendLayout();
			this.GroupBIPConnect.Controls.Add(this.BTConnect);
			this.GroupBIPConnect.Controls.Add(this.TxtPort);
			this.GroupBIPConnect.Controls.Add(this.TxtIP);
			this.GroupBIPConnect.Controls.Add(this.LBPort);
			this.GroupBIPConnect.Controls.Add(this.LBIP);
			this.GroupBIPConnect.Location = new Point(0, 0);
			this.GroupBIPConnect.Name = "GroupBIPConnect";
			this.GroupBIPConnect.Size = new Size(339, 139);
			this.GroupBIPConnect.TabIndex = 0;
			this.GroupBIPConnect.TabStop = false;
			this.GroupBIPConnect.Text = "激光设备连接";
			this.LBIP.AutoSize = true;
			this.LBIP.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LBIP.Location = new Point(21, 30);
			this.LBIP.Name = "LBIP";
			this.LBIP.Size = new Size(63, 14);
			this.LBIP.TabIndex = 0;
			this.LBIP.Text = "IP地址：";
			this.LBPort.AutoSize = true;
			this.LBPort.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LBPort.Location = new Point(21, 68);
			this.LBPort.Name = "LBPort";
			this.LBPort.Size = new Size(63, 14);
			this.LBPort.TabIndex = 1;
			this.LBPort.Text = "端口号：";
			this.TxtIP.Location = new Point(90, 29);
			this.TxtIP.Name = "TxtIP";
			this.TxtIP.Size = new Size(223, 21);
			this.TxtIP.TabIndex = 2;
			this.TxtPort.Location = new Point(90, 67);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.Size = new Size(223, 21);
			this.TxtPort.TabIndex = 3;
			this.BTConnect.Location = new Point(248, 105);
			this.BTConnect.Name = "BTConnect";
			this.BTConnect.Size = new Size(65, 28);
			this.BTConnect.TabIndex = 4;
			this.BTConnect.Text = "连接";
			this.BTConnect.UseVisualStyleBackColor = true;
			this.BTConnect.Click += new EventHandler(this.BTConnect_Click);
			this.GroupBMode.Controls.Add(this.BTModeInitialization);
			this.GroupBMode.Controls.Add(this.TxtModeName);
			this.GroupBMode.Controls.Add(this.LbMode);
			this.GroupBMode.Location = new Point(0, 145);
			this.GroupBMode.Name = "GroupBMode";
			this.GroupBMode.Size = new Size(338, 116);
			this.GroupBMode.TabIndex = 1;
			this.GroupBMode.TabStop = false;
			this.GroupBMode.Text = "模板初始化";
			this.BTModeInitialization.Location = new Point(248, 71);
			this.BTModeInitialization.Name = "BTModeInitialization";
			this.BTModeInitialization.Size = new Size(65, 28);
			this.BTModeInitialization.TabIndex = 7;
			this.BTModeInitialization.Text = "初始化";
			this.BTModeInitialization.UseVisualStyleBackColor = true;
			this.BTModeInitialization.Click += new EventHandler(this.BTModeInitialization_Click);
			this.TxtModeName.Location = new Point(90, 28);
			this.TxtModeName.Name = "TxtModeName";
			this.TxtModeName.Size = new Size(223, 21);
			this.TxtModeName.TabIndex = 6;
			this.LbMode.AutoSize = true;
			this.LbMode.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LbMode.Location = new Point(12, 29);
			this.LbMode.Name = "LbMode";
			this.LbMode.Size = new Size(77, 14);
			this.LbMode.TabIndex = 5;
			this.LbMode.Text = "模板名为：";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(344, 271);
			base.Controls.Add(this.GroupBMode);
			base.Controls.Add(this.GroupBIPConnect);
			base.Name = "TCPConnectFrm";
			this.Text = "连接激光打印设备";
			this.GroupBIPConnect.ResumeLayout(false);
			this.GroupBIPConnect.PerformLayout();
			this.GroupBMode.ResumeLayout(false);
			this.GroupBMode.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
