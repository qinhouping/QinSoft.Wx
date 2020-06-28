using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class TemplateMessage
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("miniprogram")]
        public TemplateMessageMiniProgram MiniProgram { get; set; }

        [JsonProperty("data")]
        public TemplateMessageData Data { get; set; }
    }

    public class TemplateMessageMiniProgram
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }
    }

    public class TemplateMessageKeyWord
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public class TemplateMessageData : Dictionary<string, TemplateMessageKeyWord> { }
}
