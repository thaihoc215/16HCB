using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebNhaCungCap.Utils
{
    public class HOTPAlgorithm
    {
        private HOTPAlgorithm()
        {
        }
        private static readonly int[] doubleDigits = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

        /// <summary>
        /// Calculates the checksum using the credit card algorithm. This algorithm has the advantage that it detects any single mistyped digit and any single transposition of adjacent digits.
        /// </summary>
        /// <param name="num">the number to calculate the checksum for</param>
        /// <param name="digits">number of significant places in the number</param>
        /// <returns>the checksum of num</returns>
        public static int calcChecksum(long num, int digits)
        {
            bool doubleDigit = true;
            int total = 0;
            while (0 < digits--)
            {
                int digit = (int)(num % 10);
                num /= 10;
                if (doubleDigit)
                {
                    digit = doubleDigits[digit];
                }
                total += digit;
                doubleDigit = !doubleDigit;
            }
            int result = total % 10;
            if (result > 0)
            {
                result = 10 - result;
            }
            return result;
        }

        /// <summary>
        /// This method uses the JCE to provide the HMAC-SHA-1 algorithm. HMAC computes a Hashed Message Authentication Code and in this case SHA1 is the hash algorithm used.
        /// </summary>
        /// <param name="keyBytes">the bytes to use for the HMAC-SHA-1 key</param>
        /// <param name="text">the message or text to be authenticated.</param>
        /// <returns></returns>
        public static byte[] hmac_sha1(byte[] keyBytes, byte[] text)
        {

            HMACSHA1 hmacSha1;
            hmacSha1 = new HMACSHA1(keyBytes);
            hmacSha1.Initialize();
            return hmacSha1.ComputeHash(text);

        }
        private static readonly int[] DIGITS_POWER // 0 1  2   3    4     5      6       7        8
           = { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };


        /// <summary>
        /// This method generates an OTP value for the given set of parameters.
        /// </summary>
        /// <param name="secret">the shared secret</param>
        /// <param name="movingFactor">the counter, time, or other value that changes on a per use basis.</param>
        /// <param name="codeDigits">the number of digits in the OTP, not including the checksum, if any.</param>
        /// <param name="addChecksum">a flag that indicates if a checksum digit should be appended to the OTP.</param>
        /// <param name="truncationOffset">the offset into the MAC result to begin truncation.If this value is out of the range of 0 ... 15, then dynamic truncation will be used. Dynamic truncation is when the last 4 bits of the last byte of the MAC are used to determine the start offset.</param>
        /// <returns>A numeric String in base 10 that includes</returns>
        static public String generateOTP(byte[] secret,
           long movingFactor,
           int codeDigits,
           bool addChecksum,
           int truncationOffset)
        {
            // put movingFactor value into text byte array
            String result = null;
            int digits = addChecksum ? (codeDigits + 1) : codeDigits;
            byte[] text = new byte[8];
            for (int i = text.Length - 1; i >= 0; i--)
            {
                text[i] = (byte)(movingFactor & 0xff);
                movingFactor >>= 8;
            }

            // compute hmac hash
            byte[] hash = hmac_sha1(secret, text);

            // put selected bytes into result int
            int offset = hash[hash.Length - 1] & 0xf;
            if ((0 <= truncationOffset)
                    && (truncationOffset < (hash.Length - 4)))
            {
                offset = truncationOffset;
            }
            int binary
                    = ((hash[offset] & 0x7f) << 24)
                    | ((hash[offset + 1] & 0xff) << 16)
                    | ((hash[offset + 2] & 0xff) << 8)
                    | (hash[offset + 3] & 0xff);

            int otp = binary % DIGITS_POWER[codeDigits];
            if (addChecksum)
            {
                otp = (otp * 10) + calcChecksum(otp, codeDigits);
            }
            result = otp.ToString();
            while (result.Length < digits)
            {
                result = "0" + result;
            }
            return result;
        }
    }

}