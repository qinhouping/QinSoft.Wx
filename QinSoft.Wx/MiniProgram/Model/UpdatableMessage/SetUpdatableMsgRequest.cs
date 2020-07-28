using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.UpdatableMessage
{
    public class SetUpdatableMsgRequest
    {
        [JsonProperty("activity_id")]
        public string ActivityId { get; set; }

        [JsonProperty("target_state")]
        public int TargetState { get; set; }

        [JsonProperty("template_info")]
        public SetUpdatableMsgTemplateInfo TemplateInfo { get; set; }
    }

    public class SetUpdatableMsgTemplateInfo
    {
        [JsonProperty("parameter_list")]
        public SetUpdatableMsgTemplateInfoParameter[] ParameterList { get; set; }
    }

    public class SetUpdatableMsgTemplateInfoParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
