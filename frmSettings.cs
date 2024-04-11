using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATS_UpdateReportIDs
{
    public partial class frmSettings : Form
    {
        public AppSettings settings;
       

        public frmSettings(AppSettings s)
        {
            settings = s;
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            settings.ServiceURL = txtServiceURL.Text;
            settings.Token = txtToken.Text;
            settings.SkipHeaderRow = chkSkipHeader.Checked;
            settings.CSVDelimiter = txtDelimiter.Text;
            settings.WriteSettings();
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtToken.Text = settings.Token;
            chkSkipHeader.Checked = settings.SkipHeaderRow;
            txtDelimiter.Text = settings.CSVDelimiter;
            UpdateGUI();

        }

        private void UpdateGUI()
        {
        }

    }
}
