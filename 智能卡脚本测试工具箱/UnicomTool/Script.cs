using System;
using System.Text;
namespace PrgTxtTransform
{
	internal class Script
	{
		private const string RESET_OUTPUT = "0012000000SW9000";
		private const int CMD_SEND = 1;
		private const int CMD_RECV = 2;
		private const int CMD_RESET = 3;
		private static StringBuilder sRemain = new StringBuilder();
		private static int iLastCMD = 0;
		public static string GetKeyword(string sLine)
		{
			string[] array = sLine.Split(new char[]
			{
				' '
			});
			return array[0];
		}
		public static string DelLeftSpace(string sLine)
		{
			int i;
			for (i = 0; i < sLine.Length; i++)
			{
				if (sLine[i] != ' ')
				{
					break;
				}
			}
			return sLine.Substring(i);
		}
		public static void ExcuteLine(string sLine, ref string sPrintLine)
		{
			string text = Script.DelLeftSpace(sLine.ToUpper().Replace("    ", " "));
			sPrintLine = "";
			if (text.Length != 0)
			{
				if (text[0] != ';')
				{
					string keyword = Script.GetKeyword(text);
					text = text.Substring(keyword.Length).Replace(" ", "");
					string text2 = keyword;
					if (text2 != null)
					{
						if (!(text2 == "SEND"))
						{
							if (!(text2 == "ASSERT"))
							{
								if (!(text2 == "RESET"))
								{
									goto IL_2A7;
								}
								switch (Script.iLastCMD)
								{
								case 1:
									sPrintLine = Script.sRemain.ToString();
									Script.sRemain.Remove(0, Script.sRemain.Length);
									break;
								case 3:
									sPrintLine = Script.sRemain.ToString();
									Script.sRemain.Remove(0, Script.sRemain.Length);
									break;
								}
								Script.sRemain.Append("0012000000SW9000");
								Script.iLastCMD = 3;
							}
							else
							{
								switch (Script.iLastCMD)
								{
								case 1:
									if (text.Length == 4)
									{
										Script.sRemain.Append("SW");
										Script.sRemain.Append(text);
									}
									else
									{
										Script.sRemain.Append("SW");
										Script.sRemain.Append(text.Substring(text.Length - 4));
										Script.sRemain.Append("RESULT");
										Script.sRemain.Append(text.Substring(0, text.Length - 4));
									}
									break;
								case 3:
									Script.sRemain.Append("RESULT");
									Script.sRemain.Append(text);
									break;
								}
								sPrintLine = Script.sRemain.ToString();
								Script.sRemain.Remove(0, Script.sRemain.Length);
								Script.iLastCMD = 2;
							}
						}
						else
						{
							switch (Script.iLastCMD)
							{
							case 1:
								sPrintLine = Script.sRemain.ToString();
								Script.sRemain.Remove(0, Script.sRemain.Length);
								break;
							case 3:
								sPrintLine = Script.sRemain.ToString();
								Script.sRemain.Remove(0, Script.sRemain.Length);
								break;
							}
							Script.sRemain.Append(text);
							Script.iLastCMD = 1;
						}
						return;
					}
					IL_2A7:
					sPrintLine = "不可识别的关键字：" + keyword;
				}
			}
		}
	}
}
