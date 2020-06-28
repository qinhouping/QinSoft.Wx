﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class WeixinPhoneMenu : MenuBase
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        public WeixinPhoneMenu()
        {
            this.Type = "pic_weixin";
        }
    }
}
