using System;
using System.Collections.Generic;
using System.Linq;

namespace LF.Emails
{
    public static class StringExtension
    {
        public static String Format(this String str, IDictionary<String, String> replaces)
        {
            return replaces.Aggregate(str, (current, replace) =>
                        current.Replace("{{" + replace.Key + "}}", replace.Value));
        }

    }
}
