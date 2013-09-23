using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
    }
}
