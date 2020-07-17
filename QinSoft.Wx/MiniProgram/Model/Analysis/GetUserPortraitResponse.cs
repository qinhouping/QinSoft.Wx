using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Analysis
{
    public class GetUserPortraitResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("visit_uv_new")]
        public UserPortraitData VisitUVNew { get; set; }

        [JsonProperty("visit_uv")]
        public UserPortraitData VisitUV { get; set; }
    }

    public class UserPortraitData
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("province")]
        public UserPortraitDataDetail Province { get; set; }

        [JsonProperty("city")]
        public UserPortraitDataDetail City { get; set; }

        [JsonProperty("genders")]
        public UserPortraitDataDetail Genders { get; set; }

        [JsonProperty("platforms")]
        public UserPortraitDataDetail Platforms { get; set; }

        [JsonProperty("devices")]
        public UserPortraitDataDetail Devices { get; set; }

        [JsonProperty("ages")]
        public UserPortraitDataDetail Ages { get; set; }
    }

    public class UserPortraitDataDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("access_source_visit_uv")]
        public int AccessSourceVisitUV { get; set; }
    }
}
