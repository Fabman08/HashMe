using com.prjteam.HashUtil;


namespace com.prjteam.HashMe.DTO
{
    public class DtoTemplate
    {
        public int Index { get; private set; }
        public string Name { get; private set; }        
        public string Salt { get; private set; }
        public StringUtil.SALT_POSITION SaltPosition { get; private set; }
        public bool SaltToHash { get; private set; }
        public StringUtil.HASH_ALGORITHM HashAlgorithm { get; private set; }
        public StringUtil.ENCRYPTION_FORMAT EncryptionFormat { get; private set; }
        public StringUtil.ENCODING_TYPES EncodingType { get; private set; }
        public bool Editable { get; private set; }

        public DtoTemplate(int index, string name, string salt, StringUtil.SALT_POSITION saltPosition, bool saltToHash, StringUtil.HASH_ALGORITHM hashAlgorithm, StringUtil.ENCRYPTION_FORMAT encryptionFormat, StringUtil.ENCODING_TYPES encodingType, bool editable)
        {
            Index = index;
            Name = name;
            Salt = salt;
            SaltPosition = saltPosition;
            SaltToHash = saltToHash;
            HashAlgorithm = hashAlgorithm;
            EncryptionFormat = encryptionFormat;
            EncodingType = encodingType;
            Editable = editable;
        }
    }
}
