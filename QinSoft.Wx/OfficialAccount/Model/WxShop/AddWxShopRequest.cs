using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QinSoft.Wx.Common;

namespace QinSoft.Wx.OfficialAccount.Model.WxShop
{
    [WxDocument(Url = "https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html")]
    public class AddWxShopRequest
    {
        [JsonProperty("buffer")]
        public string Buffer { get; private set; }

        public AddWxShopRequest(AddWxShopData data)
        {
            this.Buffer = data.ToJson();
        }
    }

    public class AddWxShopData
    {
        [JsonProperty("business")]
        public WxShopBusinessData Business { get; set; }
    }
}
