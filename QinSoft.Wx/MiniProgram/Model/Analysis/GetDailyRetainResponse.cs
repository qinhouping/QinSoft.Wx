using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetDailyRetainResponse
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("visit_uv_new")]
        public DailyRetainData[] VisitUVNew { get; set; }

        [JsonProperty("visit_uv")]
        public DailyRetainData[] VisitUV { get; set; }
    }

    public class DailyRetainData
    {
        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
