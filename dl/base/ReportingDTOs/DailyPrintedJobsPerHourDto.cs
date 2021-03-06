using System;
using System.Collections.Generic;


namespace GET.Spooler.Base
{
    public partial class DailyPrintedJobsPerHourDto
    {
        public int PrintedjobId { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public string CityName { get; set; }
        public string JobDefinition { get; set; }
        public int Received { get; set; }
        public int Printed { get; set; }
        public int Failure { get; set; }
        public int Reprinted { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
    }
}
