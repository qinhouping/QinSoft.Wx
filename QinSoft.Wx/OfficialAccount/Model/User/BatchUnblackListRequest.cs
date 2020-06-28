using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class BatchUnblackListRequest
    {
        [JsonProperty("openid_list")]
        public string[] OpenIdList { get; set; }
    }
}
