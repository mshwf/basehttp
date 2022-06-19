using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class SiteMonitorDto
    {
        public string VersionNumber { get; set; }
        public string LicenseStatus { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public int SiteId { get; set; }
        public string CityName { get; set; }
        public string PrintingStatus { get; set; }
        public int PrintersCount { get; set; }
        public int PrinterMachinesCount { get; set; }
        public bool IsRunning { get; set; }
        public List<PrintersStatusModel> PrintersStatus { get; set; }
    }
 
}