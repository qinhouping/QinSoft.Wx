using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Subscribe
{
    public class SubscribeMessage
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("miniprogram")]
        public SubscribeMessageMiniProgram MiniProgram { get; set; }

        [JsonProperty("scene")]
        public string Scene { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("data")]
        public SubscribeMessageData Data { get; set; }
    }

    public class SubscribeMessageMiniProgram
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }
    }

    public class SubscribeMessageKeyWord
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public class SubscribeMessageData : Dictionary<string, SubscribeMessageKeyWord> { }
}
