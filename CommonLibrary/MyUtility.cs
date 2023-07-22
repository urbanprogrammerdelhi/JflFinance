using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class MyUtility
    {
        public static string GetPageAbsolutePath
        {
            get
            {
                return System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            }
        }
    }
}
