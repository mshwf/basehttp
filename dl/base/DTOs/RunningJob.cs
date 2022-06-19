using System;

namespace GET.Spooler.Base
{
    public class RunningJob
    {
        public string Id { get; set; }
        public JobStatus JobStatus { get; set; }
        public string JobDefinition { get; set; }
        public int? WarehouseId { get; set; }
        public string CardSerial { get; set; }
        public DateTime StartedTime { get; set; }
    }
}