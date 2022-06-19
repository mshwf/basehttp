using System;
using System.Collections.Generic;
using System.Text;

namespace GET.Spooler.Base
{

    public enum LicenseStatus
    {
        Activated = 0,
        SOMETHING_WENT_WRONG_PLEASE_CONTACT_OUR_SUPPORT_TEAM = 20000,
        LICENSE_USE_IN_ANOTHER_MACHINE = 20001,
        LICENSE_EXPIRED = 20002,
        MACHINE_TIME_IS_OLDER = 20003,
        FEATURE_NOT_SUPPORTED_IN_THIS_EDITION = 20004,
        INVALID_LICENSE_FILE = 20005,
        MACHINE_DATE_IS_OLDER = 20006,
        LICENSE_NOT_EXISTS = 20007,
        FAILED_TO_READ_LAST_USED_DATE = 20008
    }
}
