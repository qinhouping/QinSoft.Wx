using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Web
{
    public class GetOAuth2UserInfoResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }


        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        [JsonProperty("privilege")]
        public string[] Privilege { get; set; }

        [JsonProperty("unionid")]
        public string Unionid { get; set; }
    }
}
