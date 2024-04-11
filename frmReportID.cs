using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATS_UpdateReportIDs
{
    public partial class frmReportID : Form
    {
        private ReportID sourceID = new ReportID();
        private ReportID destinationID = new ReportID();

        public ReportID SourceID
        {
            get { return sourceID; }
            set { sourceID = value; }
        }
        public ReportID DestinationID
        {
            get { return destinationID; }
            set { destinationID = value; }
        }
        public frmReportID()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sourceID.SN = txtSrcSN.Text;
            sourceID.PN = txtSrcPN.Text;
            sourceID.REV = txtSrcRev.Text;

            destinationID.SN = txtDestSN.Text;
            destinationID.PN = txtDestPN.Text;
            destinationID.REV = txtDestRev.Text;

            if (sourceID.Validate() && destinationID.Validate())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid report IDs");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            sourceID = null;
            destinationID = null;
            this.Close();
        }
    }
}
