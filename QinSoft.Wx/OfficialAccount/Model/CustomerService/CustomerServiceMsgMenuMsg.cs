using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceMsgMenuMsg : CustomerServiceMsgBase
    {
        [JsonProperty("msgmenu")]
        public CustomerServiceMsgMenuMsgContent MsgMenu { get; set; }

        public CustomerServiceMsgMenuMsg()
        {
            this.MsgType = "msgmenu";
        }
    }

    public class CustomerServiceMsgMenuMsgContent
    {
        [JsonProperty("head_content")]
        public string HeadContent { get; set; }

        [JsonProperty("tail_content")]
        public string TailContent { get; set; }

        [JsonProperty("list")]
        public CustomerServiceMsgMenuMsgContentItem[] List { get; set; }
    }

    public class CustomerServiceMsgMenuMsgContentItem
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
