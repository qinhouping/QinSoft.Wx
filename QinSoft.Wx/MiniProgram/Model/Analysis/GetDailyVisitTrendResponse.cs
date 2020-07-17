using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetDailyVisitTrendResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
        [JsonProperty("list")]
        public DailyVisitTrendData[] List { get; set; }
    }
    public class DailyVisitTrendData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("session_cnt")]
        public int SessionCnt { get; set; }

        [JsonProperty("visit_pv")]
        public int VisitPV { get; set; }

        [JsonProperty("visit_uv")]
        public int VisitUV { get; set; }

        [JsonProperty("visit_uv_new")]
        public int VisitUVNew { get; set; }

        [JsonProperty("stay_time_uv")]
        public double StayTimeUV { get; set; }

        [JsonProperty("stay_time_session")]
        public double StayTimeSession { get; set; }

        [JsonProperty("visit_depth")]
        public double VisitDepth { get; set; }
    }
}
