using System;
using System.Text;
using System.Security.Cryptography;

namespace com.prjteam.HashUtil
{
    public static class StringUtil
    {
        public enum HASH_ALGORITHM
        {
            Unselected = -1,
            Sha1 = 160,
            Sha256 = 256,
            Sha384 = 384,
            Sha512 = 512, 
            Md5 = 128
        }

        public enum ENCRYPTION_FORMAT
        {
            Unselected = -1,
            Base64 = 0,
            Hex = 1,
            Plain = 2
        }        
        
        public enum ENCODING_TYPES
        {
            Unselected = -1,
            Ascii = 0, 
            BigEndianUnicode = 1, 
            Unicode = 2,  
            Utf7 = 3, 
            Utf8 = 4, 
            Utf32 = 5
        }        

        public enum SALT_POSITION
        {
            Tail, Head
        }

        

        public static Encoding GetEncoder(ENCODING_TYPES type)
        {
            switch(type)
            {
                case ENCODING_TYPES.Ascii:
                    return Encoding.ASCII;

                case ENCODING_TYPES.BigEndianUnicode:
                    return Encoding.BigEndianUnicode;

                case ENCODING_TYPES.Unicode:
                    return Encoding.Unicode;

                case ENCODING_TYPES.Utf32:
                    return Encoding.UTF32;

                case ENCODING_TYPES.Utf7:
                    return Encoding.UTF7;

                case ENCODING_TYPES.Utf8:
                    return Encoding.UTF8;

                default:
                    return Encoding.UTF8;
            }
        }

        public static HashAlgorithm GetHashAlgorithm(HASH_ALGORITHM ha)
        {
            switch(ha)
            {
                case HASH_ALGORITHM.Md5:
                    return new MD5CryptoServiceProvider();

                case HASH_ALGORITHM.Sha1:
                    return new SHA1Managed();

                case HASH_ALGORITHM.Sha256:
                    return new SHA256Managed();

                case HASH_ALGORITHM.Sha384:
                    return new SHA384Managed();

                case HASH_ALGORITHM.Sha512:
                    return new SHA512Managed();

                default:
                    return new MD5CryptoServiceProvider();
            }
        }


        public static  string ToHex(byte[] ba)
        {
            if (ba == null || ba.Length == 0)
            {
                return "";
            }

            const string hexFormat = "{0:X2}";
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(string.Format(hexFormat, b));
            }
            return sb.ToString();
        }

        /// <summary>
        /// converts from a string Hex representation to an array of bytes
        /// </summary>
        public static byte[] FromHex(string hexEncoded)
        {
            if (string.IsNullOrEmpty(hexEncoded))
            {
                return null;
            }
            try
            {
                int l = Convert.ToInt32(hexEncoded.Length / 2);
                byte[] b = new byte[l];
                for (int i = 0; i <= l - 1; i++)
                {
                    b[i] = Convert.ToByte(hexEncoded.Substring(i * 2, 2), 16);
                }
                return b;
            }
            catch (Exception ex)
            {
                throw new FormatException("The provided string does not appear to be Hex encoded:" + Environment.NewLine + hexEncoded + Environment.NewLine, ex);
            }
        }
    }
}
