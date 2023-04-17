using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Hash
    {
        public enum HashType
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512
        }

        public static string GetHash(string input, HashType hashType)
        {
            var hashAlgorithm = GetHashAlgorithm(hashType);
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in data)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        private static HashAlgorithm GetHashAlgorithm(HashType hashType)
        {
            switch (hashType)
            {
                case HashType.MD5:
                    return MD5.Create();
                case HashType.SHA1:
                    return SHA1.Create();
                case HashType.SHA256:
                    return SHA256.Create();
                case HashType.SHA384:
                    return SHA384.Create();
                case HashType.SHA512:
                    return SHA512.Create();
                default:
                    throw new ArgumentOutOfRangeException(nameof(hashType), hashType, "Unsupported hash type.");
            }
        }
    }
}
