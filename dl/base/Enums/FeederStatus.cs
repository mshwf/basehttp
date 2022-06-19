using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public enum FeederStatus
    {

        READY = 1,
        BUSY = 2,
        ERROR = 4,
        THRESHOLD_EXCEEDED = 3,
    }
}
