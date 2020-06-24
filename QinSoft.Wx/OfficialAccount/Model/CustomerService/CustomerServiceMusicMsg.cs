using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceMusicMsg : CustomerServiceMsgBase
    {
        [JsonProperty("music")]
        public CustomerServiceMusicMsgContenet Music { get; set; }

        public CustomerServiceMusicMsg()
        {
            this.MsgType = "music";
        }
    }

    public class CustomerServiceMusicMsgContenet
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("musicurl")]
        public string MusicUrl { get; set; }

        [JsonProperty("hqmusicurl")]
        public string HQMusicUrl { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
