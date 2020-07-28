using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.Plugin
{
    public class GetPluginListResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("plugin_list")]
        public PluginData[] PluginList { get; set; }
    }

    public class PluginData
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }
    }
}
