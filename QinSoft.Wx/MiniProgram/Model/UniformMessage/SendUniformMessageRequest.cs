using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.UniformMessage
{
    public class SendUniformMessageRequest
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("weapp_template_msg")]
        public UniformMessageMiniProgramTemplate WeAppTemplateMsg { get; set; }

        [JsonProperty("mp_template_msg")]
        public UniformMessageOfficailAccountTemplate MPTemplateMsg { get; set; }
    }

    public class UniformMessageMiniProgramTemplate
    {
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("form_id")]
        public string FormId { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, UniformMessageMiniProgramTemplateData> Data { get; set; }

        [JsonProperty("emphasis_keyword")]
        public string EmphasisKeyword { get; set; }
    }

    public class UniformMessageMiniProgramTemplateData
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UniformMessageOfficailAccountTemplate
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("miniprogram")]
        public UniformMessageOfficailAccountTemplateMiniProgram MiniProgram { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, UniformMessageOfficailAccountTemplateData> Data { get; set; }
    }

    public class UniformMessageOfficailAccountTemplateMiniProgram
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }
    }

    public class UniformMessageOfficailAccountTemplateData
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
