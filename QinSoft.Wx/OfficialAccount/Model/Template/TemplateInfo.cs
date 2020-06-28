using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class GetTemplateListResponse
    {
        [JsonProperty("template_list")]
        public TemplateInfo[] TemplateList { get; set; }
    }

    public class TemplateInfo
    {
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("primary_industry")]
        public string PrimaryIndustry { get; set; }

        [JsonProperty("deputy_industry")]
        public string DeputyIndustry { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }
    }
}
