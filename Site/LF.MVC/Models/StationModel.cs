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
        public Int32 Last20MinutesOccurrences { get; set; }
        public IList<Occurrence> LastOccurrences { get; set; }

        public StationModel()
        {
            Stations = Access.Station.GetStationByLine(1);
        }

        public StationModel(Int32 stationId) {
            station = Access.Station.GetById(stationId);
            occurrences = Access.Occurrence.GetOccurrencesByStation(stationId);
            List<Occurrence> lastOccurrences = new List<Occurrence>();
            var last20MinutesOccurrences = 0;

            foreach (var occurence in occurrences)
            {
                var now = DateTime.Now;
                var occurenceDate = occurence.Date;

                TimeSpan diff = now.Subtract(occurenceDate);

                var minutos = diff.TotalMinutes;

                if (occurence.Date > DateTime.Now.AddMinutes(-20))
                {
                    lastOccurrences.Add(occurence);
                    last20MinutesOccurrences++;
                }
            }
            LastOccurrences = lastOccurrences;
            Last20MinutesOccurrences = last20MinutesOccurrences;


        }

    }
}