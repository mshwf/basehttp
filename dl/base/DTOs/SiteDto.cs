using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class SiteDto
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public string SiteAddress { get; set; }
        public string IpcId { get; set; }
        public int SiteType { get; set; }
        public string PrintersStatus { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string SpoolerStatus { get; set; }
        public string VersionNumber { get; set; }
        public string LicenseStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string PrintingStatus { get; set; }
        public virtual ICollection<UserSiteDto> UserSites { get; set; }
        public bool? IsUpdating { get; set; }
        public string SideCode { get; set; }
        public virtual ICollection<WarehouseDto> Warehouses { get; set; }

    }
    public class UserSiteDto
    { 
        public string UserId { get; set; }
         public int SiteId { get; set; }
        public string UserName { get; set; }
    }
}
