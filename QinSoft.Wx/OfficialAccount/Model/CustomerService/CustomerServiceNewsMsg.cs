using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceNewsMsg : CustomerServiceMsgBase
    {
        [JsonProperty("news")]
        public CustomerServiceNewsMsgContent News { get; set; }
        public CustomerServiceNewsMsg()
        {
            this.MsgType = "news";
        }
    }

    public class CustomerServiceNewsMsgContent
    {
        [JsonProperty("articles")]
        public CustomerServiceNewsMsgContentItem[] Articles { get; set; }
    }

    public class CustomerServiceNewsMsgContentItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("picurl")]
        public string PicUrl { get; set; }
    }
}
