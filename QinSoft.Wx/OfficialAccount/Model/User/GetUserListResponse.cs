using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class GetUserListResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public GetUserListResponseData Data { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }

    public class GetUserListResponseData
    {
        [JsonProperty("openid")]
        public string[] OpenId { get; set; }
    }
}
