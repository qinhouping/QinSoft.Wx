using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewMPVideoMsg : MassPreviewMsgBase
    {
        [JsonProperty("mpvideo")]
        public MassPreviewVoiceMsgContent MPVideo { get; set; }

        public MassPreviewMPVideoMsg()
        {
            this.MsgType = "mpvideo";
        }
    }

    public class MassPreviewMPVideoMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
