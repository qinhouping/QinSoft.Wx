using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class UpdateRemarkResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
    }
}
