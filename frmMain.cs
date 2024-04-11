using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATS_UpdateReportIDs
{
    public partial class frmMain : Form
    {
        AppSettings appSettings;
        WATS_RestAPIHelper wats_api;
        double time = 0;
        bool abort = false;
        bool processing = false;

        public frmMain()
        {
            appSettings = new AppSettings();
            appSettings.ReadSettings();
            wats_api = new WATS_RestAPIHelper(appSettings);
            InitializeComponent();
        }


        public void UpdateGUI()
        {
            // Update connection-status

        
        }
        private void CloseApplication(object sender, EventArgs e)
        {
            // Cleanup!
            appSettings.WriteSettings();
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settingsDialog = new frmSettings(appSettings);
            settingsDialog.ShowDialog();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
        }

        private void ProcessCSVFile(object sender, EventArgs e)
        {
            processing = true;
            DisableMenusAndButtons();
            abort = false;
            int lines = 0;
            time = 0;
            timer.Start();

            Log log = new Log();
            toolStripStatusLabel1.Text = "Updating - please wait";

            int line = 0;
            // Select CSV File
            if ((openCSVDialog.ShowDialog() == DialogResult.OK))
            {
                try
                {
                    // Process CSV
                    using (StreamReader sr = new StreamReader(openCSVDialog.FileName))
                    {
                        log.WriteLine("Updating SN from CSV:" + openCSVDialog.FileName);
                        log.WriteLine("Date:" + DateTime.Now.ToString());

                        lines = sr.ReadToEnd().Split(new char[] { '\n' }).Length;
                        sr.BaseStream.Position = 0;
                        sr.DiscardBufferedData();
                        
                        string currentLine;

                        // Skip header row if true
                        if (appSettings.SkipHeaderRow)
                        {
                            line += 1;
                            currentLine = sr.ReadLine();
                            log.WriteLine("Skipped: Header row (" + currentLine + ")");
                        }

                        // Write column headers to log
                        log.WriteLine("Line\tResult\tFound\tAction\tUpdated\tFailed\tDescription");
                        
                        // currentLine will be null when the StreamReader reaches the end of file
                        while ((currentLine = sr.ReadLine()) != null && !abort)
                        {
                            line += 1;
                            string line_ID = "Line: " + line + "\t";
                            string line_Result = "OK";
                            string line_Descr = "";
                            Application.DoEvents();
                            string[] columns = currentLine.Split(appSettings.CSVDelimiter.ToCharArray()[0]);
                            // Process only if 7 items
                            if (columns.Count() == 7)
                            {
                                if (columns[0].ToLower() == "move" || columns[0].ToLower() == "copy")
                                {

                                    ReportID src = new ReportID(columns[3], columns[1], columns[2]);
                                    ReportID dst = new ReportID(columns[6], columns[4], columns[5]);
                                    bool copy = (columns[0].ToString().ToLower() == "copy");

                                    if (src.Validate() && dst.Validate())
                                    {
                                        // Update reports

                                        string result = wats_api.UpdateReportHeaders(src, dst, copy);
                                        log.WriteLine("#" + line + "\t" + result + "\t" + line_Descr);

                                        /*
                                        if (result != "Failed")
                                        {
                                            log.WriteLine(result);
                                        }
                                        else
                                        {
                                            if (MessageBox.Show(this, "Filed to connect!", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                                            {
                                                log.WriteLine("Failed to connect" + currentLine + 1);
                                                return;
                                            }
                                            else
                                            {
                                                log.WriteLine("Failed to connect, aborted!");
                                                break;
                                            }
                                        }
                                        */

                                    }
                                    else
                                    {
                                        // LOG ILLEGAL Source or Destination ID's
                                        line_Result = "ERROR";
                                        line_Descr = "Illegal report ID(s)";
                                        log.WriteLine("#" + line +"\t" +"ERR"+ src.ToString() + dst.ToString() + "\t" + "Illegal ID");
                                    }

                                }
                                else
                                {
                                    // TODO LOG: ILLEGAL ACTION CODE - First column must contain 'Move' or 'Copy' 
                                    line_Result = "ERROR";
                                    line_Descr = "Invalid Action";
                                    log.WriteLine("#" + line + "\t" + "ERROR" + "\t\t\t\t\t\t" + "Invalid action: " + columns[0].ToString());

                                }

                            }
                            else
                            {
                                // TODO: LOG Incorrect number of columns
                                line_Result = "ERROR";
                                line_Descr = "Incorrect number of columns";
                                log.WriteLine("#" + line + "\t" + "ERROR" + "\t\t\t\t\t\t - Incorrect number of columns.");
                            }
                            
                            // Time
                            double tick_pr_line = time / (line);
                            double est_time = tick_pr_line * (lines - line);
                            var ts = TimeSpan.FromSeconds(est_time);
                            var parts = string
                                            .Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s:{4:D3}ms",
                                                ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds)
                                            .Split(':')
                                            .SkipWhile(s => Regex.Match(s, @"00\w").Success) // skip zero-valued components
                                            .ToArray();
                            var time_text = string.Join(" ", parts); // combine the result
                            toolStripStatusLabel1.Text = "Updating (" + (line + 1).ToString() + @"/" + lines + ") Est. time left: " + time_text;

                            // Update progress
                            double progress = (double)line / (double)lines;
                            toolStripProgressBar1.Value = (int)(progress * 100);
                        }

                    }
                    if (abort)
                    {
                        log.WriteLine("#" + line + "\t" + "ERROR" + "\t\t\t\t\t\t" + "Aborted by user" + line);
                    }
                    log.Save();
                }
                catch
                {
                    MessageBox.Show("Failed to open CVS file!");
                    log.Delete();
                }
            }
            timer.Stop();
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Ready";
            processing = false;
            EnableMenusAndButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReportID repIDDialog = new frmReportID();
            if (repIDDialog.ShowDialog(this) == DialogResult.OK)
            {
                string response = wats_api.UpdateReportHeaders(repIDDialog.SourceID, repIDDialog.DestinationID, false);
                MessageBox.Show(response);
            }
            
            repIDDialog.Dispose();            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (processing)
            { 
                if(MessageBox.Show(this, "File is being processed. Abort?","Abort update?",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    abort = true;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time += 1;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                abort = true;
            }
        }

        private void DisableMenusAndButtons()
        {
            menuStrip1.Enabled = false;
            btnUpdateCSV.Enabled = false;
            btnUpdateSingle.Enabled = false;
        }
        private void EnableMenusAndButtons()
        {
            btnUpdateCSV.Enabled = true;
            btnUpdateSingle.Enabled = true;
            menuStrip1.Enabled = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Doc", "WATS Update Report IDs.pdf");
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Unable to open Help-file");
            }            
        }
    }
}
