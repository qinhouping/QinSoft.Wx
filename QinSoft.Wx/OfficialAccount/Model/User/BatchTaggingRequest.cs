using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class BatchTaggingRequest
    {
        [JsonProperty("openid_list")]
        public string[] OpenIdList { get; set; }

        [JsonProperty("tagid")]
        public int TagId { get; set; }
    }
}
