using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GET.Spooler.Base
{
    public class PrinterDto
    {
        public int PrinterId { get; set; }
        public string PrinterName { get; set; }
        public string PrinterPath { get; set; }
        public bool IsActive { get; set; }
        public Guid? DeviceId { get; set; }
        public int PrinterTypeId { get; set; }
        public int? PrintingMachineId { get; set; }
        public bool? IsOnline { get; set; }
        public bool? IsDeleted { get; set; }
        public string PrinterTypeName { get; set; }
        public string PrintingMachineName { get; set; }
        public string PrintingMachineUrl { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string CityName { get; set; }
        public List<FeatureDto> Features { get; set; }
        public List<FeederDto> Feeders { get; set; }
        public PrinterTypeDto PrinterType { get; set; }


    }
}