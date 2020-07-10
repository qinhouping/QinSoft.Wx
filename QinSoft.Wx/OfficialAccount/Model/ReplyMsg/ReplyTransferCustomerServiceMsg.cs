using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyTransferCustomerServiceMsg : ReplyMsgBase
    {
        public ReplyTransferCustomerServiceMsgContent TransInfo { get; set; }

        public ReplyTransferCustomerServiceMsg()
        {
            this.MsgType = "transfer_customer_service";
        }
    }

    public class ReplyTransferCustomerServiceMsgContent
    {
        public string KFAccount { get; set; }
    }
}
