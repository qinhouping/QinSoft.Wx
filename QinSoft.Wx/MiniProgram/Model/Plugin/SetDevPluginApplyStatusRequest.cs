using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class SetDevPluginApplyStatusRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("appid")]
        public string Appid { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
