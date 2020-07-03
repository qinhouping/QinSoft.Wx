using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetUserSummaryResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("list")]
        public GetUserSummaryResponseData[] List { get; set; }
    }

    public class GetUserSummaryResponseData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("user_source")]
        public int UserSource { get; set; }

        [JsonProperty("new_user")]
        public int NewUser { get; set; }

        [JsonProperty("cancel_user")]
        public int CancelUser { get; set; }
    }
}
