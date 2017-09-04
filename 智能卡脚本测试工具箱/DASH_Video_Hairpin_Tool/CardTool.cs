using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnicomTool;
using System.Diagnostics;
using System.IO;

namespace DASH_Video_Hairpin_Tool
{
    public partial class CardTool : Form
    {
        private static PCSC pcscer = new PCSC();
        DateTime dt = new DateTime();
        public CardTool()
        {
            InitializeComponent();
        }

        private void ClearCard_Load(object sender, EventArgs e)
        {
            this.GetListOfReaders();
            this.rdo2FE2.Checked = true;
            this.rdo2FE2.Visible = false;
            this.rdo2F02.Visible = false;
            this.lblResult.Text = "";
         
            this.cmbMcaMode.Items.Add("无数据清卡");
            this.cmbMcaMode.Items.Add("有数据清卡");
            this.cmbMcaMode.Items.Add("预个人化");
            this.cmbMcaMode.Items.Add("个人化");
            this.cmbMcaMode.SelectedIndex = 0;

            this.cmbPrgMode.Items.Add("2FE2");
            this.cmbPrgMode.Items.Add("2F02");
            this.cmbPrgMode.SelectedIndex = 0;
        }
        private void GetListOfReaders()
        {
            StringBuilder Readers = new StringBuilder(2048);
            string SReader = "";
            int i = 1;
            long R = CardTool.pcscer.PCSCListOfReader(Readers);
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

        private void btnReFresh_Click(object sender, EventArgs e)
        {
            this.cmbReaders.Items.Clear();
            this.GetListOfReaders();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //选择读卡器

            if (this.cmbReaders.Text == "")
            {
                MessageBox.Show("请选择读卡器！！");
                return;
            }
            if (this.txtPrg.Text == "")
            {
                MessageBox.Show("请选择脚本！！");
                return;
            }
            bool btn = false;       //开始停止开关
            if (this.btnStart.Text == "开始")
            {
                this.btnStart.Text = "停止";
                btn = true;
            }
            else //if (this.btnStart.Text == "停止")
            {
                this.btnStart.Text = "开始";
                btn = false;             
                this.lblResult.BackColor = this.BackColor;
                this.lblResult.Text = "请点击开始"; 
                CardTool.pcscer.Reader_ClosePort();
                return;
            }
            
            Application.DoEvents();
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;
           // ret=ClearCard.pcscer.Reader_OpenPort();
          
           // MessageBox.Show("ret=" + ret);
           
            //ret=ClearCard.pcscer.Reader_CardReset(ref lgRet, ref strRet);

            //MessageBox.Show("ret=" + ret + "\nstrRet=" + strRet + "lgRet=" + lgRet);
            
            //if (lgRet != 0)
            //{
            //    MessageBox.Show("读卡器复位失败！！");
            //    return;
            //}
            //else
            //{
            //    //MessageBox.Show(strRet);
            //}
            
            //读取iccid
            PCSC.ReaderN = this.cmbReaders.SelectedIndex + 1;
            string mode = "";
            mode = this.cmbPrgMode.Text;
            //MessageBox.Show(mode);
            //if (rdo2F02.Checked == true)
            //{
            //    mode = "2F02";
            //}
            //else if (rdo2FE2.Checked == true)
            //{
            //    mode = "2FE2";
            //}
           
            //查找iccid对应的admb
            if (this.cmbMcaMode.Text == "有数据清卡" & btn == true)
            {
                if (this.txtMca.Text == "")
                {
                    MessageBox.Show("请选择数据！！");
                    return;
                }

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict = MCAhandler.getAMDB(txtMca.Text);


            clearnext:
                long lngR = 0;
                short intRL = 0;
                string strRes = "";
                do
                {
                    this.lblResult.BackColor = this.BackColor;
                    this.lblResult.Text = "请插入卡片";
                    Application.DoEvents();

                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR == 0)
                    {
                        break;
                    }
                    
                }
                
                while (true);
                if (btn == false)
                    {
                        return;
                    }
                this.lblResult.BackColor = Color.Yellow;
                this.lblResult.Text = "清卡中，请勿拔插";
                Application.DoEvents();
                string iccid = "";
                iccid = runPCSC.readICCID(PCSC.ReaderN, mode);
                lblResult.Text = iccid;
                string admb = "";
                if (dict.ContainsKey(iccid))
                {
                    admb = dict[iccid];
                }
                else
                {
                    this.lblResult.Text = "ICCID:" + iccid + "  未查询到ADMB";
                    this.lblResult.BackColor = Color.Red;
                    return;
                }
                //执行脚本
                string result = "";
                result = runPCSC.clearCard(txtPrg.Text, admb);
                
                if (result == "清卡成功")
                {
                    this.lblResult.BackColor = Color.Green;
                    this.lblResult.Text = result;
                    
                }
                else
                {
                    this.lblResult.BackColor = Color.Red;
                    this.lblResult.Text = result;
                    return;
                }
                Application.DoEvents();

                do
                {
                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR != 0)
                    {
                        goto clearnext;
                    }
                } while (true);
            }
            if (this.cmbMcaMode.Text == "无数据清卡" & btn == true)
            {
          clearNextNonData:
                long lngR = 0;
                short intRL = 0;
                string strRes = "";
                do
                {
                    this.lblResult.BackColor = this.BackColor;
                    this.lblResult.Text = "请插入卡片";
                    Application.DoEvents();

                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR == 0)
                    {
                        break;
                    }
                    
                }
                while (true);
                if (btn == false)
                {
                    return;
                }
                this.lblResult.BackColor = Color.Yellow;
                this.lblResult.Text = "清卡中，请勿拔插";
                Application.DoEvents();
                string iccid = "";
                //读号
                iccid = runPCSC.readICCID(PCSC.ReaderN, mode);
                lblResult.Text = "ICCID: "+iccid;
                //如果是空卡则返回
                if (iccid.Substring(iccid.Length - 16, 16) == "FFFFFFFFFFFFFFFF") return;
                //获取ADMB
                string admb = WibAlgrithm.GetADMB(iccid);
                
