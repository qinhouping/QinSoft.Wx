using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewVoiceMsg : MassPreviewMsgBase
    {
        [JsonProperty("voice")]
        public MassPreviewVoiceMsgContent Voice { get; set; }

        public MassPreviewVoiceMsg()
        {
            this.MsgType = "voice";
        }
    }

    public class MassPreviewVoiceMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
