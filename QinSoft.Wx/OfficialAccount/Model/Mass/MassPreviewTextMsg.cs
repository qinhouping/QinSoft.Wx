using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewTextMsg : MassPreviewMsgBase
    {
        [JsonProperty("text")]
        public MassPreviewTextMsgContent Text { get; set; }

        public MassPreviewTextMsg()
        {
            this.MsgType = "text";
        }
    }

    public class MassPreviewTextMsgContent
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
