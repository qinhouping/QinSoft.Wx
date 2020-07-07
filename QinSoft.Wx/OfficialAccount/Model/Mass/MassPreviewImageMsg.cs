using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewImageMsg : MassPreviewMsgBase
    {
        [JsonProperty("image")]
        public MassPreviewVoiceMsgContent Image { get; set; }

        public MassPreviewImageMsg()
        {
            this.MsgType = "image";
        }
    }

    public class MassPreviewImageMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
