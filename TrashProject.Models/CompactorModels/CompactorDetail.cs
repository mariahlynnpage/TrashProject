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
        public string CompactorName { get; set; }
        public bool IsTrash { get; set; }
        public bool IsDryWaste { get; set; }
        public bool IsContaminated { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
