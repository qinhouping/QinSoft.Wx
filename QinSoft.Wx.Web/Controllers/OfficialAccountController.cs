using QinSoft.Wx.Common;
using QinSoft.Wx.OfficialAccount;
using QinSoft.Wx.OfficialAccount.Model;
using QinSoft.Wx.OfficialAccount.Model.CustomerService;
using QinSoft.Wx.OfficialAccount.Model.RecvMsg;
using QinSoft.Wx.OfficialAccount.Model.ReplyMsg;
using QinSoft.Wx.OfficialAccount.Model.Menu;
using QinSoft.Wx.OfficialAccount.Model.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Reflection.Emit;
using QinSoft.Wx.OfficialAccount.Model.Account;
using System.Threading.Tasks;
using QinSoft.Wx.OfficialAccount.Model.Media;
using System.Net.Http;
using QinSoft.Wx.OfficialAccount.Model.Web;
using QinSoft.Wx.OfficialAccount.Model.Mass;
using QinSoft.Wx.OfficialAccount.Model.WxShop;

namespace QinSoft.Wx.Web.Controllers
{
    public class OfficialAccountController : Controller
    {
        private OfficialAccountService officialAccountService;

        private string ReadInputContent(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public OfficialAccountController()
        {
            this.officialAccountService = new OfficialAccountServiceImp(new OfficialAccountConfig()
            {
                AppId = "wxcad74d3a9d362a22",
                AppSecret = "6ea6005516fe6d6746107174bbf4cbe5",
                Token = "QinSoft.Wx.OfficialAccount"
            });
        }

        /// <summary>
        /// 微信接入
        /// </summary>
        /// <param name="signature">签名</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机字符串</param>
        /// <param name="echostr">响应内容</param>
        /// <returns>执行结果</returns>
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

        /// <summary>
        /// 被动回复
        /// </summary>
        /// <param name="signature">签名</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机字符串</param>
        /// <returns>执行结果</returns>
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
                    //发送客服消息2
                    customerServiceMsg = new CustomerServiceImageMsg()
                    {
                        ToUser = recvMsg.FromUserName,
                        Image = new CustomerServiceImageMsgContent()
                        {
                            MediaId = "dMUBr-ZQ80Ec_p1-SelnXe379HbDpl11TsgrnaVgofrrv0yVgpR3rD0jIvasL-k3"
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
        public ActionResult CreateMenu()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                this.officialAccountService.CreateMenu(accessToken, new MenuInfo()
                {
                    Button = new MenuBase[]
                    {
                        new ClickMenu(){
                            Key="V1001_TODAY_MUSIC",
                            Name="今日歌曲"
                        },
                        new MenuBase(){ Name="菜单", SubButton=new MenuBase[]{
                            new ViewMenu()
                            {
                                Url="http://www.soso.com/",
                                Name="搜索"
                            },
                            //new MiniProgramMenu()
                            //{
                            //    Url="http://mp.weixin.qq.com",
                            //    AppId="wx286b93c14bbf93aa",
                            //    PagePath="pages/lunar/index",
                            //    Name="wxa"
                            //},
                            new ClickMenu()
                            {
                                Key="V1001_GOOD",
                                Name="赞一下我们"
                            }
                        } }
                    }
                }); ;
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult DeleteMenu()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                this.officialAccountService.DeleteMenu(accessToken);
                return Content("OK");
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
                string accessToken = this.officialAccountService.GetAccessToken();
                return Content(this.officialAccountService.GetCustomerServiceList(accessToken).ToJson());
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
                string accessToken = this.officialAccountService.GetAccessToken();
                CustomerServiceActionRequest request = new CustomerServiceActionRequest() { Account = account, NickName = nickname, Password = password };
                switch (option)
                {
                    case "add": this.officialAccountService.AddCustomerService(accessToken, request); break;
                    case "delete": this.officialAccountService.DeleteCustomerService(accessToken, request); break;
                    case "update": this.officialAccountService.UpdateCustomerService(accessToken, request); break;
                }
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult SetTemplateIndustry(string id1, string id2)
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                this.officialAccountService.SetTemplateIndustry(accessToken, new SetTemplateIndustryRequest() { IndustryId1 = id1, IndustryId2 = id2 });
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetTemplateIndustry()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                return Content(this.officialAccountService.GetTemplateIndustry(accessToken).ToJson());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetTemplateList()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                return Content(this.officialAccountService.GetTemplateList(accessToken).ToJson());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult DeleteTemplate(string templateId)
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                this.officialAccountService.DeleteTemplate(accessToken, templateId);
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult SendTemplateMessage()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                //发送模板信息
                TemplateMessage templateMessage = new TemplateMessage()
                {
                    ToUser = "oHHY5v6KCMygltJiNTSfIVMD2Y54",
                    Url = "https://github.com/qinhouping",
                    TemplateId = "-oDLXI59TN21-QaWcWcPTdyYZfsxgWQBr-qVzesrwI4",
                    Data = new TemplateMessageData()
                          {
                              {"date", new TemplateMessageKeyWord() { Value=DateTime.Now.ToString(), Color="#173177" } }
                          }
                };
                return Content(this.officialAccountService.SendTemplateMessage(accessToken, templateMessage));
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult SendMassTagMessage()
        {
            try
            {
                string accessToken = this.officialAccountService.GetAccessToken();
                MassTagMsgBase massTagMsgBase = new MassTagTextMsg()
                {
                    Filter = new MassTagMsgFilter()
                    {
                        IsToAll = true,
                        TagId = 0
                    },
                    Text = new MassTagTextMsgContent()
                    {
                        Content = "群发测试"
                    }
                };
                return Content(this.officialAccountService.SendMassTagMessage(accessToken, massTagMsgBase).ToJson());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetOnceSubscribeUrl()
        {
            return Content(this.officialAccountService.GetSubscribeUrl("test", "xrsTOC7oISJGgDEaBz9f8Wax-dBEDheZYJ934IN4f5E", "http://zkgxji.natappfree.cc", "test"));
        }

        [HttpGet]
        public ActionResult GetQRCode()
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            CreateQRCodeResponse response = this.officialAccountService.CreateQRCode(accessToken, new CreateQRCodeRequest()
            {
                ActionName = "QR_STR_SCENE",
                ActionInfo = new QRCodeActionInfo()
                {
                    Scene = new QRCodeScene() { SceneStr = "QinSoft.Wx" }
                }
            });
            return Content(this.officialAccountService.GetShortUrl(accessToken, this.officialAccountService.GetQRCodeUrl(response.Ticket)));
        }

        [HttpGet]
        public ActionResult UploadMedia()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> UploadMediaHandle(string type)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            string fileName = this.Request.Files["file"].FileName;
            Stream stream = this.Request.Files["file"].InputStream;
            UploadMediaResponse response = await this.officialAccountService.UploadMedia(accessToken, type, fileName, stream);
            return Content(response.ToJson());
        }

        public async Task<ActionResult> DownloadMedia(string mediaId, string fileName)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            Stream stream = await this.officialAccountService.DownloadMedia(accessToken, mediaId);
            return File(stream, "application/octet-stream", fileName);
        }

        [HttpGet]
        public ActionResult UploadMaterial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadNewsMaterial()
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            AddNewsMaterialResponse response = this.officialAccountService.AddNewsMaterial(accessToken, new AddNewsMaterialRequest()
            {
                Articles = new NewsMaterialArticle[]
                {
                    new NewsMaterialArticle()
                    {
                         Title="test",
                         ShowCoverPic=0,
                         Author="Qinhouping",
                         Digest="QinSoft.Wx",
                         Content="秦后平",
                         ContentSourceUrl="https://github.com/qinhouping",
                         ThumbMediaId="PqiXo-hO4-RxRAGj0Ja4AxBwdxGfnBLn0YUKVR7ZhDM"
                    }
                }
            });
            return Content(response.ToJson());
        }

        public ActionResult UploadImageMaterial()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> UploadMaterialHandle(string type)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            string fileName = this.Request.Files["file"].FileName;
            Stream stream = this.Request.Files["file"].InputStream;
            UploadMaterialResponse response = await this.officialAccountService.UploadMaterial(accessToken, type, fileName, stream);
            return Content(response.ToJson());
        }

