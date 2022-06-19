using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class JobDto
    {
        public string JobDefinition { get; set; }
        public string JobGuid { get; set; }
        public int? JobPriority { get; set; }
        //public int? AssignedToPrinterID { get; set; }
        //public int? SiteID { get; set; }
        //public int JobID { get; set; }
        public DateTime JobScheduledTime { get; set; }

        public int JobId { get; set; }
        public string JobName { get; set; }
        public int? JobTypeId { get; set; }
        public int JobStateId { get; set; }
        public JobStatus JobStatus { get; set; }
        public int JobOwnerId { get; set; }
        public int? TotalNumberOfPrints { get; set; }
        public int? NumberOfTrials { get; set; }
        public DateTime? JobStartTime { get; set; }
        public DateTime? JobCompletedTime { get; set; }
        public int? JobBatchId { get; set; }
        public int? AssignedToPrinterId { get; set; }
        public int? ScheduleModeId { get; set; }
        public int? NumberOfExecutedJobs { get; set; }
        public int? NumberOfReprintedJobs { get; set; }
        public string ErrorMessage { get; set; }
        public string WarehouseResponseMessage { get; set; }
        public string RejectionReason { get; set; }
        public string ChipSerialNumber { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public int? JobDetailsId { get; set; }
        public bool? Reprint { get; set; }
        public string PrintUser { get; set; }
        public bool? IsUpdated { get; set; }
        public string MachineId { get; set; }

        public virtual PrinterDto Printer { get; set; }
        public virtual OwnerDto Owner { get; set; }

        public PageDto FrontPage { get; set; }

        public PageDto BackPage { get; set; }

        public PrintOptionsDto PrintOptions { get; set; }

        public Dictionary<string, string> LogicalItems { get; set; }
        public int WarehouseId { get; set; }
        public string CardSerial { get; set; }
        public bool? WarehouseUpdated { get; set; }
        public string WarehouseName { get; set; }
        public string ToJson()
        {
            var job = new PrintingOrderDto
            {
                print_options = PrintOptions
            };
            LogicalItems.Add("PassportType", JobDefinition);
            job.definition = LogicalItems;
            return JSON.Serialize(job);
        }
    }

    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MachineName { get; set; }
        public string MachineIPAddress { get; set; }
    }

    public static class JobDtoExtensions
    {
        public static bool HasColorLayerx(this JobDto job)
        {
            if ((job.FrontPage != null && job.FrontPage.ColorImage != null && job.FrontPage.ColorImage.Length != 0) ||
              (job.BackPage != null && job.BackPage.ColorImage != null && job.BackPage.ColorImage.Length != 0)) return true;

            return false;
        }
        public static bool HasBlackLayer(this JobDto job)
        {
            if ((job.FrontPage != null && job.FrontPage.BlackImage != null && job.FrontPage.BlackImage.Length != 0) ||
              (job.BackPage != null && job.BackPage.BlackImage != null && job.BackPage.BlackImage.Length != 0)) return true;

            return false;
        }
        public static bool HasUVLayer(this JobDto job)
        {
            if ((job.FrontPage != null && job.FrontPage.UVImage != null && job.FrontPage.UVImage.Length != 0) ||
              (job.BackPage != null && job.BackPage.UVImage != null && job.BackPage.UVImage.Length != 0)) return true;

            return false;
        }
    }


}
