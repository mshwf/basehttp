namespace GET.PKI.Common
{
    public static class Attributes
    {
        #region Keys constants

        public const string KEY_ID = "KeyId";
        public const string KEY_NAME = "KeyName";
        public const string KEY_SIZE = "KeySize";
        public const string KEY_STORE = "KeyStore";
        public const string KEY_IS_EXPORTABLE = "IsExportable";
        public const string KEY_CONTAINER_NAME = "ContainerName";
        public const string KEY_PROVIDER_NAME = "ProviderName";
        public const string KEY_PROVIDER_TYPE = "ProviderType";
        public const string KEY_TYPE = "KeyType";
        public const string KEY_MECHANSIM = "KeyMechanism";
        public const string NAMED_CURVE = "NamedCurve";
        public const string KEY_NUMBER = "KeyNumber";
        public const string KEY_FLAGS = "KeyFlags";
        public const string SLOT_NUMBER = "SlotNumber";
        #endregion

        #region Certificates constants
        public const string CERT_NOT_BEFORE = "notBefore";
        public const string CERT_NOT_AFTER = "notAfter";
        public const string CERT_CA_PASSWORD = "CAPassword";
        #endregion    
    }
}