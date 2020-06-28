using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetTagUserListResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public GetTagUserListResponseData Data { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }

    public class GetTagUserListResponseData
    {
        [JsonProperty("openid")]
        public string[] OpenId { get; set; }
    }
}
