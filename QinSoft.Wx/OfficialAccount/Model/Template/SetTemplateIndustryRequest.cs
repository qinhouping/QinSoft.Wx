using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class SetTemplateIndustryRequest
    {
        [JsonProperty("industry_id1")]
        public string IndustryId1 { get; set; }

        [JsonProperty("industry_id2")]
        public string IndustryId2 { get; set; }
    }
}
