using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetDailySummaryResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
    }

    public class DailySummaryData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("visit_total")]
        public int VisitTotal { get; set; }

        [JsonProperty("share_pv")]
        public int SharePV { get; set; }

        [JsonProperty("share_uv")]
        public int ShareUV { get; set; }
    }
}
