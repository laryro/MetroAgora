using System;
using Resources;

namespace LF.MVC.Helpers.Extensions
{
    public static class EnumExtension
    {
        public static String GetName(this Enum role)
        {
            var resourceValue = Enums.ResourceManager.GetString(role.GetType().Name + "_" + role);

            return String.IsNullOrEmpty(resourceValue)
                ? role.ToString()
                : resourceValue;
        }

        public static String ToCss(this Enum permission)
        {
            return permission
                .ToReadableString()
                .ToLower()
                .Replace(" ", "-");
        }

        public static String ToReadableString(this Enum permission)
        {
            return permission.ToString().ToReadableString();
        }

    }

}