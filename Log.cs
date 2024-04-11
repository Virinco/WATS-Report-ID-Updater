using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATS_UpdateReportIDs
{

    public class Log
    {
        bool saved = false;
        //StreamWriter streamWriter;
        string path;
        public Log()
        {
            path = Path.GetTempFileName();
        }
        ~Log()
        {
            if (!saved)
            {
                Delete();
            }
        }
        public bool Delete()
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool WriteLine(string message)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Write(string message)
        {
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.Write(message);
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Save()
        {
            SaveFileDialog file_dialog = new SaveFileDialog();
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                return SaveAs(file_dialog.FileName);
            }
            return false;
        }
        public bool SaveAs(string new_path)
        {
            try
            {               
                File.Copy(path, new_path, true);

                // DELETE TEMP FILE ON FIRST SAVE
                if (!saved)
                {
                    try
                    {
                        Delete();
                        saved = true;
                    }
                    catch
                    {                     
                    }
                }


                path = new_path;
                return true;
            }
            catch
            {
                MessageBox.Show("Save failed!");
                return false;
            }
        }
    }
}
