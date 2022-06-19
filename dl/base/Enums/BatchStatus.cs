using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public enum BatchStatus : int
    {

        NONE = 0,

        RECEIVING = 1,

        RECEIVED = 2,

        READY_FOR_PRINTING = 3,

        Cancelled = 4,

        QA_DONE = 5,

        FINISHED = 6,

        QUEUED_TO_OTHERSITE = 7,

        FAILED_TO_REDIRECT = 8,

        REDIRECTED = 9,

        QUEUED_TO_DISPATCH = 10,

        FAILED_TO_DISPATCH = 11
    }

}
