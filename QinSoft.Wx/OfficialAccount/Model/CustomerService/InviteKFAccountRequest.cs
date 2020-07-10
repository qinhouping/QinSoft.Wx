using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class InviteKFAccountRequest
    {
        [JsonProperty("kf_account")]
        public string KFAccount { get; set; }

        [JsonProperty("invite_wx")]
        public string InviteWx { get; set; }
    }
}
