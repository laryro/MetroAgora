using System;
using System.IO;
using System.Web;
using LF.Generics.Cookies;

namespace LF.MVC.Helpers.Extensions
{
    public static class HttpPostedFileBaseExtension
    {
        public static String SaveFor<T>(this HttpPostedFileBase file, String oldValue)
        {
            if (file == null || String.IsNullOrEmpty(file.FileName))
                return oldValue;

            var sitePath = Directory.GetCurrentDirectory();
            var path = "Upload";
            var guid = Token.New();

            var extension = Path.GetExtension(file.FileName);
            var fileName = guid + extension;
            var fileFullName = Path.Combine(sitePath, path, typeof(T).Name, fileName);

            file.SaveAs(fileFullName);

            return fileName;
        }
    }
}