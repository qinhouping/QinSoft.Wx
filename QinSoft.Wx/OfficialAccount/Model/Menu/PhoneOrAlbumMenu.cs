using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Menu
{
    public class PhoneOrAlbumMenu : MenuBase
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        public PhoneOrAlbumMenu()
        {
            this.Type = "pic_photo_or_album";
        }
    }
}
