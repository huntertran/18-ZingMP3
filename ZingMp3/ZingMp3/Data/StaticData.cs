using ZingMp3.Data.ViewModel;
using ZingMp3.Model;

namespace ZingMp3.Data
{
    public class StaticData
    {
        public static string HtmlString = "";

        public static string PublicKey = "c2984f3b3487658441a2d1d68fee11d09903a69c";
        public static string PrivateKey = "acdb4afe1c849b6b753c7a1981167bf5";

        public static string requestData = "";
        public static string signature = "";

        public static HotSongsViewModel _hotSongsViewModel = new HotSongsViewModel();
        public static HotAlbumsViewModel HotAlbumsViewModel = new HotAlbumsViewModel();
        public static HotVideosViewModel HotVideosViewModel = new HotVideosViewModel();

        public static bool isOffline = false;

        public static int openCount = 0;

        public static CheckParameterData checkParameterData = new CheckParameterData();
        public static string appVersion;
        public static bool EnableAppLink = false;
    }
}
