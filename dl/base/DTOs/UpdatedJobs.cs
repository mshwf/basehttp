using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public class UpdatedJobs
    {
        public List<JobStub> Jobs { get; set; }
        public List<BatchStub> Batches { get; set; }
    }
}
