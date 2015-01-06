using Advanced_Combat_Tracker;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
// Advanced Combat Tracker - mini parse window用Plugin
// NameEn: 日本語クライアント利用時に、キャラクター名(ペット含む)を英語で出力
[assembly: AssemblyTitle("Mini Parse Pets' Name in English")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace ACTv3Plugins
{
	public class NameEnPlugin : IActPluginV1
	{
		Label statusLabel;

		private string[,] Pet = {
			 {"フェアリー・エオス","Eos"},{"フェアリー・セレネ","Selene"},{"イフリート・エギ","Ifrit-Egi"},{"ガルーダ・エギ","Garuda-Egi"},{"タイタン・エギ","Titan-Egi"},
			 {"カーバンクル・エメラルド","Emerald"},{"カーバンクル・トパーズ","Topaz"},
		};

		private bool isOneByteChar(string str)
		{
			byte [] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
			if (byte_data.Length == str.Length)	{
				return true;
			}else{
				return false;
			}
		}
		
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			statusLabel = pluginStatusText;
			CombatantData.ExportVariables.Add(
				"NameEn",
			new CombatantData.TextExportFormatter("NameEn", "Name En", "name in english", (data, extra) => {
					string name = data.GetColumnByName("Name");
					if(!(isOneByteChar(name))){
					 for( int i=0;i<Pet.Length-1;i++ ){
						 if(name.Contains(Pet[i,0])) return name.Replace(Pet[i,0],Pet[i,1]);
				 	}
				 }
				 return name;
				}));
			ActGlobals.oFormActMain.ValidateLists();
			statusLabel.Text = "Initialized.";
		}

		public void DeInitPlugin()
		{
			CombatantData.ExportVariables.Remove("NameEn");
			statusLabel.Text = "Deinitialized";
		}

	 }
}
