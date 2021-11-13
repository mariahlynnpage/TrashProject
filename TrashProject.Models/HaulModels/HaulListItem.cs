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
    public class HaulListItem
    {
        [Key]
        public int HaulId { get; set; }
        [ForeignKey("CompactorId")]
        public Compactor Compactor { get; set; }
        [ForeignKey("HaulerId")]
        public HaulerInfo HaulerName { get; set; }
        [ForeignKey("PropertyId")]
        public Property PropertyName { get; set; }
        [ForeignKey("PropertyContactId")]
        public PropertyContact PropertyContactName { get; set; }
        [Display(Name = "Haul Date Requested")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}