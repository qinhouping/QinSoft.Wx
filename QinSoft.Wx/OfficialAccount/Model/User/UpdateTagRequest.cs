using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class UpdateTagRequest
    {
        [JsonProperty("tag")]
        public UpdateTagRequestInfo Tag { get; set; }
    }

    public class UpdateTagRequestInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
