using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace GET.Spooler.Base
{
    public enum JobStatus : int
    {

        NONE = 0,

        READY = 1,

        QUEUED = 2,

        SUBMITTED = 3,

        ACCEPTED = 4,

        RUNNING = 5,

        FINISHED = 6,

        FAILED_TO_PRINT = 7,

        FAILED_TO_DISPATCH = 8,

        ONHOLD = 9,

        QUEUED_TO_OTHERSITE = 10,

        FAILED_TO_REDIRECT = 11,

        REDIRECTED = 12,

        FAILED_IN_QA = 13,

        SUCCESSED_IN_QA = 14,

        Cancelled = 15,
    }
}
