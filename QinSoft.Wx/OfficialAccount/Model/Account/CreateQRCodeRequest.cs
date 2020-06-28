using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Account
{
    [WxDocument(Url = "https://developers.weixin.qq.com/doc/offiaccount/Account_Management/Generating_a_Parametric_QR_Code.html")]
    public class CreateQRCodeRequest
    {
        [JsonProperty("expire_seconds")]
        public int? ExpireSeconds { get; set; }

        [JsonProperty("action_name")]
        public string ActionName { get; set; }

        [JsonProperty("action_info")]
        public QRCodeActionInfo ActionInfo { get; set; }
    }

    public class QRCodeActionInfo
    {
        [JsonProperty("scene")]
        public QRCodeScene Scene { get; set; }
    }

    public class QRCodeScene
    {
        [JsonProperty("scene_id")]
        public int SceneId { get; set; }

        [JsonProperty("scene_str")]
        public string SceneStr { get; set; }
    }
}
