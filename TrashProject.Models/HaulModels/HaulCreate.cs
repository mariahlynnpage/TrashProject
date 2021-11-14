using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrashProject.Data;

namespace TrashProject.Models.HaulModels
{
    public class HaulCreate
    {
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
