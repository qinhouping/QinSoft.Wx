using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetBlackUserListRequest
    {
        [JsonProperty("begin_openid")]
        public string BeginOpenId { get; set; }
    }
}
