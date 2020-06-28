using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetBlackUserListResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public GetBlackUserListResponseData Data { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }

    public class GetBlackUserListResponseData
    {
        [JsonProperty("openid")]
        public string[] OpenId { get; set; }
    }
}
