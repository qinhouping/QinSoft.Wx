using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Account
{
    public class GetShortUrlRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } = "long2short";

        [JsonProperty("long_url")]
        public string LongUrl { get; set; }
    }
}
