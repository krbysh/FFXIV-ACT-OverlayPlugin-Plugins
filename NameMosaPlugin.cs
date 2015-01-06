using Advanced_Combat_Tracker;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
// Advanced Combat Tracker - mini parse window用Plugin
// NameMosa:キャラクターをモザイク処理
[assembly: AssemblyTitle("Mini Parse Mosaic Name")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace ACTv3Plugins
{
	public class NameMosaPlugin : IActPluginV1
	{
		Label statusLabel;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			statusLabel = pluginStatusText;
			CombatantData.ExportVariables.Add(
				"NameMosa",
			new CombatantData.TextExportFormatter("NameMosa", "Name Mosa", "name mosaic", (data, extra) => {
				return "\u2592\u2592\u2592\u2592";
			}));
			ActGlobals.oFormActMain.ValidateLists();
			statusLabel.Text = "Initialized.";
		}

		public void DeInitPlugin()
		{
			CombatantData.ExportVariables.Remove("NameMosa");
			statusLabel.Text = "Deinitialized";
		}

	 }
}
