using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceWxCardMsg : CustomerServiceMsgBase
    {
        [JsonProperty("wxcard")]
        public CustomerServiceWxCardMsgContent WxCard { get; set; }

        public CustomerServiceWxCardMsg()
        {
            this.MsgType = "wxcard";
        }
    }

    public class CustomerServiceWxCardMsgContent
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }
    }
}
