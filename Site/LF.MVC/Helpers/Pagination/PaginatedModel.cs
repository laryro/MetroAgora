using System;
using System.Collections.Generic;

namespace LF.MVC.Helpers.Pagination
{
    public class PaginatedModel<T>
    {
        public PaginatedModel(IList<T> list, String url, Int32 total, Int32 itemsPerPage)
        {
            List = list;
            PagesModel = new PagesModel(url, total, itemsPerPage);
        }

        public IList<T> List { get; private set; }
        public PagesModel PagesModel { get; private set; }

        public Int32 TotalPages { get; set; }

    }
}