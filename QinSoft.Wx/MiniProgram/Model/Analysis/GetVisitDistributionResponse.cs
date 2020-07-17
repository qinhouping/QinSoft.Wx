using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetVisitDistributionResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("list")]
        public VisitDistributionData[] List { get; set; }
    }

    public class VisitDistributionData
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("item_list")]
        public VisitDistributionDataItem[] TtemList { get; set; }
    }

    public class VisitDistributionDataItem
    {
        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("access_source_visit_uv")]
        public int AccessSourceVisitUV { get; set; }
    }
}
