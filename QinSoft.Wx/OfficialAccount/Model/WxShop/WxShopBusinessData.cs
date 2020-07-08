using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.WxShop
{
    public class WxShopBusinessData
    {
        [JsonProperty("base_info")]
        public WxShopBusinessBaseInfoData BaseInfo { get; set; }
    }

    public class WxShopBusinessBaseInfoData
    {
        [JsonProperty("sid")]
        public string SId { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("branch_name")]
        public string BranchName { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("offset_type")]
        public int OffsetType { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("photo_list")]
        public WxShopBusinessBaseInfoPhotoData[] PhotoList { get; set; }

        [JsonProperty("recommend")]
        public string Recommend { get; set; }

        [JsonProperty("special")]
        public string Special { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        [JsonProperty("open_time")]
        public string OpenTime { get; set; }

        [JsonProperty("avg_price")]
        public int AvgPrice { get; set; }
    }

    public class WxShopBusinessBaseInfoPhotoData
    {
        [JsonProperty("photo_url")]
        public string PhotoUrl { get; set; }
    }
}
