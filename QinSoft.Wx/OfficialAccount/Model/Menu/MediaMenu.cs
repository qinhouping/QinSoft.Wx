using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class MediaMenu : MenuBase
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        public MediaMenu()
        {
            this.Type = "location_select";
        }
    }
}
