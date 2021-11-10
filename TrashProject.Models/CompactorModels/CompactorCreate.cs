using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.CompactorModels
{
    public class CompactorCreate
    {
        [Display(Name = "Compactor Name")]
        public string CompactorName { get; set; }
        [Display(Name = "Check if this is Trash")]
        public bool IsTrash { get; set; }
        [Display(Name = "Check if this is Contaminated")]
        public bool IsContaminated { get; set; }
        [Display(Name = "Check if this is Dry Waste")]
        public bool IsDryWaste { get; set; }
    }
}
