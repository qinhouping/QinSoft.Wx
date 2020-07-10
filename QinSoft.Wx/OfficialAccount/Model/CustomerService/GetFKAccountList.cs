using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{

    public class GetFKAccountList
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("kf_list")]
        public GetFKAccountItem[] KFAccountList { get; set; }
    }

    public class GetFKAccountItem
    {
        [JsonProperty("kf_account")]
        public string KFAccountk { get; set; }

        [JsonProperty("kf_nick")]
        public string KFNickName { get; set; }

        [JsonProperty("kf_id")]
        public string KFID { get; set; }

        [JsonProperty("kf_headimgurl")]
        public string KFHeadImgUrl { get; set; }

        [JsonProperty("kf_wx")]
        public string KFWx { get; set; }
    }
}
