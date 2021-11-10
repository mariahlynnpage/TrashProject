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
