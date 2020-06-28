using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class ScanCodeWaitMsgMenu : MenuBase
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        public ScanCodeWaitMsgMenu()
        {
            this.Type = "scancode_waitmsg";
        }
    }
}
