using System;

namespace LF.MVC.Helpers.Pagination
{
    public class PagesModel
    {
        public PagesModel(String url, Int32 total, Int32 itemsPerPage)
        {
            if (url != "/")
            {
                Url = url;
            }

            ItemsPerPage = itemsPerPage;

            if (itemsPerPage == 0)
                return;
            
            Pages = total / itemsPerPage;

            if (total % itemsPerPage != 0)
                Pages++;
        }

        public Int64 Pages { get; private set; }
        public String Url { get; private set; }
        public Int32 ItemsPerPage { get; set; }
    }
}