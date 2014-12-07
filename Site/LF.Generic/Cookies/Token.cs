using System;

namespace LF.Generics.Cookies
{
    public static class Token
    {
        public static String New()
        {
            return Guid.NewGuid()
                .ToString()
                .ToUpper()
                .Replace("-", "");
        }

    }
}
