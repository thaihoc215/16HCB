using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebNhaCungCap.Utils
{
    public class Utils
    {
        /// <summary>
        /// Key phải đồng nhất với key ở android
        /// </summary>
        private const int KEY_TIME = 95369;
        public static string GetSecurityCode(string tokenUser)
        {
            long longtime = CurrentMillis.CurrentTimeMillis;
            longtime = longtime - longtime % 60000 + KEY_TIME;
            tokenUser += "_" + longtime;

            byte[] code = Encoding.ASCII.GetBytes(tokenUser);
            return HOTPAlgorithm.generateOTP(code, 7, 6, false, 7);
        }

        public static string GetSecurityCodeBackup(string tokenUser, int index)
        {
            string longtime = CurrentMillis.CurrentTimeMillis.ToString();
            longtime = longtime.Substring(0, longtime.Length - 5) + KEY_TIME;
            tokenUser += "_" + longtime;

            byte[] code = Encoding.ASCII.GetBytes(tokenUser);
            return HOTPAlgorithm.generateOTP(code, index, 8, false, index);
        }

        public static string GenKey12Digit(string primaryKey)
        {

            HashAlgorithm algorithm = SHA1.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(primaryKey.ToString()));
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < 6; ++i)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }


    }
}