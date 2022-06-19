using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GET.PKI.Common
{
    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null) return false;
            if (x.Equals(y, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.GetHashCode();
        }
    }
}
