using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class GetMaterialCountResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("voice_count")]
        public string VoiceCount { get; set; }

        [JsonProperty("video_count")]
        public string VideoCount { get; set; }

        [JsonProperty("image_count")]
        public string ImageCount { get; set; }

        [JsonProperty("news_count")]
        public string NewsCount { get; set; }
    }
}
