using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.CompactorModels
{
    public class CompactorEdit
    {
        [Key]
        public int CompactorId { get; set; }
        public string CompactorName { get; set; }
        public bool IsTrash { get; set; }
        public bool IsContaminated { get; set; }
        public bool IsDryWaste { get; set; }
    }
}
