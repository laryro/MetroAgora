using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LF.MVC.Models
{
    public class StationModel : BaseModel
    {
        public IList<Station> Stations { get; set; }

        public StationModel()
        {
            Stations = Access.Station.GetStationByLine(1);
        }

    }
}