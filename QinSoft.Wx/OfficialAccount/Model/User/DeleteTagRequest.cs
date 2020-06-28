using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class DeleteTagRequest
    {
        [JsonProperty("tag")]
        public DeleteTagRequestInfo Tag { get; set; }
    }

    public class DeleteTagRequestInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
