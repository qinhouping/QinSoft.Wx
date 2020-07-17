using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetVisitPageResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("page_path")]
        public string PagePath { get; set; }

        [JsonProperty("page_visit_pv")]
        public int PageVisitPV { get; set; }

        [JsonProperty("page_visit_uv")]
        public int PageVisitUV { get; set; }

        [JsonProperty("page_staytime_pv")]
        public double PageStaytimePV { get; set; }

        [JsonProperty("entrypage_pv")]
        public int EntrypagPV { get; set; }

        [JsonProperty("exitpage_pv")]
        public int ExitpagePV { get; set; }

        [JsonProperty("page_share_pv")]
        public int PageSharePV { get; set; }

        [JsonProperty("page_share_uv")]
        public int PageShareUV { get; set; }
    }
}
