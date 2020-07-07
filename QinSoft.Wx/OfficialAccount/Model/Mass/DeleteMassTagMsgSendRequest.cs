using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class DeleteMassTagMsgSendRequest
    {
        [JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [JsonProperty("article_idx")]
        public int ArticleIdx { get; set; }
    }
}
