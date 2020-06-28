using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class ViewMenu : MenuBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        public ViewMenu()
        {
            this.Type = "view";
        }
    }
}
