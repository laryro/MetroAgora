using System;
using System.Collections.Generic;
using System.IO;

namespace LF.Emails
{
    internal class Format
    {
        internal String Subject { get; private set; }
        internal String Body { get; private set; }


        internal Format(FormatType key, IDictionary<string, string> keywords)
        {
            Subject = Subjects[key].Format(keywords);

            var path = Path.Combine("HTMLs", "Email", key + ".html");
            var html = File.ReadAllText(path);
            Body = html.Format(keywords);
        }

        public IDictionary<FormatType, String> Subjects = new Dictionary<FormatType, String>
        {
            { FormatType.NewUser, "Your password" },
            { FormatType.RecoverPassword, "Recover your password" },
        };

    }
}
