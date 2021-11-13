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
        public virtual Compactor Compactor { get; set; }
        [Display(Name = "Compactor")]
        public int CompactorId { get; set; }
        [ForeignKey("HaulerInfoId")]
        public virtual HaulerInfo HaulerInfo { get; set; }
        [Display(Name = "Hauler")]
        public int HaulerInfoId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        [Display(Name = "Property")]
        public int PropertyId { get; set; }
        [ForeignKey("PropertyContactId")]
        public virtual PropertyContact PropertyContact { get; set; }
        [Display(Name = "Property Contact")]
        public int PropertyContactId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
