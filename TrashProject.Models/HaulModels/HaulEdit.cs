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
        [Key]
        public int HaulId { get; set; }
        public int CompactorId { get; set; }
        public int HaulerInfoId { get; set; }
        public int PropertyId { get; set; }
        public int PropertyContactId { get; set; }

        public IEnumerable<SelectListItem> Compactors { get; set; }
        public IEnumerable<SelectListItem> HaulerInformation { get; set; }
        public IEnumerable<SelectListItem> Properties { get; set; }
        public IEnumerable<SelectListItem> PropertyContacts { get; set; }
    }
}
