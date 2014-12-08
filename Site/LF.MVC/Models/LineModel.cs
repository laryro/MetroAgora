using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LF.MVC.Models
{
    public class LineModel : BaseModel
    {
        public IList<Line> AllLines { get; set; }
        
        public Line Line { get; set; }
        public IList<Occurrence> LineOccurrences { get; set; }

        public IList<Station> Stations { get; set; }
        public IDictionary<Station, Int32> StationAndStatus { get; set; }        

        public LineModel()
        {
            AllLines = Access.Line.GetAll();

            Stations = Access.Station.GetStationByLine(1);
            
            Line = Access.Line.GetById(1);
            
            List<Occurrence> LineOccurrencesList = new List<Occurrence>();
            
            foreach(var station in Stations){
                foreach (var occurence in Access.Occurrence.GetOccurrencesByStation(station.ID).ToList()) {
                    var now = DateTime.Now;
                    var occurenceDate = occurence.Date;

                    TimeSpan diff = now.Subtract(occurenceDate);

                    var minutos = diff.TotalMinutes;

                    if (occurence.Date > DateTime.Now.AddMinutes(-20)){
                        LineOccurrencesList.Add(occurence);
                    }
                }
            }

            LineOccurrences = LineOccurrencesList;

            IDictionary<Station, Int32> ocorrenciasPorEstacaoList = new Dictionary<Station, Int32>();

            foreach(var station in Stations){
                Int32 numberOfOccurencesByStation = 0;
                foreach (var occurence in Access.Occurrence.GetOccurrencesByStation(station.ID).ToList()) {
                    var now = DateTime.Now;
                    var occurenceDate = occurence.Date;

                    TimeSpan diff = now.Subtract(occurenceDate);

                    var minutos = diff.TotalMinutes;

                    if (occurence.Date > DateTime.Now.AddMinutes(-20)){
                        numberOfOccurencesByStation++;
                    }
                }
                ocorrenciasPorEstacaoList.Add(station, numberOfOccurencesByStation);
            }

            StationAndStatus = ocorrenciasPorEstacaoList;

        }

    }
}