using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class JobBatchDto
    {
        public JobBatchDto()
        {
            Jobs = new HashSet<JobDto>();
        }

        public int JobBatchId { get; set; }
        public string JobBatchSenderIp { get; set; }
        public bool? IsJobBatchEnded { get; set; }
        public string JobBatchName { get; set; }
        public int SiteId { get; set; }
        public DateTime ReceivedTime { get; set; }
        public DateTime? StartedTime { get; set; }
        public DateTime? CompleteTime { get; set; }
        public int JobsCount { get; set; }
        public int? PrintedJobsCount { get; set; }
        public int? FailedCount { get; set; }
        public int? SuccessCount { get; set; }
        public int StateId { get; set; }
        public string JobBatchPort { get; set; }
        public string JobBatchGuid { get; set; }
        public int? PrinterId { get; set; }
        public string JobDefinition { get; set; }

        public virtual PrinterDto Printer { get; set; }
        public virtual SiteDto Site { get; set; }
        public virtual BatchStatus State { get; set; }
        public virtual ICollection<JobDto> Jobs { get; set; }
    }

}
