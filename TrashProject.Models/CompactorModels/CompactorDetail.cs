using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.CompactorModels
{
    public class CompactorDetail
    {
        [Key]
        public int CompactorId { get; set; }
        [Display(Name = "Compactor Name")]
        public string CompactorName { get; set; }
        [Display(Name = "Is it trash?")]
        public bool IsTrash { get; set; }
        [Display(Name = "Is it contaminated?")]
        public bool IsContaminated { get; set; }
        [Display(Name = "Is it dry waste?")]
        public bool IsDryWaste { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
