using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class CustomerServiceLinkMsg : CustomerServiceMsgBase
    {
        [JsonProperty("link")]
        public CustomerServiceImageMsgContent Link { get; set; }

        public CustomerServiceLinkMsg()
        {
            this.MsgType = "link";
        }
    }

    public class CustomerServiceLinkMsgContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
    }
}
