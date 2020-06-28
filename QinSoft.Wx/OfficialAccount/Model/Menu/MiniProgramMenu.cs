using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class MiniProgramMenu : MenuBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }

        public MiniProgramMenu()
        {
            this.Type = "miniprogram";
        }
    }
}
