using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewMPNewsMsg : MassPreviewMsgBase
    {
        [JsonProperty("mpnews")]
        public MassTagMPNewsMsgContent MPNews { get; set; }

        public MassPreviewMPNewsMsg()
        {
            this.MsgType = "mpnews";
        }
    }

    public class MassPreviewMPNewsMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
