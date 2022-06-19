using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{
    public enum RequestType : int
    {
        NONE = 0,
        SITE_DISPATCHER = 1,
        JOB_DISPATCHER = 2,
    }

    public enum JobScheduleMode : int
    {
        NONE = 0,
        INTERACTIVE = 1,
        DROP_AND_MONITOR = 2
    }

    public enum PropertyType : int
    {
        Boolean = 1,
        String = 2,
        Number = 3,
        Enum = 4,
        Complex = 5,
        Device = 6
    }
}
