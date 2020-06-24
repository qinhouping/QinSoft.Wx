using QinSoft.Wx.Common;
using QinSoft.Wx.OfficialAccount;
using QinSoft.Wx.OfficialAccount.Model;
using QinSoft.Wx.OfficialAccount.Model.CustomerService;
using QinSoft.Wx.OfficialAccount.Model.RecvMsg;
using QinSoft.Wx.OfficialAccount.Model.ReplyMsg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace QinSoft.Wx.Web.Controllers
{
    public class OfficialAccountController : Controller
    {
        private OfficialAccountService officialAccountService;

        public OfficialAccountController()
        {
            this.officialAccountService = new OfficialAccountServiceImp(new OfficialAccountConfig()
            {
                AppId = "wxcad74d3a9d362a22",
                AppSecret = "6ea6005516fe6d6746107174bbf4cbe5",
                Token = "QinSoft.Wx.OfficialAccount"
            });
        }

        [HttpGet]
        public ActionResult Join(string signature, long timestamp, string nonce, string echostr)
        {
            if (this.officialAccountService.CalculateJoinSignature(timestamp, nonce).Equals(signature, StringComparison.OrdinalIgnoreCase) == true)
            {
                return Content(echostr);
            }
            else
            {
                return Content(string.Empty);
            }
        }

        [HttpPost]
        public ActionResult Join(string signature, long timestamp, string nonce)
        {
            if (this.officialAccountService.CalculateJoinSignature(timestamp, nonce).Equals(signature, StringComparison.OrdinalIgnoreCase) == true)
            {
                try
                {
                    string recvMsgXml = ReadInputContent(this.Request.InputStream);
                    RecvMsgBase recvMsg = recvMsgXml.FromXml<RecvMsgBase>();
                    ReplyTextMsg replyMsg = new ReplyTextMsg()
                    {
                        FromUserName = recvMsg.ToUserName,
                        ToUserName = recvMsg.FromUserName,
                        CreateTime = DateTime.Now.ToTimeStamp(),
                        MsgType = "text",
                        Content = "hello world"
                    };
                    string sendMsgXml = replyMsg.ToXml();

                    string accessToken = this.officialAccountService.GetAccessToken();
                    this.officialAccountService.TypingCustomerService(accessToken, new TypingCustomerServiceRequest()
                    {
                        ToUser = recvMsg.FromUserName,
                        Command = "Typing"
                    });

                    //发送客服消息
                    CustomerServiceMsgBase customerServiceMsg = new CustomerServiceNewsMsg()
                    {
                        ToUser = recvMsg.FromUserName,
                        News = new CustomerServiceNewsMsgContent()
                        {
                            Articles = new CustomerServiceNewsMsgContentItem[]
                            {
                            new CustomerServiceNewsMsgContentItem(){
                                Title="秦后平的Github",
                                Description="最大男性交友网站",
                                Url="https://github.com/qinhouping" ,
                                PicUrl="https://avatars1.githubusercontent.com/u/28695396?s=60&v=4"
                            }
                            }
                        }
                    };
                    this.officialAccountService.SendCustomerServiceMessage(accessToken, customerServiceMsg);
                    this.officialAccountService.TypingCustomerService(accessToken, new TypingCustomerServiceRequest()
                    {
                        ToUser = recvMsg.FromUserName,
                        Command = "CancelTyping"
                    });
                    return Content(sendMsgXml);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    return Content(e.Message);
                }
            }
            else
            {
                return Content("禁止操作");
            }
        }

        [HttpGet]
        public ActionResult GetAccessToken()
        {
            try
            {
                return Content(this.officialAccountService.GetAccessToken());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetCustomerServiceList()
        {
            try
            {
                string accessTokne = this.officialAccountService.GetAccessToken();
                return Content(this.officialAccountService.GetCustomerServiceList(accessTokne).ToJson());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult ActionCustomerService(string option, string account, string nickname, string password)
        {
            try
            {
                string accessTokne = this.officialAccountService.GetAccessToken();
                CustomerServiceActionRequest request = new CustomerServiceActionRequest() { Account = account, NickName = nickname, Password = password };
                switch (option)
                {
                    case "add": this.officialAccountService.AddCustomerService(accessTokne, request); break;
                    case "delete": this.officialAccountService.DeleteCustomerService(accessTokne, request); break;
                    case "update": this.officialAccountService.UpdateCustomerService(accessTokne, request); break;
                }
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        private string ReadInputContent(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}