using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetUserReadResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("list")]
        public GetUserReadResponseData[] List { get; set; }
    }

    public class GetUserReadResponseData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("user_source")]
        public int UserSource { get; set; }

        [JsonProperty("int_page_read_user")]
        public string IntPageReadUser { get; set; }

        [JsonProperty("int_page_read_count")]
        public string IntPageReadCount { get; set; }

        [JsonProperty("ori_page_read_user")]
        public string OriPageReadUser { get; set; }

        [JsonProperty("ori_page_read_count")]
        public string OriPageReadCount { get; set; }

        [JsonProperty("share_user")]
        public string ShareUser { get; set; }

        [JsonProperty("share_count")]
        public string ShareCount { get; set; }

        [JsonProperty("add_to_fav_user")]
        public string AddToFavUser { get; set; }

        [JsonProperty("add_to_fav_count")]
        public string AddToFavCount { get; set; }
    }
}