                //执行脚本
                string result = "";
                result = runPCSC.clearCard(txtPrg.Text, admb);
                if (result == "清卡成功")
                {
                    this.lblResult.BackColor = Color.Green;
                    this.lblResult.Text = result;
                }
                else
                {
                    this.lblResult.BackColor = Color.Red;
                    this.lblResult.Text = result;
                    return;
                }
                Application.DoEvents();

                do
                {
                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR != 0)
                    {
                        goto clearNextNonData;
                    }
                } while (true);
            }
            else if (this.cmbMcaMode.Text == "预个人化" & btn == true )
            {

            PrePersonalizationnext:
                long lngR = 0;
                short intRL = 0;
                string strRes = "";
                do
                {
                    this.lblResult.BackColor = this.BackColor;
                    this.lblResult.Text = "请插入卡片";
                    Application.DoEvents();

                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR == 0)
                    {
                        break;
                    }
                } while (true);
                if (btn == false)
                {
                    return;
                }
                //Stopwatch stopWatch = new Stopwatch();
                //stopWatch.Start();
                int timeStart = System.Environment.TickCount;
                this.lblResult.BackColor = Color.Yellow;
                this.lblResult.Text = "发卡中，请勿拔插";
                Application.DoEvents();
            
                
                //执行脚本
                string result = "";
                result = runPCSC.PrePersonalization(txtPrg.Text);
                //stopWatch.Stop();
                int timeEnd = System.Environment.TickCount;
                if (result == "发卡成功")
                {
                    this.lblResult.BackColor = Color.Green;
                    this.lblResult.Text = result + "\n用时（秒）：" + (timeEnd-timeStart)/1000;
                }
                else
                {
                    this.lblResult.BackColor = Color.Red;
                    this.lblResult.Text = result;
                }
                Application.DoEvents();

                do
                {
                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR != 0)
                    {
                        goto PrePersonalizationnext;
                    }
                } while (true);
            }
            else if (this.cmbMcaMode.Text == "个人化" & btn == true)
            {
                if (this.txtMca.Text == "")
                {
                    MessageBox.Show("请选择数据！！");
                    return;
                }
                List<string[]> list = new List<string[]>(); 
                list = MCAhandler.getMca(txtMca.Text);
                int mcaLine = 0;

            Personalizationnext:
                long lngR = 0;
                short intRL = 0;
                string strRes = "";
                do
                {
                    this.lblResult.BackColor = this.BackColor;
                    this.lblResult.Text = "请插入卡片";
                    Application.DoEvents();

                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR == 0)
                    {
                        break;
                    }
                }
                while (true);
                if (btn == false)
                {
                    return;
                }
                int timeStart = System.Environment.TickCount;
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                this.lblResult.BackColor = Color.Yellow;
                this.lblResult.Text = "写卡中，请勿拔插";
                Application.DoEvents();
              //获取单条数据
                mcaLine++;
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string[] keys = list[0];
                string[] values = list[mcaLine];
                for (int i = 0; i < keys.Length; i++)
                {
                    dict.Add("<"+keys[i]+">", values[i]);
                }

                //执行脚本
                string result = "";
                result = runPCSC.Personalization(txtPrg.Text, dict);
                stopWatch.Stop();
                int timeEnd = System.Environment.TickCount;
                if (result == "写卡成功")
                {
                    this.lblResult.BackColor = Color.Green;
                    //this.lblResult.Text = result+"\n用时（秒）："+stopWatch.ElapsedTicks;
                    this.lblResult.Text = result + "\n用时（秒）：" + (timeEnd - timeStart) / 1000+
                        "\n写入卡号：" + dict["<ICCID>"];
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "个人化日志.log"),
                        DateTime.Now.ToString()+"\t"+ result + "\t用时（秒）：" + (timeEnd - timeStart) / 1000 +
                        "\t写入卡号：" + dict["<ICCID>"]+"\r\n");
                }
                else
                {
                    this.lblResult.BackColor = Color.Red;
                    this.lblResult.Text = result;
                }
                Application.DoEvents();

                do
                {
                    lngR = CardTool.pcscer.Reader_OpenPort();
                    Application.DoEvents();
                    if (lngR != 0)
                    {
                        goto Personalizationnext;
                    }
                } while (true);
            }     
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "prg脚本（*.prg）|*.prg|所有文件（*.*）|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPrg.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "mca数据（*.mca）|*.mca|所有文件（*.*）|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMca.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CardTool.pcscer.Reader_ClosePort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long ret = 0;
            ret = CardTool.pcscer.Reader_OpenPort();
            txtDebug.Text += "Reader_OpenPort:\nret=" + ret + "\n";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            short lgRet = 0;
            string strRet = string.Empty;
            long ret = 0;                    
            ret = CardTool.pcscer.Reader_CardReset(ref lgRet, ref strRet);
            txtDebug.Text += "Reader_CardReset:\n" + "ret=" + ret + "\nlgRet=" + lgRet + "\nstrRet=" + strRet + "\n";
            //MessageBox.Show("ret=" + ret + "\nstrRet=" + strRet + "\nlgRet=" + lgRet);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            List<string> cmdList = new List<string>();
            cmdList.Add("A0A40000023F00");
            cmdList.Add("A0A400000232FE2");
            string strCmd="";
            string strRes="";
            string strSW="";
            foreach (string str in cmdList)
            {
                strCmd = str;
                CardTool.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
                //MessageBox.Show("strCmd=" + strCmd + "\nstrRes=" + strRes + "\nstrSW=" + strSW);
                txtDebug.Text +=  "Reader_SendCommand:\n" + "strCmd=" + strCmd + "\nstrRes=" + strRes + "\nstrSW=" + strSW + "\n";
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict=MCAhandler.getAMDB(txtMca.Text);
            if (dict.ContainsKey("13170042080090054200"))
            {
                MessageBox.Show(dict["13170042080090054200"]);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str="0012000000SW9000RESULT3B17968112120F34C300";
            string cmd="";
            string sw="";
            string result = "";
            runPCSC.splitCMD(str,ref cmd,ref sw,ref result);
            MessageBox.Show("str=" + str + "\ncmd=" + cmd + "\nsw=" + sw + "\nresult=" + result);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string str1 = "700B107109197410";//8456CCAD7CBC13E3
           
            byte[] bytes=new byte[60];

            long lng = PCSC.GetSupperAdmin(str1,  bytes);
            string str2=Encoding.Default.GetString(bytes);
            //foreach (byte b in bytes)
            //{
            //    str2 += b;
            //}
            MessageBox.Show("str1=" + str1 + "\nstr2=" + str2 + "\nlng=" + lng);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //string str = "0012000000SW9000RESULT3B17968112120F34C300";
            string str = "A0A40000023F00SW9F17";
 
            string cmd = "";
            string sw = "";
            string result = "";
            runPCSC.splitCMD(str, ref cmd, ref sw, ref result);
           // MessageBox.Show("str=" + str + "\ncmd=" + cmd + "\nsw=" + sw + "\nresult=" + result);
            string strCmd = cmd;
            string strRes = "";
            string strSW = "";
            CardTool.pcscer.Reader_SendCommand(ref strCmd, ref  strRes, ref  strSW);
            MessageBox.Show("strCmd=" + strCmd + "\nstrRes=" + strRes + "\nstrSW=" + strSW );

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dit = new Dictionary<string, string>();
            dit.Add("<ICCID>", "1234567890");
            dit.Add("<IMSI>", "9000");

            string strcmd = "<ICCID>A0B000000ASW9000RESULT<ICCID>A0B0000009SW9000RESULT<IMSI>";
            MessageBox.Show(runPCSC.replaceParameters(strcmd, dit));
        }

        private void button12_Click(object sender, EventArgs e)
        {
           // "700B107109197410";//8456CCAD7CBC13E3
            MessageBox.Show(WibAlgrithm.GetADMB("9868204F897109001700"));
           
        }
    }
}
