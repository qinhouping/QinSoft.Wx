using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class TemplateIndustryInfo
    {
        [JsonProperty("first_class")]
        public string FirstClass { get; set; }

        [JsonProperty("second_class")]
        public string SecondClass { get; set; }
    }
}
