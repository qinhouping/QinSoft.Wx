using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetUserCumulateResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("list")]
        public GetUserCumulateResponseData[] List { get; set; }
    }

    public class GetUserCumulateResponseData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("cumulate_user")]
        public int CumulateUser { get; set; }
    }
}
