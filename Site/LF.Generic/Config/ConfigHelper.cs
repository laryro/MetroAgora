using System;
using System.Configuration;
using System.Web;

namespace LF.Generics.Config
{
    public class ConfigHelper
    {
        public static String Url
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;

                return String.Format("{0}://{1}",
                    HttpContext.Current.Request.Url.Scheme,
                    HttpContext.Current.Request.Url.Authority
                );
            }
        }


        public static Int32 ItemsPerPage
        {
            get { return getInt("ItemsPerPage"); }
        }



        private static int getInt(String key)
        {
            var valueString = ConfigurationManager.AppSettings[key];

            int valueInteger;
            Int32.TryParse(valueString, out valueInteger);

            return valueInteger;
        }


    }
}
