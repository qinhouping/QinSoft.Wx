using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{

    public class CustomerServiceListResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("kf_list")]
        public CustomerServiceListItem[] CustomerServiceList { get; set; }
    }

    public class CustomerServiceListItem
    {
        [JsonProperty("kf_account")]
        public string Account { get; set; }

        [JsonProperty("kf_nick")]
        public string NickName { get; set; }

        [JsonProperty("kf_id")]
        public string ID { get; set; }

        [JsonProperty("kf_headimgurl")]
        public string HeadImgUrl { get; set; }
    }
}
