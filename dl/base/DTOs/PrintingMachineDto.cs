using System.Collections.Generic;

namespace GET.Spooler.Base
{
    public class PrintingMachineDto
    {
        public int PrintingMachineId { get; set; }
        public string PrintingMachineName { get; set; }
        public string PrintingMachineDescription { get; set; }
        public string PrintingMachineUrl { get; set; }
        public string PrintingMachineIpaddress { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public List<PrinterDto> Printers { get; set; }
    }
}