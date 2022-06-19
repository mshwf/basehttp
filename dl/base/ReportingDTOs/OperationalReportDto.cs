using System;
using System.Collections.Generic;
using System.Linq;

namespace GET.Spooler.Base
{
    public class OperationalReportDto
    {

        public string UserName { get; set; }
        public DateTime IssuingTime { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<DocumentTypeFigure> DocumentTypeFigures { get; set; }
        public string QRData { get; set; }

        public string GetDataToBeSigned()
        {
            return $"{IssuingTime.Ticks},{FromDate.Ticks},{ToDate.Ticks}," +
                $"[{string.Join(",", DocumentTypeFigures.Select(d => $"{d.Name},{d.TotalNumberOfSuccessCards},{d.TotalNumberOfDefectiveCards}"))}]";
        }
    }

    public class DocumentTypeFigure
    {
        public string Name { get; set; }
        public int TotalNumberOfSuccessCards { get; set; }
        public int TotalNumberOfDefectiveCards { get; set; }
    }
}
