using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.UpdatableMessage
{
    public class CreateActivityIdResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("activity_id")]
        public string ActivityId { get; set; }

        [JsonProperty("expiration_time")]
        public long ExpirationTime { get; set; }
    }
}
