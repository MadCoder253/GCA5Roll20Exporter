//These aren't usually required Imports within Visual Studio, but have to be included
//here now because the plugin compiler doesn't make these associations automatically.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Security;


using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using GCA5.Interfaces;
using GCA5Engine;
using System.Drawing;

namespace ExportToRoll20
{
    public class ExportToRoll20 : GCA5.Interfaces.IExportSheet
    {
        private const string PLUGIN_NAME = "Export Character to Roll20";
        private const string PLUGIN_DESCRIPTION = "Export Character to a json file to import into Roll20. For more informaiton see: https://github.com/MadCoder253/GCA5Roll20Exporter";
        private const string PLUGIN_VERSION = "1.0.0.0";

        public event IExportSheet.RequestRunSpecificOptionsEventHandler RequestRunSpecificOptions;

        public void CreateOptions(SheetOptionsManager mySheetOptions)
        {
            SheetOption mySheetOption = new SheetOption();
            SheetOptionDisplayFormat myDisplayFormat = new SheetOptionDisplayFormat();

            myDisplayFormat.BackColor = SystemColors.Info;
            myDisplayFormat.CaptionLocalBackColor = SystemColors.Info;

            mySheetOption.Clear();
            mySheetOption.Name = "Header_Description";
            mySheetOption.Type = GCA5Engine.OptionType.Header;
            mySheetOption.UserPrompt = PluginName() + PluginVersion();
            mySheetOption.DisplayFormat = myDisplayFormat;
            mySheetOptions.AddOption(mySheetOption);

            mySheetOption.Clear();
            mySheetOption.Name = "Description";
            mySheetOption.Type = GCA5Engine.OptionType.Caption;
            mySheetOption.UserPrompt = PluginDescription();
            mySheetOption.DisplayFormat = myDisplayFormat;
            mySheetOptions.AddOption(mySheetOption);
        }

        public string PluginDescription()
        {
            return PLUGIN_DESCRIPTION;
        }

        public string PluginName()
        {
            return PLUGIN_NAME;
        }

        public string PluginVersion()
        {
            return PLUGIN_VERSION;
        }

        public int PreferredFilterIndex()
        {
            // only json files are supported
            return 0;
        }

        public bool PreviewOptions(SheetOptionsManager Options)
        {
            // not needed
            return true;
        }

        public string SupportedFileTypeFilter()
        {
            return "JSON files (*.json)|*.json";
        }

        public void UpgradeOptions(SheetOptionsManager Options)
        {
            //Not needed as of now
        }

        public bool GenerateExport(Party Party, string TargetFilename, SheetOptionsManager Options)
        {
            if (Party.Characters.Count > 20)
            {
                DialogOptions_RequestedOptions e = new DialogOptions_RequestedOptions();
                SheetOptionsManager SOM = new GCA5Engine.SheetOptionsManager("RunSpecificOptions For " + PluginName());
                e.RunSpecificOptions = SOM;
                RequestRunSpecificOptions.Invoke(this, e);
            }

            FileWriter fileWriter = new FileWriter();

            try
            {
                fileWriter.FileOpen(TargetFilename);

                fileWriter.Write("{\"title\": \"Export to Roll20\"}");
            }
            finally
            {
                fileWriter.FileClose();
            }
            
            return true;
        }


    }
}
