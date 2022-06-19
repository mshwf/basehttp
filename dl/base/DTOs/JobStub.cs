using Newtonsoft.Json;
using System;

namespace GET.Spooler.Base
{
    public class JobStub
    {
        [JsonIgnore]
        public int? BatchId { get; set; }
        [JsonIgnore]
        public int NumOfExecutedJobs { get; set; }
        [JsonIgnore]
        public int NumOfReprintedJobs { get; set; }
        [JsonIgnore]
        public int NumOfTrials { get; set; }

        public int JobStateId { get; set; }

        public string JobGuid { get; set; }

        public DateTime? PrintDate { get; set; }

        public DateTime? StartTime { get; set; }

        public int NumberOfExecutedJobs { get; set; }

        public int NumberOfTrials { get; set; }

        public string ErrorMessage { get; set; }

        public int NumberOfReprintedJobs { get; set; }

        public string OperationId { get; set; }

        public string MachineId { get; set; }

        public string ChipSN { get; set; }

        public int PrintTimes { get; set; }
    }
}
