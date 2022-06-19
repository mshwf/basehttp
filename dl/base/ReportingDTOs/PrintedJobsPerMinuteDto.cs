using System;
using System.Collections.Generic;


namespace GET.Spooler.Base
{
    public partial class PrintedJobsPerMinuteDto
    {
        public int Minute { get; set; }
        public int Printed { get; set; }
        public int FailedJobs { get; set; }
        public int FailedCards { get; set; }
        public DateTime? Time { get; set; }
    }
}
