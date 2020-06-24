using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceMsgBase
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("msgtype")]
        public string MsgType { get; set; }

        [JsonProperty("customservice")]

        public MsgCustomerService CustomerService { get; set; }
    }
}
