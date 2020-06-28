using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class GetTemplateIndustryResponse
    {
        [JsonProperty("primary_industry")]
        public TemplateIndustryInfo PrimaryIndustry { get; set; }

        [JsonProperty("secondary_industry")]
        public TemplateIndustryInfo SecondaryIndustry { get; set; }
    }
}
