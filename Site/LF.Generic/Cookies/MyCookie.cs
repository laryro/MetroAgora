using System;
using System.Web;

namespace LF.Generics.Cookies
{
    public static class MyCookie
    {
        public static String Get()
        {
            if (get() == null)
                add(Token.New());

            return get();
        }


        private const String name = "LF_NH";
        
        private static HttpContext context
        {
            get { return HttpContext.Current; }
        }

        private static HttpCookieCollection requestCookies
        {
            get { return context.Request.Cookies; }
        }

        private static HttpCookieCollection responseCookies
        {
            get { return context.Response.Cookies; }
        }

        private static String local { get; set; }



        private static String get()
        {
            if (context == null)
            {
                return local;
            }

            var cookie = requestCookies[name]
                            ?? responseCookies[name];

            if (cookie == null)
                return null;

            if (cookie.Value == null)
                remove();

            return cookie.Value;
        }



        private static void add(String value)
        {
            remove();

            if (context == null)
            {
                local = value;
                return;
            }

            var cookie = new HttpCookie(name)
            {
                Value = value,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            requestCookies.Add(cookie);
            responseCookies.Add(cookie);

            requestCookies[name].Value = value;
            responseCookies[name].Value = value;
        }

        private static void remove()
        {
            if (context == null)
            {
                local = null;

                return;
            }

            if (requestCookies[name] != null)
                requestCookies[name].Expires =
                    DateTime.UtcNow.AddDays(-1);

            if (responseCookies[name] != null)
                responseCookies[name].Expires =
                    DateTime.UtcNow.AddDays(-1);
        }

        
    }
}
