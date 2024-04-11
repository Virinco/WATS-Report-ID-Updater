using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Virinco.WATS.Schemas.WRML;
using Virinco.WATS.Web.Api.Models;

namespace WATS_UpdateReportIDs
{
    class WATS_RestAPIHelper
    {
        private AppSettings appSettings;
        public AppSettings AppSettings
        {
            get 
            {
                return appSettings;
            }
            set 
            {
                appSettings = value;
            }
        }

        private static HttpClient httpClient = new HttpClient();


        public WATS_RestAPIHelper(AppSettings settings)
        {
            this.appSettings = settings;

            //string filename = settings.LogFileDirectory + "UpdateReportID_LOG_" + DateTime.Now.ToString() + ".log";
            //fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
        }

        public string UpdateReportHeaders(ReportID source_ID, ReportID dest_ID, bool make_copy = false)
        {
            String action = "Move";
            if (make_copy == true) action = "Copy";

            int found = 0;
            int updated = 0;
            int failed = 0;
            string result = "";
            string failures = "";

            string log_text = action + "\t" + "RESULT" + source_ID.ToString() + " to: " + dest_ID.ToString() + " - ";
            // Find reports
            try
            {

                
                var headers = FindReports(source_ID.SN, source_ID.PN, source_ID.REV);
                found = headers.Count;
                log_text += " - Found: " + found;

                // Update reports
                foreach (var header in headers)
                {
                    HttpStatusCode status = UpdateReport(header.Guid, dest_ID.SN, dest_ID.PN, dest_ID.REV, make_copy);
                    if (status == HttpStatusCode.OK)
                    {
                        updated += 1;
                    }
                    else
                    {
                        failed += 1;
                        failures += status.ToString() + "\t";
                    }
                }
                log_text += " - Updated: " + updated + " - Failed: " + failed;
            }
            catch 
            {
                result = "ERR";
            }

            if (found > 0)
            {
                if (failed == 0)
                {
                    result = "OK";
                }
                else
                {
                    result = "ERR";
                }
            }
            else
            {
                result = "NF";
            }

            return result + "\t" + found + "\t" + action + "\t" + updated + "\t" + failed + "\t" + failures;
            return result;
        }

        // Tar stringene sn, pn og rev som parameter og returnerer rapport-id’er eller headere for alle rapporter som matcher? 
        private List<WatsReportHeader> FindReports(string sn, string pn, string rev)
        {
            var headers = new List<WatsReportHeader>();

            int i = 0;
            int top = 1000;

            //Get all reports, 1000 at a time
            int resultCount = 1;
            while (resultCount > 0)
            {
                int skip = top * i;
                var request = new HttpRequestMessage(HttpMethod.Get, appSettings.ServiceURL + $"/api/report/query?$filter=SN eq '{sn}' and PN eq '{pn}' and Rev eq '{rev}'&$orderby=tstamp asc&$top={top}&$skip={skip}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", appSettings.Token);

                var response = httpClient.SendAsync(request).Result; 
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;

                var result = Virinco.Newtonsoft.Json.JsonConvert.DeserializeObject<WatsReportHeader[]>(content);
                headers.AddRange(result);
                resultCount = result.Length;
                i++;
            }

            return headers;
        }

        //Tar rapportID og nytt sn,pn og rev som parameter, returnerer en statuskode som bekrefter oppdateringen, f.eks respons-text.
        private HttpStatusCode UpdateReport(Guid uuid, string newSn, string newPn, string newRev, bool makeCopy = false)
        {
            //Get wrml
            var request = new HttpRequestMessage(HttpMethod.Get, appSettings.ServiceURL + $"/api/internal/report/wrml/{uuid}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", appSettings.Token);

            var response = httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            //Edit wrml
            var xmlSerializer = new XmlSerializer(typeof(Virinco.WATS.Schemas.WRML.Reports));
            var reader = new StringReader(content);
            
            var report = (Virinco.WATS.Schemas.WRML.Reports)xmlSerializer.Deserialize(reader);



            report.Report[0].SN = newSn;
            report.Report[0].PN = newPn;
            report.Report[0].Rev = newRev;

            

            if (makeCopy)
            {
                report.Report[0].ID = Guid.NewGuid().ToString();

                //report.Report[0].ID = "00000000-0000-0000-00000000";// Guid.Empty.ToString();
            }
            
            var writer = new StringWriter();
            xmlSerializer.Serialize(writer, report);
            string reportString = writer.ToString();

            //Send wrml
            request = new HttpRequestMessage(HttpMethod.Post, appSettings.ServiceURL + $"/api/report");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", appSettings.Token);
            request.Content = new StringContent(reportString, Encoding.UTF8, "application/xml");

            response = httpClient.SendAsync(request).Result;
            return response.StatusCode;
        }
    }
}

