using System;
using System.Collections.Generic;
using System.Text;

namespace GET.PKI.Common
{
    public static class Pkcs11Attributes
    {
        #region Keys constants
        public const string KEY_NAME = "keyName";
        public const string KEY_SIZE = "keySize";
        public const string KEY_IS_EXPORTABLE = "IsExportable";
        #endregion

        #region Slots
        public const string SLOT_ID = "slotId";
        #endregion

    }
}
