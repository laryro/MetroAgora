using System;
using System.Text.RegularExpressions;

namespace LF.MVC.Helpers.Extensions
{
    public static class StringExtension
    {
        public static String ToUrl(this String text)
        {
            var regexBlank = new Regex(@"\s+");
            text = regexBlank.Replace(text, "-");

            var regexOthers = new Regex(@"[^\w^-]");
            text = regexOthers.Replace(text, "");

            return text;
        }

        public static String JustNumbers(this String text)
        {
            return Regex.Replace(text, @"[^\d]", "");
        }

        public static String ToReadableString(this String name)
        {
            var readableName = name[0].ToString();

            foreach (var letter in name.Substring(1))
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    readableName += " ";
                }

                readableName += letter;
            }

            return readableName;
        }



    }
}