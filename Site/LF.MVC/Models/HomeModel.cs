using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LF.MVC.Models
{
    public class HomeModel : BaseModel
    {
        public IList<Line> Lines { get; set; }

        public HomeModel()
        {
            Lines = Access.Line.GetAll();

        }

    }
}