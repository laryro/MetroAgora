using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LF.MVC.Models
{
    public class LineModel : BaseModel
    {
        public Line Line { get; set; }
        public IList<Station> Stations { get; set; }
        
        public LineModel()
        {
            Stations = Access.Station.GetStationByLine(1);
            Line = Access.Line.GetById(1);
        }

    }
}