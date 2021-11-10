using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Data
{
    public class PropertyContact
    {
        [Key]
        public int PropertyContactId { get; set; }
        public Guid OwnerId { get; set; }
        public string PropContactPosition { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PropContactPhoneNumber { get; set; }
        public string PropContactEmail { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
