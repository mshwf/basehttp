using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class FeederDto
    {
        public int FeederId { get; set; }
        public int? PrinterId { get; set; }
        public string FeederName { get; set; }
        public int ErrorThreshold { get; set; }
        public string DocumentType { get; set; }
        public int? DocumentTypeId { get; set; }
    }
}