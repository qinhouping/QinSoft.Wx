using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class AddKFAccountRequest
    {
        [JsonProperty("kf_account")]
        public string KFAccount { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }
    }
}
