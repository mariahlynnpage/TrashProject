using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrashProject.Models.HaulModels
{
    public class HaulEdit
    {
        public int HaulId { get; set; }
        [Display(Name = "Compactor Name")]
        public int CompactorId { get; set; }
        [Display(Name = "Hauler")]
        public int HaulerInfoId { get; set; }
        [Display(Name = "Property")]
        public int PropertyId { get; set; }
        [Display(Name = "Contact who Requests this Haul")]
        public int PropertyContactId { get; set; }

        public IEnumerable<SelectListItem> Compactors { get; set; }
        public IEnumerable<SelectListItem> HaulerInformation { get; set; }
        public IEnumerable<SelectListItem> Properties { get; set; }
        public IEnumerable<SelectListItem> PropertyContacts { get; set; }
    }
}
