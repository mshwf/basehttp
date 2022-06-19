using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class UpdateFeedersStatusDto
    {
        public string PrintingMachineURL { get; set; }
        public string PrinterPath { get; set; }
        public string FeederName { get; set; }
        public bool IsResetFeederStatus { get; set; }
    }
}
