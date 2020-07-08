using Newtonsoft.Json;
using QinSoft.Wx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.WxShop
{
    public class GetWxShopListRequest
    {
        [JsonProperty("buffer")]
        public string Buffer { get; private set; }

        public GetWxShopListRequest(GetWxShopListRequestData data)
        {
            this.Buffer = data.ToJson();
        }
    }

    public class GetWxShopListRequestData
    {
        [JsonProperty("begin")]
        public int Begin { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
