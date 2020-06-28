using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetTagUserListRequest
    {
        [JsonProperty("tagid")]
        public int TagId { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }
}
