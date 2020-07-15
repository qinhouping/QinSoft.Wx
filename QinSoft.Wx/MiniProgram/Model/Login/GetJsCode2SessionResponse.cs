using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Login
{
    public class GetJsCode2SessionResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
