using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Data
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public Guid OwnerId { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

