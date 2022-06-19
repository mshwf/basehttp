using System.Collections.Generic;

namespace GET.Spooler.Base
{
    public class DocumentTypeDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }

        public virtual List<FeederDto> PrinterFeeders { get; set; }
    }
}
