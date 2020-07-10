using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace QinSoft.Wx.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var r = CheckPhone("@@@yhj1%5574//515535【");
            return View();
        }

        public static string CheckPhone(string content)
        {
            if (content == null) return null;
            string pattern = "(\\d{3})\\d{4}(\\d{4})";
            string[] specialChars = new string[] {
                "/r","/n","/t"," ","`","~","!","@","#","$","%","^","&","*","(",")","-","_","=","+","[","{","]","}",";",":","'","\"","\\","|",",","<",".",">","/","?",
                "·","！","￥","……","（","）","——","【","】","；","’","”","、","，","《","。","》"
            };
            string tmpContent = content;
            foreach (string specialChar in specialChars)
            {
                tmpContent = tmpContent.Replace(specialChar, string.Empty);
            }
            if (Regex.IsMatch(tmpContent, pattern))
            {
                return Regex.Replace(tmpContent, pattern, "$1****$2");
            }
            else
            {
                return content;
            }
        }
    }
}