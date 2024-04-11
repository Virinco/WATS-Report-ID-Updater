using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS_UpdateReportIDs
{
    public class AppSettings
    {
        public string ServiceURL = "wats.yourservername.com";
        public string Token = "";
        public bool SkipHeaderRow = true;
        public string CSVDelimiter = ",";

        public AppSettings()
        {
            ReadSettings();
        }
        public void ReadSettings()
        {
            ServiceURL = Properties.Settings.Default.ServiceURL;
            Token = Properties.Settings.Default.Token;
            SkipHeaderRow = Properties.Settings.Default.SkipHeaderRow;
            CSVDelimiter = Properties.Settings.Default.CSVDelimiter;
        }
        public void WriteSettings()
        {
            Properties.Settings.Default.ServiceURL = ServiceURL;
            Properties.Settings.Default.Token = Token;
            Properties.Settings.Default.SkipHeaderRow = SkipHeaderRow;
            Properties.Settings.Default.CSVDelimiter = CSVDelimiter;
            Properties.Settings.Default.Save();
        }
        public void Reset_Defaults()
        {
            Properties.Settings.Default.ServiceURL = "https://yourservername.wats.com/";
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.SkipHeaderRow = true;
            Properties.Settings.Default.CSVDelimiter = ",";
            Properties.Settings.Default.Save();
        }
    }
}
