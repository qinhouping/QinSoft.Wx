using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewMsgBase : MassMsgBase
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("towxname")]
        public string ToWxName { get; set; }
    }
}
