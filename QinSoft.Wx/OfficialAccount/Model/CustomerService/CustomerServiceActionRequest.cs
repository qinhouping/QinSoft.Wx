using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceActionRequest
    {
        [JsonProperty("kf_account")]
        public string Account { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
