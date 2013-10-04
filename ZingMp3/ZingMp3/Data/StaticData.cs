using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZingMp3.Data.ViewModel;

namespace ZingMp3.Data
{
    public class StaticData
    {
        public static string HtmlString = "";

        public static string PublicKey = "c2984f3b3487658441a2d1d68fee11d09903a69c";
        public static string PrivateKey = "acdb4afe1c849b6b753c7a1981167bf5";

        public static string requestData = "";
        public static string signature = "";

        public static MainPageViewModel mainPageViewModel = new MainPageViewModel();
    }
}
