﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class MsgCustomerService
    {
        [JsonProperty("kf_account")]
        public string Account { get; set; }
    }
}
