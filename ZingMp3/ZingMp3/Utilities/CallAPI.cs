using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZingMp3.Data;
using ZingMp3.Model;

namespace ZingMp3.Utilities
{
    public class CallAPI
    {
        public static string LinkBuilder(string publicKey, string signature, string requestData, string api)
        {
            string link = "http://api.mp3.zing.vn/api/" + api
                          + "?publicKey=" + publicKey
                          + "&signature=" + signature
                          + "&jsondata=" + requestData;
            return link;
        }

        public static async Task<ObservableCollection<MusicItem>> GetHotContentTask()
        {
            ObservableCollection<MusicItem> resultCollection = new ObservableCollection<MusicItem>();

            JsonData1 jsonData = new JsonData1();
            jsonData.t = "song";

            StaticData.requestData = StaticMethod.GenerateData(jsonData);
            StaticData.signature = StaticMethod.Hash_hmac(StaticData.requestData);

            string link = LinkBuilder(StaticData.PublicKey, StaticData.signature, StaticData.requestData, "hot-content");

            JObject jObject = JObject.Parse(await StaticMethod.GetHttpAsString(link));

            return resultCollection;
        }
    }
}