        [HttpPost]
        public async Task<ActionResult> UploadImageMaterialHandle(string type)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            string fileName = this.Request.Files["file"].FileName;
            Stream stream = this.Request.Files["file"].InputStream;
            UploadImageMaterialResponse response = await this.officialAccountService.UploadImageMaterial(accessToken, fileName, stream);
            return Content(response.ToJson());
        }

        [HttpGet]
        public async Task<ActionResult> DownloadMaterial(string mediaId, string fileName)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            Stream stream = await this.officialAccountService.DownloadMaterial(accessToken, new DownloadMaterialRequest() { MediaId = mediaId });
            return File(stream, "application/octet-stream", fileName);
        }

        [HttpGet]
        public ActionResult GetMaterialCount()
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            GetMaterialCountResponse response = this.officialAccountService.GetMaterialCount(accessToken);
            return Content(response.ToJson());
        }

        [HttpGet]
        public ActionResult GetMaterialList(string type, int count = 10, int offset = 0)
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            if (type == "news")
            {
                GetMaterialListResponse<NewsMaterislListItem> response = this.officialAccountService.GetMaterialList<NewsMaterislListItem>(accessToken, new GetMaterialListRequest()
                {
                    Count = count,
                    Offset = offset,
                    Type = type
                });
                return Content(response.ToJson());
            }
            else
            {
                GetMaterialListResponse<NotNewsMaterislListItem> response = this.officialAccountService.GetMaterialList<NotNewsMaterislListItem>(accessToken, new GetMaterialListRequest()
                {
                    Count = count,
                    Offset = offset,
                    Type = type
                });
                return Content(response.ToJson());
            }
        }

        [HttpGet]
        public ActionResult WebIndex()
        {
            string redirect = this.Request.Url.Scheme + "://" + this.Request.Url.Host + Url.Action("WebIndexRedict");
            //string redirect = "http://686vxv.natappfree.cc/OfficialAccount/WebIndexRedict";
            return Redirect(this.officialAccountService.GetOAuth2Uri(redirect, "snsapi_userinfo", "TEST"));
        }

        [HttpGet]
        public ActionResult WebIndexRedict(string state, string code)
        {
            GetOAuth2AccessTokenResponse accessTokenResponse = this.officialAccountService.GetOAuth2AccessToken(code);
            accessTokenResponse = this.officialAccountService.RefreshOAuth2AccessToken(accessTokenResponse.RefreshToken);
            GetOAuth2UserInfoResponse userInfoResponse = this.officialAccountService.GetOAuth2UserInfo(accessTokenResponse.AccessToken, accessTokenResponse.OpenId);
            return Content(userInfoResponse.ToJson());
        }

        [HttpGet]
        public ActionResult CalculateJsApiSignature()
        {
            string sign = this.officialAccountService.CalculateJsApiSignature("sM4AOVdWfPE4DxkXGEs8VMCPGGVi4C3VM0P37wVUCFvkVAy_90u5h9nbSlYy3-Sl-HhTdfl2fzFy1AOcHKP7qg", 1414587457, "Wm3WZYTPz0wzccnW", "http://mp.weixin.qq.com?params=value");
            return Content(sign);
        }

        [HttpGet]
        public ActionResult AddWxShop()
        {
            string accessToken = this.officialAccountService.GetAccessToken();
            AddWxShopResponse response = this.officialAccountService.AddWxShop(accessToken, new AddWxShopRequest(new AddWxShopData()
            {
                Business = new WxShopBusinessData()
                {
                    BaseInfo = new WxShopBusinessBaseInfoData()
                    {
                        SId = "shop_test",
                        BusinessName = "鲜榨果汁",
                        BranchName = "test店",
                        Province = "安徽",
                        City = "马鞍山市",
                        District = "当涂县",
                        Address = "测试地址",
                        Telephone = "11111111111",
                        Categories = new string[] { "果汁" },
                        OffsetType = 3,
                        Longitude = 118.50966,
                        Latitude = 31.585623,
                        PhotoList = new WxShopBusinessBaseInfoPhotoData[] {
                            new WxShopBusinessBaseInfoPhotoData() { PhotoUrl="http://file02.16sucai.com/d/file/2015/0118/f4f4dc35c08c2aafeb8a581e3e48c274.jpg" },
                            new WxShopBusinessBaseInfoPhotoData() { PhotoUrl="http://img02.tooopen.com/images/20140120/sy_54583439935.jpg" }
                        },
                        Recommend = "精品果汁饮料",
                        Special = "有WiFi，外卖服务",
                        Introduction = "果汁以水果为原料经过物理方法如压榨、离心、萃取等得到的汁液产品，经加工制成的饮品。果汁中保留了水果中大部分营养成分，例如维生素、矿物质、糖分和膳食纤维中的果胶等。常喝果汁可以助消化、润肠道，补充膳食中营养成分的不足。",
                        OpenTime = "9:00-22:00",
                        AvgPrice = 20
                    }
                }
            }));
            return Content(response.ToJson());
        }
    }
}