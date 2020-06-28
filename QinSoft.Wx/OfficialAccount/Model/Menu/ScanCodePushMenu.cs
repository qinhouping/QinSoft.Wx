using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class ScanCodePushMenu : MenuBase
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        public ScanCodePushMenu()
        {
            this.Type = "scancode_push";
        }
    }
}
