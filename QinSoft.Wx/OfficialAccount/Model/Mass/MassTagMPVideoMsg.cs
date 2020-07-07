using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagMPVideoMsg : MassTagMsgBase
    {
        [JsonProperty("mpvideo")]
        public MassTagVoiceMsgContent mpvideo { get; set; }

        public MassTagMPVideoMsg()
        {
            this.MsgType = "mpvideo";
        }
    }

    public class MassTagMPVideoMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
