using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg.RecvEvent
{
    public class RecvScanCodeWaitEvntMsg
    {
        public string EventKey { get; set; }

        public RecvScanCodeWaitEvntMsgInfo ScanCodeInfo { get; set; }
    }
    public class RecvScanCodeWaitEvntMsgInfo
    {
        public string ScanType { get; set; }
        public string ScanResult { get; set; }
    }
}
