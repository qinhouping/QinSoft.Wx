using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class WxDocumentAttribute : Attribute
    {
        public string Url { get; set; }
    }
}
