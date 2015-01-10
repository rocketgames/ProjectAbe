using System;
using System.Text;
using System.Security.Cryptography;

namespace SC
{
    public class MacHasher
    {
        #region API_Create_Hash

        /// <summary>
        /// Creates the hash
        /// </summary>
        /// <param name="relativeURL">Relative path, for example /api/wallet/.</param>
        /// <param name="timeTicksNonce">DateTime.UtcNow.Ticks.ToString()</param>
        /// <param name="URLparams">GET or POST parameters in their URL encoded format, for example foo=bar&amp;baz=quux.</param>
        /// <returns></returns>
        public static string API_Create_Hash(string timeTicksNonce, string secret, string relativeURL, string URLparams)
        {
            string message = string.Format("{0}{1}{2}{3}",
                timeTicksNonce, // nonce
                secret, // api secret key
                relativeURL,
                URLparams);

            // get the bytes of the secret
            HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(secret));
            
            // hash the message and the time
            byte[] hashmessage = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(message));

            // return the string
            return BitConverter.ToString(hashmessage);
        }

        // API_Create_Hash
        #endregion

        #region ByteToString

        /// <summary>
        /// Converts a byte array to a string
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        private static string ByteToString(byte[] buff)
        {
            StringBuilder sb = new StringBuilder();
            int j = buff.Length;
            for (int i = 0; i < j; i++)
                sb.Append(buff[i].ToString("X2"));

            return sb.ToString();
        }

        // ByteToString
        #endregion
    }
}