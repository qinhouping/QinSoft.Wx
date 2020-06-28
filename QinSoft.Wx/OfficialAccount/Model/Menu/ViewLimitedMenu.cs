using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class ViewLimitedMenu : MenuBase
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        public ViewLimitedMenu()
        {
            this.Type = "view_limited";
        }
    }
}
