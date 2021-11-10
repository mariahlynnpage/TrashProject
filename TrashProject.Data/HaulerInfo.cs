using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Data
{
    public class HaulerInfo
    {
        [Key]
        public int HaulerId { get; set; }
        public Guid OwnerId { get; set; }
        public string HaulerName { get; set; }
        public string HaulerPhoneNumber { get; set; }
        public string HaulerEmail { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
