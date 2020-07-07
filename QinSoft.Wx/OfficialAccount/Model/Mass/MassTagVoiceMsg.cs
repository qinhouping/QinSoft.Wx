using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagVoiceMsg : MassTagMsgBase
    {
        [JsonProperty("voice")]
        public MassTagVoiceMsgContent Voice { get; set; }

        public MassTagVoiceMsg()
        {
            this.MsgType = "voice";
        }
    }

    public class MassTagVoiceMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
