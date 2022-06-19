using System;

namespace GET.Spooler.Base
{
    public class OrderState
    {
        public DateTime? StartedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        //public DateTime ReceivedTime { get; set; }
        public string ErrorMessage { get; set; }
        public string DocumentNumber { get; set; }
        public string PrintUser { get; set; }
        public JobStatus State { get; set; }
    }
}