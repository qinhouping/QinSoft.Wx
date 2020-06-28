using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.User
{
    public class BatchGetUserInfoRequest
    {
        [JsonProperty("user_list")]
        public BatchGetUserInfoRequestItem[] UserList { get; set; }
    }

    public class BatchGetUserInfoRequestItem
    {
        public string OpenId { get; set; }

        public string Lang { get; set; } = "zh_CN";
    }
}
