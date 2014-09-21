namespace LunchDictator.Web.Core
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class HashHelper
    {
        public static string GetHash(string str)
        {
            var hash = MD5.Create();
            return Convert.ToBase64String(hash.ComputeHash(Encoding.Default.GetBytes(str)));
        }
    }
}