using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UnicomTool;
namespace DASH_Video_Hairpin_Tool
{
	public class Form1 : Form
	{
		private IContainer components = null;
		private Label label2;
		private Button btn_flush;
		private ComboBox cmbReaders;
		private GroupBox GroupBCardReader;
		private GroupBox gpFileConfig;
		private Button BTStart;
		private Button btnPrg;
		private Button btnMCA;
		private TextBox txtPrgPath;
		private TextBox txtMCAPath;
		private OpenFileDialog OpenFileDlgMca;
		private OpenFileDialog OpenFileDlgPrg;
		private RichTextBox TextBResult;
		private Label LbMode;
		private GroupBox GroupBTCP;
		private TextBox TxtPort;
		private TextBox TxtIP;
		private Label LBPort;
		private Label LBIP;
		private Label LBTime;
		private TextBox TxtTime;
		private ComboBox CombMode;
		private static PCSC pcscer = new PCSC();
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
			this.label2 = new Label();
			this.btn_flush = new Button();
			this.cmbReaders = new ComboBox();
			this.GroupBCardReader = new GroupBox();
			this.gpFileConfig = new GroupBox();
			this.CombMode = new ComboBox();
			this.LbMode = new Label();
			this.BTStart = new Button();
			this.btnPrg = new Button();
			this.btnMCA = new Button();
			this.txtPrgPath = new TextBox();
			this.txtMCAPath = new TextBox();
			this.OpenFileDlgMca = new OpenFileDialog();
			this.OpenFileDlgPrg = new OpenFileDialog();
			this.TextBResult = new RichTextBox();
			this.GroupBTCP = new GroupBox();
			this.TxtTime = new TextBox();
			this.LBTime = new Label();
			this.TxtPort = new TextBox();
			this.TxtIP = new TextBox();
			this.LBPort = new Label();
			this.LBIP = new Label();
			this.GroupBCardReader.SuspendLayout();
			this.gpFileConfig.SuspendLayout();
			this.GroupBTCP.SuspendLayout();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label2.Location = new Point(8, 36);
			this.label2.Name = "label2";
			this.label2.Size = new Size(77, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "选择读卡器：";
			this.btn_flush.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.btn_flush.Location = new Point(447, 33);
			this.btn_flush.Name = "btn_flush";
			this.btn_flush.Size = new Size(90, 20);
			this.btn_flush.TabIndex = 9;
			this.btn_flush.Text = "刷新";
			this.btn_flush.UseVisualStyleBackColor = true;
			this.btn_flush.Click += new EventHandler(this.btn_flush_Click);
			this.cmbReaders.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.cmbReaders.FormattingEnabled = true;
			this.cmbReaders.Location = new Point(97, 33);
			this.cmbReaders.Name = "cmbReaders";
			this.cmbReaders.Size = new Size(344, 20);
			this.cmbReaders.TabIndex = 7;
			this.GroupBCardReader.Controls.Add(this.cmbReaders);
			this.GroupBCardReader.Controls.Add(this.label2);
			this.GroupBCardReader.Controls.Add(this.btn_flush);
			this.GroupBCardReader.Location = new Point(4, 1);
			this.GroupBCardReader.Name = "GroupBCardReader";
			this.GroupBCardReader.Size = new Size(557, 73);
			this.GroupBCardReader.TabIndex = 11;
			this.GroupBCardReader.TabStop = false;
			this.GroupBCardReader.Text = "配置读卡器";
			this.gpFileConfig.Controls.Add(this.CombMode);
			this.gpFileConfig.Controls.Add(this.LbMode);
			this.gpFileConfig.Controls.Add(this.BTStart);
			this.gpFileConfig.Controls.Add(this.btnPrg);
			this.gpFileConfig.Controls.Add(this.btnMCA);
			this.gpFileConfig.Controls.Add(this.txtPrgPath);
			this.gpFileConfig.Controls.Add(this.txtMCAPath);
			this.gpFileConfig.Location = new Point(4, 148);
			this.gpFileConfig.Name = "gpFileConfig";
			this.gpFileConfig.Size = new Size(557, 126);
			this.gpFileConfig.TabIndex = 12;
			this.gpFileConfig.TabStop = false;
			this.gpFileConfig.Text = "文件配置";
			this.CombMode.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.CombMode.FormattingEnabled = true;
			this.CombMode.Location = new Point(97, 21);
			this.CombMode.Name = "CombMode";
			this.CombMode.Size = new Size(344, 20);
			this.CombMode.TabIndex = 16;
			this.LbMode.AutoSize = true;
			this.LbMode.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LbMode.Location = new Point(8, 22);
			this.LbMode.Name = "LbMode";
			this.LbMode.Size = new Size(91, 14);
			this.LbMode.TabIndex = 15;
			this.LbMode.Text = "打印模板为：";
			this.BTStart.Location = new Point(485, 58);
			this.BTStart.Name = "BTStart";
			this.BTStart.Size = new Size(60, 56);
			this.BTStart.TabIndex = 14;
			this.BTStart.Text = "开始";
			this.BTStart.UseVisualStyleBackColor = true;
			this.BTStart.Click += new EventHandler(this.BTStart_Click);
			this.btnPrg.Location = new Point(6, 89);
			this.btnPrg.Name = "btnPrg";
			this.btnPrg.Size = new Size(79, 25);
			this.btnPrg.TabIndex = 4;
			this.btnPrg.Text = "Prg文件";
			this.btnPrg.UseVisualStyleBackColor = true;
			this.btnPrg.Click += new EventHandler(this.btnPrg_Click);
			this.btnMCA.Location = new Point(6, 58);
			this.btnMCA.Name = "btnMCA";
			this.btnMCA.Size = new Size(79, 23);
			this.btnMCA.TabIndex = 4;
			this.btnMCA.Text = "MCA数据文件";
			this.btnMCA.UseVisualStyleBackColor = true;
			this.btnMCA.Click += new EventHandler(this.btnMCA_Click);
			this.txtPrgPath.Location = new Point(97, 93);
			this.txtPrgPath.Name = "txtPrgPath";
			this.txtPrgPath.Size = new Size(370, 21);
			this.txtPrgPath.TabIndex = 3;
			this.txtMCAPath.Location = new Point(97, 58);
			this.txtMCAPath.Name = "txtMCAPath";
			this.txtMCAPath.Size = new Size(370, 21);
			this.txtMCAPath.TabIndex = 3;
			this.OpenFileDlgMca.FileName = "openFileDialog1";
			this.OpenFileDlgPrg.FileName = "openFileDialog1";
			this.TextBResult.Location = new Point(4, 280);
			this.TextBResult.Name = "TextBResult";
			this.TextBResult.Size = new Size(557, 175);
			this.TextBResult.TabIndex = 14;
			this.TextBResult.Text = "";
			this.GroupBTCP.Controls.Add(this.TxtTime);
			this.GroupBTCP.Controls.Add(this.LBTime);
			this.GroupBTCP.Controls.Add(this.TxtPort);
			this.GroupBTCP.Controls.Add(this.TxtIP);
			this.GroupBTCP.Controls.Add(this.LBPort);
			this.GroupBTCP.Controls.Add(this.LBIP);
			this.GroupBTCP.Location = new Point(4, 80);
			this.GroupBTCP.Name = "GroupBTCP";
			this.GroupBTCP.Size = new Size(557, 62);
			this.GroupBTCP.TabIndex = 15;
			this.GroupBTCP.TabStop = false;
			this.GroupBTCP.Text = "设置打印设备IP";
			this.TxtTime.Location = new Point(485, 28);
			this.TxtTime.Name = "TxtTime";
			this.TxtTime.Size = new Size(64, 21);
			this.TxtTime.TabIndex = 9;
			this.LBTime.AutoSize = true;
			this.LBTime.Location = new Point(370, 31);
			this.LBTime.Name = "LBTime";
			this.LBTime.Size = new Size(113, 12);
			this.LBTime.TabIndex = 8;
			this.LBTime.Text = "打印延时（毫秒）：";
			this.TxtPort.Location = new Point(283, 28);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.Size = new Size(81, 21);
			this.TxtPort.TabIndex = 7;
			this.TxtIP.Location = new Point(64, 28);
			this.TxtIP.Name = "TxtIP";
			this.TxtIP.Size = new Size(144, 21);
			this.TxtIP.TabIndex = 6;
			this.LBPort.AutoSize = true;
			this.LBPort.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LBPort.Location = new Point(214, 31);
			this.LBPort.Name = "LBPort";
			this.LBPort.Size = new Size(63, 14);
			this.LBPort.TabIndex = 5;
			this.LBPort.Text = "端口号：";
			this.LBIP.AutoSize = true;
			this.LBIP.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.LBIP.Location = new Point(6, 29);
			this.LBIP.Name = "LBIP";
			this.LBIP.Size = new Size(63, 14);
			this.LBIP.TabIndex = 4;
			this.LBIP.Text = "IP地址：";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
//			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(565, 461);
			base.Controls.Add(this.GroupBTCP);
			base.Controls.Add(this.TextBResult);
			base.Controls.Add(this.gpFileConfig);
			base.Controls.Add(this.GroupBCardReader);
			base.Name = "Form1";
			this.Text = "视频项目模组发卡工具";
			base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
			this.GroupBCardReader.ResumeLayout(false);
			this.GroupBCardReader.PerformLayout();
			this.gpFileConfig.ResumeLayout(false);
			this.gpFileConfig.PerformLayout();
			this.GroupBTCP.ResumeLayout(false);
			this.GroupBTCP.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form1()
		{
			this.InitializeComponent();
			this.AddMode("", true);
		}
		private void btn_flush_Click(object sender, EventArgs e)
		{
			this.cmbReaders.Items.Clear();
			this.GetListOfReaders();
		}
		private void GetListOfReaders()
		{
			StringBuilder Readers = new StringBuilder(2048);
			string SReader = "";
			int i = 1;
			long R = Form1.pcscer.PCSCListOfReader(Readers);
			for (int j = 0; j < Readers.Length; j++)
			{
				char t = Readers[j];
				if (t == ',')
				{
					if (i == 1)
					{
						publicConst.hhcardname1 = SReader;
						i++;
					}
					else
					{
						publicConst.hhcardname2 = SReader;
					}
					this.cmbReaders.Items.Add(SReader);
					SReader = "";
				}
				else
				{
					SReader += t.ToString();
				}
			}
			if (this.cmbReaders.Items.Count != 0)
			{
				try
				{
					this.cmbReaders.SelectedIndex = 0;
					PCSC.ReaderN = this.cmbReaders.SelectedIndex + 1;
				}
				catch
				{
					MessageBox.Show("读卡器选择错误");
				}
			}
			else
			{
				this.cmbReaders.Text = "";
			}
		}
		private void btnMCA_Click(object sender, EventArgs e)
		{
			this.OpenFileDlgMca.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			this.OpenFileDlgMca.Multiselect = true;
			this.OpenFileDlgMca.Title = "选择ICCID文件";
			this.OpenFileDlgMca.DefaultExt = "打开MCA文件(*.mca)|*.mca|所有文件(*.*)|*.*";
			this.txtMCAPath.Text = "";
			if (this.OpenFileDlgMca.ShowDialog() == DialogResult.OK)
			{
				this.txtMCAPath.Text = this.OpenFileDlgMca.FileName;
			}
		}
		private void btnPrg_Click(object sender, EventArgs e)
		{
			this.OpenFileDlgPrg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			this.OpenFileDlgPrg.Multiselect = true;
			this.OpenFileDlgPrg.Title = "选择PRG脚本文件";
			this.OpenFileDlgPrg.DefaultExt = "打开MCA文件(*.prg)|*.prg|所有文件(*.*)|*.*";
			this.txtPrgPath.Text = "";
			if (this.OpenFileDlgPrg.ShowDialog() == DialogResult.OK)
			{
				this.txtPrgPath.Text = this.OpenFileDlgPrg.FileName;
			}
		}
		private void BTStart_Click(object sender, EventArgs e)
		{
			if (this.CombMode.Text == "")
			{
				MessageBox.Show("请选择打印模板！！");
			}
			else
			{
				int Ir = this.AddMode(this.CombMode.Text.Trim(), false);
				if (Ir == 0)
				{
					if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DSNstart.txt"))
					{
						MessageBox.Show("目录下无DSNstart.txt文件，请新建并设置起始DSN号！！");
					}
					else
					{
						if (this.TxtIP.Text == "" || this.TxtPort.Text == "")
						{
							MessageBox.Show("请选择填写IP地址、端口号！！");
						}
						else
						{
							if (this.TxtTime.Text == "")
							{
								MessageBox.Show("请输入延时时间！！");
							}
							else
							{
								if (this.txtMCAPath.Text == "" || !File.Exists(this.txtMCAPath.Text))
								{
									MessageBox.Show("请选择MCA文件！！");
								}
								else
								{
									if (this.txtPrgPath.Text == "" || !File.Exists(this.txtPrgPath.Text))
									{
										MessageBox.Show("请选择prg脚本！！");
									}
									else
									{
										if (!(this.BTStart.Text == "停止"))
										{
											if (this.cmbReaders.Text == "")
											{
												MessageBox.Show("请选择读卡器！！");
												return;
											}
											short lgRet = 0;
											string strRet = string.Empty;
											Form1.pcscer.Reader_OpenPort();
											Form1.pcscer.Reader_CardReset(publicConst.hhcard1, ref lgRet, ref strRet, publicConst.hhcardname1);
											if (lgRet != 0)
											{
												MessageBox.Show("读卡器复位失败！！");
												return;
											}
											IPAddress ip = IPAddress.Parse(this.TxtIP.Text.Trim());
											string sendMessage = "";
											Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
											try
											{
												clientSocket.Connect(new IPEndPoint(ip, (int)short.Parse(this.TxtPort.Text.Trim())));
												Thread.Sleep((int)short.Parse(this.TxtTime.Text.Trim()));
												sendMessage = "0x02+$Initialize_" + this.CombMode.Text.Trim() + "+0x03";
												string strRetMessage = this.AsynSend(clientSocket, sendMessage);
												if (string.Compare(strRetMessage, "0x02+$Initialize_ ERROR +0x03", true) == 0 || strRetMessage == null)
												{
													MessageBox.Show("初始化模板失败！");
													clientSocket.Shutdown(SocketShutdown.Both);
													clientSocket.Close();
													goto IL_818;
												}
											}
											catch
											{
												MessageBox.Show("连接激光打印机失败！");
												clientSocket.Shutdown(SocketShutdown.Both);
												clientSocket.Close();
												goto IL_818;
											}
											bool IfNewData = true;
											Dictionary<string, string> DicMData = new Dictionary<string, string>();
											string strWr = string.Empty;
											string strNextData = string.Empty;
											try
											{
												while (true)
												{
													long lngRes = Form1.pcscer.Reader_OpenPort();
													if (lngRes == 0L)
													{
														this.TextBResult.BackColor = Color.Yellow;
														this.TextBResult.Text = "--------------------发卡中，请勿拔卡-----------------------";
														Application.DoEvents();
														this.BTStart.Text = "停止";
														strWr = "";
														if (IfNewData)
														{
															DicMData.Clear();
															DicMData = this.GetMcaData(this.txtMCAPath.Text, ref strNextData);
															if (DicMData == null)
															{
																break;
															}
														}
														foreach (string ky in DicMData.Keys)
														{
															strWr = strWr + DicMData[ky] + ",";
														}
														int Iret = this.HairpinWriteData(DicMData, this.txtPrgPath.Text);
														if (Iret != 0)
														{
															if (Iret == -5)
															{
																goto Block_27;
															}
															IfNewData = false;
														}
														else
														{
															this.WriteDSNFile(strNextData);
															string strPrintData = "";
															foreach (string ky in DicMData.Keys)
															{
																if (ky.Length > 8)
																{
																	if (ky.Substring(0, 8) == "打印数据")
																	{
																		strPrintData = strPrintData + DicMData[ky] + ",";
																	}
																}
															}
															try
															{
																sendMessage = "0x02+$Data_" + strPrintData.Trim(new char[]
																{
																	','
																}) + "+0x03";
																string strRetMessage = this.AsynSend(clientSocket, sendMessage);
																if (string.Compare(strRetMessage, "0x02+$Receive_Error +0x03", true) == 0 || strRetMessage == null)
																{
																	MessageBox.Show("发送打标数据失败！" + sendMessage);
																	this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "个人化后补卡数据.mca", strWr.Trim(new char[]
																	{
																		','
																	}), false);
																	clientSocket.Shutdown(SocketShutdown.Both);
																	clientSocket.Close();
																	break;
																}
																sendMessage = "0x02+$MarkStart_+0x03";
																strRetMessage = this.AsynSend(clientSocket, sendMessage);
																if (string.Compare(strRetMessage, "0x02+$MarkStart_ERROR+0x03", true) == 0 || strRetMessage == null)
																{
																	MessageBox.Show("发送打标指令失败！");
																	this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "个人化后补卡数据.mca", strWr.Trim(new char[]
																	{
																		','
																	}), false);
																	clientSocket.Shutdown(SocketShutdown.Both);
																	clientSocket.Close();
																	break;
																}
															}
															catch
															{
																this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "个人化后补卡数据.mca", strWr.Trim(new char[]
																{
																	','
																}), false);
																MessageBox.Show("打标失败！" + sendMessage);
																clientSocket.Shutdown(SocketShutdown.Both);
																clientSocket.Close();
																break;
															}
															this.TextBResult.BackColor = Color.Green;
															this.TextBResult.Text = "--------------------发卡成功-----------------------";
															this.TextBResult.Text = this.TextBResult.Text + "\n\r" + Form1.Ascii2Str(DicMData["DSN"]);
															this.TextBResult.Select(48, 17);
															this.TextBResult.SelectionFont = new Font("Tahoma", 26f, FontStyle.Bold);
															this.BTStart.Text = "开始";
															Application.DoEvents();
															int It = this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "Log.log", DicMData["DSN"] + ":发卡成功", true);
															if (It != 0)
															{
																break;
															}
														}
														long lngR;
														do
														{
															short intRL = 0;
															string strRes = "";
															lngR = (long)Form1.pcscer.Reader_CardReset(ref intRL, ref strRes);
														}
														while (lngR == 0L);
													}
												}
												goto IL_818;
												Block_27:
												this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "FailLog.log", "发卡失败:" + strWr.Trim(new char[]
												{
													','
												}), false);
											}
											catch (Exception e2)
											{
												MessageBox.Show("发卡失败！" + e2.Message);
											}
											finally
											{
											}
										}
										IL_818:
										this.BTStart.Text = "开始";
										this.TextBResult.BackColor = Color.White;
										this.TextBResult.Text = "";
									}
								}
							}
						}
					}
				}
			}
		}
		public string AsynSend(Socket socket, string message)
		{
			string result;
			if (socket == null || message == string.Empty)
			{
				result = null;
			}
			else
			{
				byte[] data = Encoding.UTF8.GetBytes(message);
				string strRMessage = null;
				try
				{
					socket.Send(Encoding.ASCII.GetBytes(message));
					Thread.Sleep((int)short.Parse(this.TxtTime.Text.Trim()));
					int receiveLength = socket.Receive(data);
					strRMessage = Encoding.ASCII.GetString(data, 0, receiveLength);
				}
				catch (Exception ex)
				{
					MessageBox.Show("发送消息出现异常！", ex.Message);
					result = null;
					return result;
				}
				finally
				{
				}
				result = strRMessage;
			}
			return result;
		}
		private int AddMode(string strD, bool IfAdd)
		{
			int Iret = 0;
			bool IfWrite = true;
			try
			{
				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini"))
				{
					StreamReader rd = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini", Encoding.Default);
					for (string strM = rd.ReadLine(); strM != null; strM = rd.ReadLine())
					{
						if (strM.Trim() != "")
						{
							if (strM.Trim() == strD)
							{
								IfWrite = false;
							}
							if (IfAdd)
							{
								this.CombMode.Items.Add(strM.Trim());
							}
						}
					}
					rd.Close();
				}
				if (IfWrite && strD.Trim() != "")
				{
					StreamWriter wr = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini", true, Encoding.Default);
					wr.WriteLine(strD.Trim());
					wr.Close();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("加入打印模板失败！" + e.Message);
				Iret = -1;
			}
			finally
			{
			}
			return Iret;
		}
		public static string Ascii2Str(string strD)
		{
			if (strD.Length % 2 != 0)
			{
				throw new Exception(strD + "长度不正确");
			}
			string strR = "";
			for (int i = 0; i < strD.Length / 2; i++)
			{
				int asciiCode = Convert.ToInt32(strD.Substring(i * 2, 2), 16);
				if (asciiCode < 0 || asciiCode > 255)
				{
					throw new Exception("ASCII Code is not valid.");
				}
				ASCIIEncoding asciiEncoding = new ASCIIEncoding();
				byte[] byteArray = new byte[]
				{
					(byte)asciiCode
				};
				string strCharacter = asciiEncoding.GetString(byteArray);
				strR += strCharacter;
			}
			return strR;
		}
		private int HairpinWriteData(Dictionary<string, string> DicData, string FilePath)
		{
			int Irt = 0;
			short intRL = 0;
			string strRes = "";
			long lngRes = (long)Form1.pcscer.Reader_CardReset(ref intRL, ref strRes);
			int result;
			if (lngRes != 0L)
			{
				MessageBox.Show("复位失败！！");
				this.TextBResult.BackColor = Color.Red;
				this.TextBResult.Text = "--------------------卡片复位失败-----------------------";
				this.BTStart.Text = "开始";
				Application.DoEvents();
				result = -1;
			}
			else
			{
				StreamReader rdPrg = new StreamReader(FilePath);
				string strOrder = rdPrg.ReadLine();
				try
				{
					while (strOrder != null)
					{
						strOrder = strOrder.Replace(" ", "");
						if (strOrder.IndexOf("<") > 0)
						{
							string strVar = strOrder.Substring(strOrder.IndexOf("<") + 1, strOrder.IndexOf(">") - strOrder.IndexOf("<") - 1);
							if (!DicData.ContainsKey(strVar))
							{
								MessageBox.Show(strVar + "数据中无此变量数据！！");
								this.TextBResult.BackColor = Color.Red;
								this.TextBResult.Text = "--------------------数据和脚本不匹配-----------------------";
								this.BTStart.Text = "开始";
								rdPrg.Close();
								Application.DoEvents();
								result = -5;
								return result;
							}
							strOrder = strOrder.Replace("<" + strVar + ">", DicData[strVar]);
						}
						string strSend = strOrder.Substring(0, strOrder.IndexOf("SW"));
						string strS = strOrder.Substring(strOrder.IndexOf("SW") + 2);
						string strSW = strS;
						if (strS.IndexOf("RESULT") > 0)
						{
							strSW = strS.Substring(0, strS.IndexOf("RESULT"));
							string strResult = strS.Substring(strS.IndexOf("RESULT") + 6);
						}
						string strR = string.Empty;
						string strRsw = string.Empty;
						if (strSend == "0012000000")
						{
							lngRes = (long)Form1.pcscer.Reader_CardReset(ref intRL, ref strRes);
							if (lngRes != 0L)
							{
								MessageBox.Show("复位失败！！");
								this.TextBResult.BackColor = Color.Red;
								this.TextBResult.Text = "--------------------卡片复位失败-----------------------";
								this.BTStart.Text = "开始";
								rdPrg.Close();
								Application.DoEvents();
								result = -1;
								return result;
							}
						}
						else
						{
							long Iret = (long)Form1.pcscer.Reader_SendCommand(ref strSend, ref strR, ref strRsw);
							if (Iret < 0L)
							{
								MessageBox.Show(strSend + "发卡失败！！");
								goto IL_32B;
							}
							if (strRsw != strSW)
							{
								MessageBox.Show(strSend + "发卡失败！！");
								goto IL_32B;
							}
						}
						strOrder = rdPrg.ReadLine();
					}
				}
				catch (Exception e2_312)
				{
					goto IL_32B;
				}
				finally
				{
					rdPrg.Close();
				}
				result = Irt;
				return result;
				IL_32B:
				rdPrg.Close();
				this.TextBResult.BackColor = Color.Red;
				this.TextBResult.Text = "--------------------发卡失败-----------------------";
				this.BTStart.Text = "开始";
				Application.DoEvents();
				this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + "FailLog.log", "发卡失败:" + DicData["DSN"] + "--" + strOrder, false);
				result = -1;
			}
			return result;
		}
		private int WriteToLog(string FilePath, string strT, bool IfRepeat)
		{
			int result;
			if (IfRepeat && strT != "")
			{
				if (File.Exists(FilePath))
				{
					StreamReader rd = new StreamReader(FilePath);
					for (string strTp = rd.ReadLine(); strTp != null; strTp = rd.ReadLine())
					{
						if (strTp.Trim() != "")
						{
							if (strTp.Split(new char[]
							{
								':'
							})[0] == strT.Split(new char[]
							{
								':'
							})[0])
							{
								MessageBox.Show(strT.Split(new char[]
								{
									':'
								})[0] + "重复发卡！！");
								result = -1;
								return result;
							}
						}
					}
					rd.Close();
				}
			}
			StreamWriter wr = new StreamWriter(FilePath, true, Encoding.Default);
			wr.WriteLine(strT);
			wr.Close();
			result = 0;
			return result;
		}
		private Dictionary<string, string> GetMcaData(string FilePath, ref string strNextData)
		{
			Dictionary<string, string> DicData = new Dictionary<string, string>();
			StreamReader rd = new StreamReader(this.txtMCAPath.Text);
			StreamReader rdDsn = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DSNstart.txt");
			Dictionary<string, string> result;
			try
			{
				string strDsn = rdDsn.ReadLine();
				if (strDsn == null)
				{
					MessageBox.Show("DSN记录文件为空！");
					rd.Close();
					rdDsn.Close();
					result = null;
					return result;
				}
				if (strDsn.Trim() == "" || strDsn.IndexOf(":") <= 0)
				{
					MessageBox.Show("DSN记录文件格式不正确！");
					rd.Close();
					rdDsn.Close();
					result = null;
					return result;
				}
				strDsn = strDsn.Trim().Split(new char[]
				{
					':'
				})[1].Trim();
				string strHead = rd.ReadLine();
				string strTemp = rd.ReadLine();
				if (strTemp.Trim() == "")
				{
					MessageBox.Show("MCA文件有空行！");
					rd.Close();
					rdDsn.Close();
					result = null;
					return result;
				}
				if (strHead.Split(new char[]
				{
					','
				}).Length != strTemp.Split(new char[]
				{
					','
				}).Length)
				{
					MessageBox.Show("MCA数据表头和数据不对应！");
					rd.Close();
					rdDsn.Close();
					result = null;
					return result;
				}
				if (strDsn == "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")
				{
					for (int i = 0; i < strHead.Split(new char[]
					{
						','
					}).Length; i++)
					{
						DicData.Add(strHead.Split(new char[]
						{
							','
						})[i], strTemp.Split(new char[]
						{
							','
						})[i]);
					}
					strNextData = rd.ReadLine();
				}
				else
				{
					while (strTemp != null)
					{
						if (strTemp.Trim() != "")
						{
							if (strTemp.Split(new char[]
							{
								','
							})[0] == strDsn)
							{
								for (int i = 0; i < strHead.Split(new char[]
								{
									','
								}).Length; i++)
								{
									DicData.Add(strHead.Split(new char[]
									{
										','
									})[i], strTemp.Split(new char[]
									{
										','
									})[i]);
								}
								strNextData = rd.ReadLine();
								break;
							}
						}
						strTemp = rd.ReadLine();
					}
				}
			}
			catch (Exception e2_2EF)
			{
				MessageBox.Show("MCA数据获取失败！");
				rd.Close();
				rdDsn.Close();
				result = null;
				return result;
			}
			finally
			{
				rd.Close();
				rdDsn.Close();
			}
			result = DicData;
			return result;
		}
		private void WriteDSNFile(string strDsn)
		{
			StreamReader rdDsn = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DSNstart.txt", Encoding.Default);
			if (strDsn == null)
			{
				strDsn = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
			}
			else
			{
				if (strDsn.Trim() == "")
				{
					strDsn = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
				}
				else
				{
					strDsn = strDsn.Trim().Split(new char[]
					{
						','
					})[0];
				}
			}
			try
			{
				string strT = rdDsn.ReadLine().Trim().Split(new char[]
				{
					':'
				})[0];
				rdDsn.Close();
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + "DSNstart.txt");
				StreamWriter wr = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "DSNstart.txt", false, Encoding.Default);
				wr.WriteLine(strT + ":" + strDsn.Trim());
				wr.Close();
			}
			catch
			{
				rdDsn.Close();
				throw new Exception("记录DSN值失败！！");
			}
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Form1.pcscer.Reader_ClosePort();
			Environment.Exit(0);
		}
	}
}
