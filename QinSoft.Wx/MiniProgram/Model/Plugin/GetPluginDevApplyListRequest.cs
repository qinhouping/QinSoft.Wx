using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class GetPluginDevApplyListRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } = "dev_apply_list";

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("num")]
        public int Num { get; set; }
    }
}
