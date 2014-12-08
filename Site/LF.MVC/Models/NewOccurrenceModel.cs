using LF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LF.MVC.Models
{
    public class NewOccurrenceModel : BaseModel
    {
        public IList<Occurrence> Occurrences { get; set; }

        public NewOccurrenceModel()
        {
            List<SelectListItem> listOfCategory = new List<SelectListItem>();
            foreach (var categoria in Access.Category.GetAll())
            {
                var categoryItem = new SelectListItem() { Text = categoria.Name, Value = categoria.ID.ToString() };
                listOfCategory.Add(categoryItem);
            }

            CategoryList = listOfCategory.AsEnumerable();
        }

        public NewOccurrenceModel(Int32 stationId)
        {
            List<SelectListItem> listOfCategory = new List<SelectListItem>();
            foreach (var categoria in Access.Category.GetAll())
            {
                var categoryItem = new SelectListItem() { Text = categoria.Name, Value = categoria.ID.ToString() };
                listOfCategory.Add(categoryItem);
            }
            Station = Access.Station.GetById(stationId);
            CategoryList = listOfCategory.AsEnumerable();
        }

        
        public void Save(){
            Occurrence ocorrencia = new Occurrence();
            ocorrencia.Category = Access.Category.GetById(Convert.ToInt32(CategoryId));
            ocorrencia.Date = DateTime.Now;
            ocorrencia.Description = Description;
            ocorrencia.Station = Access.Station.GetById(StationId);
            ocorrencia.User = Access.Current.User;
            Access.Occurrence.Save(ocorrencia);
        }

        [Required]
        public String Description { get; set; }
        [Required]
        public String CategoryId { get; set; }
        public Int32 StationId { get; set; }
        public Station Station { get; set; }
        public User User { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}