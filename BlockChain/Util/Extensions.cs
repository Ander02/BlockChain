using BlockChain.Structure;
using System;

namespace BlockChain.Util
{
    public static class Extensions
    {
        public static string ToBase64(this byte[] buffer) => Convert.ToBase64String(buffer);

        public static byte[] FromBase64(this string base64) => Convert.FromBase64String(base64);

        public static bool NotEquals(this object obj1, object obj2) => !obj1.Equals(obj2);

    }
}
