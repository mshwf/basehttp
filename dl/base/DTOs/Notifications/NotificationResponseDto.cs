using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class NotificationResponseDto
    {
        public string NotificationTitle { get; set; }
        public string NotificationContent { get; set; }
        public string MainURL { get; set; }
        public DateTime? CreatedTime { get; set; }
    }

    //public class NotificationDto
    //{
    //    public string NotificationTitle { get; set; }
    //    public string NotificationContent { get; set; }
    //    public string MainURL { get; set; }
    //}
}