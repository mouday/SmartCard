using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace UnicomTool
{
	internal class PCSC
	{
		public static string ReaderType;
		public static long MWicdev;
		public static long PortSpeed;
		public static string Port;
		public static int ReaderN;
		[DllImport("Crwicc.dll")]
		public static extern long TripleDESVB(long DESType, string TripleDESKey, int SourDataLen, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern long PCSCListReader(StringBuilder Readers);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_Connect(int NofReaders);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_CardReset(byte[] ATR, ref short ATRlen);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_SendCommand(byte[] Comm, int Lens, byte[] Resp, ref int Lenr);
		[DllImport("PCSCReader.dll")]
		public static extern long PCSC_Close();
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_CardReset_Ex(uint hhCard, byte[] ATR, ref short ATRlen, string hhcardname);
		[DllImport("PCSCReader.dll")]
		public static extern int BinToHexStr(string HexStr, string BinData, int BinLen);
		[DllImport("PCSCReader.dll")]
		public static extern int HexStrToBin(string BinData, string HexStr, int HexStrLen);
		[DllImport("PCSCReader.dll")]
		public static extern int SingleDESECB(int DESType, string SingleDESKey, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int TriDESECB(int DESType, string TriDESKey, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int SingleMACCBC(int MACKey, string InitData, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int TriMACCBC(int MACKey, string InitData, int SourDataType, string SourData, string DestData);
		[DllImport("MCS_SR")]
		public static extern int CPU_OpenCard(string bATR, int wATRLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_CloseCard();
		[DllImport("MCS_SR")]
		public static extern int CPU_Reset(string bATR, int wATRLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_IsoAPDU(string bCommand, int wCmdLength, string bResponse, int wRespLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_GetProtocol(byte bProtocol);
		[DllImport("MCS_SR")]
		public static extern int MCS_InitComm(byte bPort, long dwCommBaudRate);
		[DllImport("MCS_SR")]
		public static extern int MCS_ExitComm();
		[DllImport("MCS_SR")]
		public static extern int MCS_GetVersion(string bVersion);
		[DllImport("MCS_SR")]
		public static extern int MCS_TestDevice();
		[DllImport("MCS_SR")]
		public static extern int MCS_TestDoor();
		[DllImport("MCS_SR")]
		public static extern int MCS_LED(byte bOnOff);
		[DllImport("MCS_SR")]
		public static extern int MCS_Buzzer(byte bOnOff);
		[DllImport("MCS_SR")]
		public static extern int MCS_SetStringMode(byte bStringMode);
		[DllImport("kernel32")]
		public static extern long GetTickCount();
		[DllImport("WibAlgrithm.dll")]
		public static extern long GetSupperAdmin( string strSourceData,  byte[] strOutData);
		public long Reader_OpenPort()
		{
			PCSC.PortSpeed = 115200L;
			int retval = PCSC.PCSC_Connect(PCSC.ReaderN);
            //MessageBox.Show(PCSC.ReaderN.ToString());
            //MessageBox.Show(retval.ToString());
			long result;
			if (retval != 0)
			{
				result = -1L;
			}
			else
			{
				result = 0L;
			}
			return result;
		}
		public long PCSCListOfReader(StringBuilder Readers)
		{
			return PCSC.PCSCListReader(Readers);
		}
		public long Reader_CardReset(uint hhcard, ref short intReslen, ref string strRes, string hhcardname)
		{
			byte[] atr = new byte[600];
			strRes = "";
			int retval = PCSC.PCSC_CardReset_Ex(hhcard, atr, ref intReslen, hhcardname);
			strRes = Encoding.ASCII.GetString(atr);
			long result;
			if (retval != 0)
			{
				result = 1L;
			}
			else
			{
				result = (long)retval;
			}
			return result;
		}
		public int Reader_CardReset(ref short intReslen, ref string strRes)
		{
			byte[] TstrRes = new byte[600];
			int retval = PCSC.PCSC_Connect(PCSC.ReaderN);
			strRes = "";
			int result;
			if (retval != 0)
			{
				result = -1;
			}
			else
			{
				try
				{
					retval = PCSC.PCSC_CardReset(TstrRes, ref intReslen);
				}
				catch (Exception e_3A)
				{
					result = 0;
					return result;
				}
				if (retval != 0)
				{
					result = -3;
				}
				else
				{
					strRes = Encoding.ASCII.GetString(TstrRes, 0, (int)(intReslen * 2));
					result = 0;
				}
			}
			return result;
		}
		public int Reader_SendCommand(ref string strCmd, ref string strRes, ref string strSW)
		{
			byte[] TstrRes = new byte[600];
			int TlngReslen = 0;
			byte[] Tcomm = Encoding.Default.GetBytes(strCmd);
			int Lens = int.Parse((strCmd.Length / 2).ToString());
			int retval = PCSC.PCSC_SendCommand(Tcomm, Lens, TstrRes, ref TlngReslen);
			int lngReslen = TlngReslen;
			short i = 0;
			while ((int)i < lngReslen * 2)
			{
				strRes += (char)TstrRes[(int)i];
				i += 1;
			}
			strSW = retval.ToString("X");
			strSW = strSW.ToUpper();
			int result;
			if (retval < 0)
			{
				result = retval;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public void Reader_ClosePort()
		{
			PCSC.PCSC_Close();
		}
		public void TimeD(long lngTD)
		{
			long lngST = PCSC.GetTickCount();
			long lngET;
			do
			{
				Application.DoEvents();
				if (PCSC.GetTickCount() - lngST < 0L)
				{
					lngST = PCSC.GetTickCount();
				}
				lngET = PCSC.GetTickCount() - lngST;
			}
			while (lngET >= lngTD);
		}
		public long HexToDec(string strS)
		{
			int i = strS.Length;
			long tmp = 0L;
			long tmpDec = 0L;
			byte[] array = new byte[1];
			int j = 1;
			while (j < i + 1)
			{
				string tmps = strS.Substring(j, 1);
				string text = tmps;
				switch (text)
				{
				case "0":
					tmp = 0L;
					break;
				case "1":
					tmp = 1L;
					break;
				case "2":
					tmp = 2L;
					break;
				case "3":
					tmp = 3L;
					break;
				case "4":
					tmp = 4L;
					break;
				case "5":
					tmp = 5L;
					break;
				case "6":
					tmp = 6L;
					break;
				case "7":
					tmp = 7L;
					break;
				case "8":
					tmp = 8L;
					break;
				case "9":
					tmp = 9L;
					break;
				case "a":
					tmp = 10L;
					break;
				case "A":
					tmp = 10L;
					break;
				case "b":
					tmp = 11L;
					break;
				case "B":
					tmp = 11L;
					break;
				case "c":
					tmp = 12L;
					break;
				case "C":
					tmp = 12L;
					break;
				case "d":
					tmp = 13L;
					break;
				case "D":
					tmp = 13L;
					break;
				case "e":
					tmp = 14L;
					break;
				case "E":
					tmp = 14L;
					break;
				case "f":
					tmp = 15L;
					break;
				case "F":
					tmp = 15L;
					break;
				}
				//IL_25B:
				array = Encoding.ASCII.GetBytes(tmps);
				int asctmps = (int)array[0];
				if ((asctmps <= 57 && asctmps >= 48) || (asctmps <= 65 && asctmps >= 70) || (asctmps <= 102 && asctmps >= 97))
				{
					if (tmps != "0")
					{
						if (j < i)
						{
							for (int k = 1; k <= i - 1; k++)
							{
								tmp *= 16L;
							}
							tmpDec += tmp;
						}
						if (j == i)
						{
							tmpDec += tmp;
						}
					}
				}
				j++;
				continue;
				//goto IL_25B;
			}
			return tmpDec;
		}
	}
}
