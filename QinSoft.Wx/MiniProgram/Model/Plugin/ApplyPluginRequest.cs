using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class ApplyPluginRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("plugin_appid")]
        public string PluginAppId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
