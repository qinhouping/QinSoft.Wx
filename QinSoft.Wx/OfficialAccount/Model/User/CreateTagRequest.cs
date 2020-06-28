using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class CreateTagRequest
    {
        [JsonProperty("tag")]
        public CreateTagRequestInfo Tag { get; set; }
    }

    public class CreateTagRequestInfo
    {
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
