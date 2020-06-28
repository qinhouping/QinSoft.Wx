using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class GetTemplateIdRequest
    {
        [JsonProperty("template_id_short")]
        public string TemplateIdShort { get; set; }
    }
}
