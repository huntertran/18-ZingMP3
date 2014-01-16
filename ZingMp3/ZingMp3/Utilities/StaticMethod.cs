using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Windows;
using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xBrainLab.Security.Cryptography;
using ZingMp3.Data;
using ZingMp3.Model;

namespace ZingMp3.Utilities
{
    public class StaticMethod
    {
        public static async Task<string> GetHttpAsString(string link)
        {
            WebRequest request = WebRequest.Create(new Uri(link, UriKind.Absolute));
            WebResponse response = await request.GetResponseAsync();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string result = reader.ReadToEnd();

            return result;
        }

        public static async Task<string> GetHttpAsStringGZipAware(string link)
        {
            WebRequest request = WebRequest.Create(new Uri(link, UriKind.Absolute));
            WebResponse response = await request.GetResponseAsync();

            if (response.ContentType.Contains("gzip"))
            {
                var responseGzipStream = new GZipInputStream(response.GetResponseStream());
                StreamReader reader = new StreamReader(responseGzipStream, Encoding.UTF8);
                string result = reader.ReadToEnd();

                return result;
            }
            else
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string result = reader.ReadToEnd();

                return result;
            }
        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }

        public static byte[] StringToAscii(string s)
        {
            byte[] retval = new byte[s.Length];
            for (int ix = 0; ix < s.Length; ++ix)
            {
                char ch = s[ix];
                if (ch <= 0x7f) retval[ix] = (byte)ch;
                else retval[ix] = (byte)'?';
            }
            return retval;
        }

        /// <summary>
        /// Convert from requested data to json
        /// </summary>
        /// <typeparam name="T">must be json1, json2 or json4</typeparam>
        /// <param name="originData">requested data</param>
        /// <returns>return URL Encoded, Base64 Converted from a Json</returns>
        public static string GenerateData<T>(T originData)
        {
            //Convert Data to Json

            string result = JsonConvert.SerializeObject(originData);

            //Convert to Base 64

            //byte[] endBuff = Encoding.GetEncoding("ISO-8859-1").GetBytes(result);
            byte[] endBuff = Encoding.UTF8.GetBytes(result);
            //byte[] endBuff = StringToAscii(result);
            string enc = Convert.ToBase64String(endBuff);

            //Convert to URL
            if (enc.Contains("="))
            {
                result = HttpUtility.UrlEncode(enc);

                //Special Translation
                result = result.Substring(0, result.Length - 6) + "%3D%3D";
                //result = result + "%3D%3D";
            }
            else
            {
                result = HttpUtility.UrlEncode(enc);
            }

            return result;
        }

        /// <summary>
        /// Convert from urlencoded, base 64 encoded to hash with MD5
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string Hash_hmac(string origin)
        {
            string result = origin;

            Encoding encoding = Encoding.UTF8;
            //byte[] keyByte = encoding.GetBytes(StaticData.PrivateKey);
            //byte[] keyByte = Encoding.GetEncoding("ISO-8859-1").GetBytes(StaticData.PrivateKey);
            byte[] keyByte = StringToAscii(StaticData.PrivateKey);

            //Convert to Signature, with HASH_HMAC PHP, MD5, Data, Private Key
            HMACMD5 hmac = new HMACMD5(keyByte);
            //HMACMD5 hmac = new HMACMD5(StaticData.PrivateKey);

            //var messageByte = encoding.GetBytes(result);
            //var messageByte = Encoding.GetEncoding("ISO-8859-1").GetBytes(result);
            //var messageByte = StringToAscii(result);
            byte[] computedHash = hmac.ComputeHash(result);

            result = ByteToString(computedHash);

            return result;
        }

        public static void Quit()
        {
            //throw new QuitException();
            IsolatedStorageSettings.ApplicationSettings.Save();
            Application.Current.Terminate();
        }
    }
}
