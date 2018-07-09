using System;
using System.Security.Cryptography;

namespace com.prjteam.HashUtil
{
    public class StringHashing
    {

        public static string ComputeHash(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, byte[] saltBytes)
        {
            return ComputeHash(plainText, hashAlgorithm, saltBytes, StringUtil.ENCRYPTION_FORMAT.Base64, StringUtil.ENCODING_TYPES.Utf8, StringUtil.SALT_POSITION.Tail, false);
        }

        private static string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

        public static string ComputeHash(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, byte[] saltBytes, StringUtil.ENCRYPTION_FORMAT format, StringUtil.ENCODING_TYPES encodingType, StringUtil.SALT_POSITION saltPosition, bool addSaltToHash)
        {
            string hashValue;

            if (hashAlgorithm == StringUtil.HASH_ALGORITHM.Md5)
                hashValue = GetMd5Hash(plainText);
            else
            {

                // If salt is not specified, generate it on the fly.
                if (saltBytes == null)
                    saltBytes = GenerateRandomSalt();

                // Convert plain text into a byte array.
                byte[] plainTextBytes = StringUtil.GetEncoder(encodingType).GetBytes(plainText);

                // Allocate array, which will hold plain text and salt.
                byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

                if (saltPosition == StringUtil.SALT_POSITION.Tail)
                {
                    // Copy plain text bytes into resulting array.
                    for (int i = 0; i < plainTextBytes.Length; i++)
                        plainTextWithSaltBytes[i] = plainTextBytes[i];

                    // Append salt bytes to the resulting array.
                    for (int i = 0; i < saltBytes.Length; i++)
                        plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
                }
                else
                {

                    // Copy salt bytes into resulting array.
                    for (int i = 0; i < saltBytes.Length; i++)
                        plainTextWithSaltBytes[i] = saltBytes[i];

                    // prefix salt bytes to the resulting array.
                    for (int i = 0; i < plainTextBytes.Length; i++)
                        plainTextWithSaltBytes[saltBytes.Length + i] = plainTextBytes[i];

                }


                // Because we support multiple hashing algorithms, we must define
                // hash object as a common (abstract) base class. We will specify the
                // actual hashing algorithm class later during object creation.

                // Make sure hashing algorithm name is specified.
                //if (hashAlgorithm == null)
                //    hashAlgorithm = "";

                // Initialize appropriate hashing algorithm class.
                HashAlgorithm hash = StringUtil.GetHashAlgorithm(hashAlgorithm);

                // Compute hash value of our plain text with appended salt.
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

                int hashLen;

                if (addSaltToHash)
                    hashLen = hashBytes.Length + saltBytes.Length;
                else
                    hashLen = hashBytes.Length;

                // Create array which will hold hash and original salt bytes.
                byte[] hashWithSaltBytes = new byte[hashLen];

                // Copy hash bytes into resulting array.
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSaltBytes[i] = hashBytes[i];

                if ((addSaltToHash) && (hashAlgorithm != StringUtil.HASH_ALGORITHM.Md5))
                {
                    // Append salt bytes to the result.
                    for (int i = 0; i < saltBytes.Length; i++)
                        hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
                }

                hashValue = GetFormatedStringFromHash(format, hashWithSaltBytes, encodingType);
            
            }

            // Convert result into a base64-encoded string.
            

            // Return the result.
            return hashValue;
        }


        public static bool VerifyHash(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, string hashValue)
        {
            return VerifyHash(plainText, hashAlgorithm, hashValue, StringUtil.ENCRYPTION_FORMAT.Base64, StringUtil.ENCODING_TYPES.Utf8, StringUtil.SALT_POSITION.Tail);
        }

        public static bool VerifyHash(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, string hashValue, StringUtil.ENCRYPTION_FORMAT format, StringUtil.ENCODING_TYPES encodingType, StringUtil.SALT_POSITION saltPosition)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = GetByteArrayFromEncodedString(format, hashValue,encodingType);

            // We must know size of hash (without salt).

            // Size of hash is based on the specified algorithm.                        
            int hashSizeInBits = hashAlgorithm.GetHashCode();
                        
            // Convert size of hash from bits to bytes.
            int hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];


            if (saltPosition == StringUtil.SALT_POSITION.Tail)
            {
                // Copy salt from the end of the hash to the new array.
                for (int i = 0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];
            }
            else
            {
                // Copy salt from the begin of the hash to the new array.
                for (int i = 0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[i];
            }

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText, hashAlgorithm, saltBytes, format, encodingType, saltPosition,true);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }

        public static string HashPasswordFromSaltedPassword(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, string hashValue)
        {
            return HashPasswordFromSaltedPassword(plainText, hashAlgorithm, hashValue, StringUtil.ENCRYPTION_FORMAT.Base64, StringUtil.ENCODING_TYPES.Utf8, StringUtil.SALT_POSITION.Tail);
        }

        public static string HashPasswordFromSaltedPassword(string plainText, StringUtil.HASH_ALGORITHM hashAlgorithm, string hashValue, StringUtil.ENCRYPTION_FORMAT format, StringUtil.ENCODING_TYPES encodingType, StringUtil.SALT_POSITION saltPosition)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = GetByteArrayFromEncodedString(format,hashValue,encodingType);

            // We must know size of hash (without salt).

            // Size of hash is based on the specified algorithm.
            int hashSizeInBits = hashAlgorithm.GetHashCode();
            
            // Convert size of hash from bits to bytes.
            int hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return String.Empty;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            if (saltPosition == StringUtil.SALT_POSITION.Tail)
            {
                // Copy salt from the end of the hash to the new array.
                for (int i = 0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];
            }
            else
            {
                // Copy salt from the begin of the hash to the new array.
                for (int i = 0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[i];
            }

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText, hashAlgorithm, saltBytes,format,encodingType,saltPosition,true);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return  expectedHashString;
        }

        public static byte[] GenerateRandomSalt()
        {
            // Define min and max salt sizes.
                const int minSaltSize = 4;
                const int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                byte[] saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);

                return saltBytes;
            
        }

        public static string GetFormatedStringFromHash(StringUtil.ENCRYPTION_FORMAT format, byte[] hash, StringUtil.ENCODING_TYPES encodingType)
        {
            switch(format)
            {
                case StringUtil.ENCRYPTION_FORMAT.Base64:
                    return Convert.ToBase64String(hash);
                case StringUtil.ENCRYPTION_FORMAT.Hex:
                    return StringUtil.ToHex(hash);
                default:
                    return StringUtil.GetEncoder(encodingType).GetString(hash);
                    
            }
        }

        public static byte[] GetByteArrayFromEncodedString(StringUtil.ENCRYPTION_FORMAT format, string strHash, StringUtil.ENCODING_TYPES encodingType)
        {
            switch (format)
            {
                case StringUtil.ENCRYPTION_FORMAT.Base64:
                    return Convert.FromBase64String(strHash);
                case StringUtil.ENCRYPTION_FORMAT.Hex:
                    return StringUtil.FromHex(strHash);
                default:
                    return StringUtil.GetEncoder(encodingType).GetBytes(strHash);
            }
        }
        
    }
}
