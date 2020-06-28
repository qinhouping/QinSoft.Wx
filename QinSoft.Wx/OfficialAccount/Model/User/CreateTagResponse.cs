using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class CreateTagResponse
    {
        [JsonProperty("tag")]
        public CreateTagResponseInfo Tag { get; set; }
    }

    public class CreateTagResponseInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
