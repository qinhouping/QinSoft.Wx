using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetUserTagListRequest
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}
