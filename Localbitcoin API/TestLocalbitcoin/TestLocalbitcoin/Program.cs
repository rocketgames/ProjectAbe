using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SC;

namespace TestLocalbitcoin
{
    class Program
    {
        const string secret = "e723aef2ea46d9b705f23fb6ed54536b";

        static void Main(string[] args)
        {
            /*
 Signature is sent via HTTP headers. A total of three fields are needed:

    Apiauth-Key: API authentication key.
    Apiauth-Nonce: The nonce in this particular request.
    Apiauth-Signature: HMAC signature.
            */


            const string relativeURL = "/api/myself/";
            string nonce = DateTime.UtcNow.Ticks.ToString();

            // get the mac hash
            string hash = MacHasher.API_Create_Hash(nonce, secret, relativeURL, string.Empty);

            // build the url
            string url = string.Format("https://localbitcoins.com{0}", relativeURL);

            // build the header
            string header = string.Format("Apiauth-Key={0}&Apiauth-Nonce{1}&Apiauth-Signature={2}",
                secret,
                nonce,
                hash);

            Console.WriteLine(url);
            Console.WriteLine(header);
            Console.WriteLine(CallToService_GET(url, secret, nonce, hash));

            Console.WriteLine("FINSIHED");
            Console.ReadLine();
        }


        /// <summary>
        /// Calls to the webservice
        /// </summary>
        /// <returns></returns>
        public static string CallToService_GET(string URL, string headerKey, string headerNonce, string headerHash)
        {
            // set content header and length
            HttpWebRequest BitcoinWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            BitcoinWebRequest.Method = "GET";

            BitcoinWebRequest.Headers.Add("Apiauth-Key", headerKey);
            BitcoinWebRequest.Headers.Add("Apiauth-Nonce", headerNonce);
            BitcoinWebRequest.Headers.Add("Apiauth-Signature", headerHash);

            // call the service
            using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)BitcoinWebRequest.GetResponse())
            {
                using (Stream responseStream = myHttpWebResponse.GetResponseStream())
                {
                    StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);

                    // read the data
                    return myStreamReader.ReadToEnd();
                }
            }
        }
    }
}
