using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class BatchStub
    {

        public int StateId { get; set; }


        public DateTime? StartedTime { get; set; }


        public DateTime? CompleteTime { get; set; }


        public int? PrintedJobsCount { get; set; }

        public int? FailedCount { get; set; }

        public int? SuccessCount { get; set; }


        public string BatchGuid { get; set; }
    }
}
