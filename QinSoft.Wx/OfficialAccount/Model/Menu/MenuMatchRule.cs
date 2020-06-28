using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    [WxDocument(Url = "https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Personalized_menu_interface.html")]
    public class MenuMatchRule
    {
        [JsonProperty("tag_id")]
        public string TagId { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("client_platform_type")]
        public string ClientPlatformType { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
