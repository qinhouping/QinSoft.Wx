using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class UpdateRemarkRequest
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}
