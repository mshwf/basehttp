using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base.DTOs
{
   public class ChipSerialDto
    {
        public int Id { get; set; }
        public string ChipNumber { get; set; }
        public string SerialNumber { get; set; }
        public string JobGuid { get; set; }
    }
}
