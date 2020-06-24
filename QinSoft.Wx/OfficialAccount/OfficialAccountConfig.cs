using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount
{
    /// <summary>
    /// 公众号配置
    /// </summary>
    public class OfficialAccountConfig
    {
        /// <summary>
        /// 公众号应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 公众号秘钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 公众号接入Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 消息加密
        /// </summary>
        public string EncodingAESKey { get; set; }
    }
}
