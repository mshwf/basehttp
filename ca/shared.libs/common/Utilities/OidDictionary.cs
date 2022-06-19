using System.Collections.Generic;

namespace GET.PKI.Common
{
    public class OidDictionary : Dictionary<string, string>
    {
        public new void Add(string name, string oid) => base.Add(name, oid);

        public new string this[string name]
        {
            get => base[name];
            set => base[name] = value;
        }
    }
}
