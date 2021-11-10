using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Data
{
    public class Haul
    {
        [Key]
        public int HaulId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey("CompactorId")]
        public virtual Compactor Compactors { get; set; }
        [Display(Name = "Compactor")]
        public virtual int CompactorId { get; set; }
        [ForeignKey("HaulerInfoId")]
        public virtual HaulerInfo HaulerInformation { get; set; }
        [Display(Name = "Hauler")]
        public virtual int HaulerInfoId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Properties { get; set; }
        [Display(Name = "Property")]
        public virtual int PropertyId { get; set; }
        [ForeignKey("PropertyContactId")]
        public virtual PropertyContact PropertyContacts { get; set; }
        [Display(Name = "Property Contact")]
        public virtual int PropertyContactId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
