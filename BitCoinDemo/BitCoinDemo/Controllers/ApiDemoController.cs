using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Text;
using System.Security.Cryptography;

namespace BitCoinDemo.Controllers
{
    public class ApiDemoController : ApiController
    {
       // [AcceptVerbs("Get","GetSomething/id")]
        [AcceptVerbs("Get")]
        public AuthKey GetAuthenticationKey(string url, string key, string currentTime ) {

            string myKey = key == null ? "this-is-my-secret": key;
            string myUrl = url == null ? "/example/endpoint" : url;
            string myTime = currentTime == null ? "2014-06-03T17:48:47.774453" : DateTime.Now.ToUniversalTime().ToString();

            AuthKey auth = new AuthKey(myUrl, myKey, myTime);
           return auth;
                       

        }

             
    }

    
    public class AuthKey
    {

        public string TargetURL { get; set; }
        public string SecretKey { get; set; }
        public string EncrytpedKey { get; set; }
        public string Timestamp { get; set; }
        public string HeaderString { get; set; }

        public AuthKey(string url, string key, string timestamp){

            this.TargetURL = url;
            this.SecretKey = key;
            this.Timestamp = timestamp;
            this.EncrytpedKey = GetEncryptedKey();
            this.HeaderString = string.Format("X-CK-Key: K36e69e8c-114ce276-e3148282a78f3da5  X-CK-Sign: {0}  X-CK-Timestamp: {1}", this.EncrytpedKey, this.Timestamp);

        }

      

        private string GetEncryptedKey()
        {
            
            string dataToEncrypt = string.Format("{0}|{1}",this.TargetURL, Timestamp );
           

            // get the bytes of the secret
            HMACSHA256 hmacsha1 = new HMACSHA256(Encoding.UTF8.GetBytes(this.SecretKey));

            // hash the message and the time
            byte[] hashmessage = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(dataToEncrypt));

            // return the string
            return ByteToString(hashmessage);
           
        }
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
                sb.Append(buff[i].ToString("x2"));

            return sb.ToString();
        }

        // ByteToString
        #endregion



    }
}
