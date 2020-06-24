using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceVideoMsg : CustomerServiceMsgBase
    {
        [JsonProperty("video")]
        public CustomerServiceVideoMsgContent Video { get; set; }

        public CustomerServiceVideoMsg()
        {
            this.MsgType = "video";
        }
    }

    public class CustomerServiceVideoMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
