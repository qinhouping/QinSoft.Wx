using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class UnbindPluginRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } = "unbind";

        [JsonProperty("plugin_appid")]
        public string PluginAppid { get; set; }
    }
}
