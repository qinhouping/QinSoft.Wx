using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceMPNewsMsg : CustomerServiceMsgBase
    {
        [JsonProperty("mpnews")]
        public CustomerServiceMPNewsMsgContent MPNews { get; set; }

        public CustomerServiceMPNewsMsg()
        {
            this.MsgType = "mpnews";
        }
    }

    public class CustomerServiceMPNewsMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
