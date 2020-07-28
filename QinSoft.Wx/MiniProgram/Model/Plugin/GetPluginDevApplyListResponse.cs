using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class GetPluginDevApplyListResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("apply_list")]
        public PluginDevApplyData[] ApplyList { get; set; }
    }
    public class PluginDevApplyData
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        [JsonProperty("categories")]
        public PluginDevApplyDataCategorie[] Categories { get; set; }

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        [JsonProperty("apply_url")]
        public string ApplyUrl { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public class PluginDevApplyDataCategorie
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("second")]
        public string Second { get; set; }
    }
}
