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
        public Station station { get; set; }
        public IList<Occurrence> occurrences { get; set; }

        public StationModel()
        {
            Stations = Access.Station.GetStationByLine(1);
        }

        public StationModel(Int32 stationId) {
            station = Access.Station.GetById(stationId);
            occurrences = Access.Occurrence.GetOccurrencesByStation(stationId);
        }

    }
}