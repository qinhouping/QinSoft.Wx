using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassMsgBase
    {
        [JsonProperty("msgtype")]
        public string MsgType { get; set; }
    }
}
