using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class MenuInfo
    {
        [JsonProperty("button")]
        public MenuBase[] Button { get; set; }

        [JsonProperty("matchrule")]
        public MenuMatchRule MenuMatchRule { get; set; }
    }
}
