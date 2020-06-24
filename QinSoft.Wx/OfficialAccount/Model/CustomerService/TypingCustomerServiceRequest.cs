using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class TypingCustomerServiceRequest
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
