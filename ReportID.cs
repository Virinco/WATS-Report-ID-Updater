using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS_UpdateReportIDs
{
    public class ReportID
    {
        private string sn, pn, rev;

        public string SN 
        {
            get 
            {
                return sn;
            }
            set 
            {
                sn = value;
            }
        }
        public string PN
        {
            get
            {
                return pn;
            }
            set
            {
                pn = value;
            }
        }
        public string REV
        {
            get
            {
                return rev;
            }
            set
            {
                rev = value;
            }
        }

        public ReportID()
        {
            sn = "";
            pn = "";
            rev = "";
        }
        public ReportID(ReportID src)
        {
            this.sn = src.sn;
            this.pn = src.pn;
            this.rev = src.rev;
        }
        public ReportID(string serial_number, string part_number, string revision)
        {
            sn = serial_number;
            pn = part_number;
            rev = revision;
        }
        private bool IsLegal(string id)
        {
            if (id.Contains("%")) return false;
            if (id.Contains("*")) return false;
            if (id.Contains(";")) return false;
            if (id.Contains(",")) return false;
            return true;
        }

        public override string ToString()
        {
            return "(" + sn + "," + pn + "," + "rev" + ")";
        }
        public bool Validate()
        {
            if ((IsLegal(PN) && IsLegal(REV) && IsLegal(SN)))
            {
                // SN & PN Can't be empty
                if (!(SN == "") && !(PN == ""))
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }
    }
}
