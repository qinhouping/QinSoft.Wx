using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Template
{
    public class DeleteTemplateRequest
    {
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }
}
