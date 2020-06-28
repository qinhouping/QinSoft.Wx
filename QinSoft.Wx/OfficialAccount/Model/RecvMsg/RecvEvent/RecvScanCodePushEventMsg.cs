using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg.RecvEvent
{
    public class RecvScanCodePushEventMsg : RecvEventMsgBase
    {
        public string EventKey { get; set; }

        public RecvScanCodePushEventMsgInfo ScanCodeInfo { get; set; }
    }

    public class RecvScanCodePushEventMsgInfo
    {
        public string ScanType { get; set; }
        public string ScanResult { get; set; }
    }
}
