using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace LF.MVC.Models
{
    public class NewOccurrenceModel : BaseModel
    {
        public IList<Occurrence> Occurrences { get; set; }

        public NewOccurrenceModel()
        { 
        }

        public NewOccurrenceModel(Int32 stationId)
        {
            Station = Access.Station.GetById(stationId);
            User = Access.Current.User;
        }

        
        public void Save(){
            Occurrence ocorrencia = new Occurrence();
            ocorrencia.Category = Category;
            ocorrencia.Date = DateTime.Now;
            ocorrencia.Description = Description;
            ocorrencia.Station = Station;
            ocorrencia.User = Access.Current.User;
            Access.Occurrence.Save(ocorrencia);
        }

        public String Description { get; set; }
        public Category Category { get; set; }
        public Station Station { get; set; }
        public User User { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}