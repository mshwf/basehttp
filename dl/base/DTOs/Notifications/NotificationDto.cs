using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class NotificationDto
    {
        public Guid NotificationId { get; set; }
        public int SenderId { get; set; }
        public string Receivers { get; set; }
        public string ActualReceivers { get; set; }
        public bool? IsPublisher { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationContent { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public bool? IsSeen { get; set; }
        public DateTime? SeenTime { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}