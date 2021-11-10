using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Data
{
    public class Compactor
    {
        [Key]
        public int CompactorId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string CompactorName { get; set; }
        public bool IsTrash { get; set; }
        public bool IsContaminated { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public bool IsDryWaste { get; set; }
    }
}
