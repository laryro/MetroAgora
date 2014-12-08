using LF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LF.MVC.Models
{
    public class OccurrenceModel : BaseModel
    {
        public IList<Occurrence> Occurrences { get; set; }

        public OccurrenceModel()
        {
            Occurrences = Access.Occurrence.GetOccurrencesByStation(1);
            
        }

        
        //public void Save(){
        //    Access.Occurrence.Save(newOccurence);
        //}

        //public Occurrence newOccurence { get; set; }

    }
}