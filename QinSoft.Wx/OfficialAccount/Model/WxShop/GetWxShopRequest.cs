using Newtonsoft.Json;
using QinSoft.Wx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.WxShop
{
    public class GetWxShopRequest
    {
        [JsonProperty("buffer")]
        public string Buffer { get; private set; }

        public GetWxShopRequest(GetWxShopRequestData data)
        {
            this.Buffer = data.ToJson();
        }
    }

    public class GetWxShopRequestData
    {
        [JsonProperty("poi_id")]
        public string PoiId { get; set; }
    }
}
