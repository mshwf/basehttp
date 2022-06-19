using System;
using System.Collections.Generic;
using System.Text;

namespace GET.PKI.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public List<string> HelpList { get; set; }
    }
}
