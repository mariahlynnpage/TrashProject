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
    public class HaulDetail
    {
        [Key]
        public int HaulId { get; set; }
        public int CompactorId { get; set; }
        public Compactor Compactor { get; set; }
        public int HaulerInfoId { get; set; }
        public HaulerInfo HaulerInfo { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int PropertyContactId { get; set; }
        public PropertyContact PropertyContact { get; set; }

        public IEnumerable<SelectListItem> Compactors { get; set; }
        public IEnumerable<SelectListItem> HaulerInformation { get; set; }
        public IEnumerable<SelectListItem> Properties { get; set; }
        public IEnumerable<SelectListItem> PropertyContacts { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
