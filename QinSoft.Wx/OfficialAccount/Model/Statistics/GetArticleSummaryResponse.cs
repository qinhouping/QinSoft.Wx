using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetArticleSummaryResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("list")]
        public GetArticleSummaryResponseData List { get; set; }
    }

    public class GetArticleSummaryResponseData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("msgid")]
        public string msgid { get; set; }

        [JsonProperty("title")]
        public string Titel { get; set; }

        [JsonProperty("int_page_read_user")]
        public int IntPageReadUser { get; set; }

        [JsonProperty("int_page_read_count")]
        public int IntPageReadCount { get; set; }

        [JsonProperty("ori_page_read_user")]
        public int OriPageReadUser { get; set; }

        [JsonProperty("ori_page_read_count")]
        public int OriPageReadCount { get; set; }

        [JsonProperty("share_user")]
        public int ShareUser { get; set; }

        [JsonProperty("share_count")]
        public int ShareCount { get; set; }

        [JsonProperty("add_to_fav_user")]
        public int AddToFavUser { get; set; }

        [JsonProperty("add_to_fav_count")]
        public int AddToFavCount { get; set; }
    }
}
