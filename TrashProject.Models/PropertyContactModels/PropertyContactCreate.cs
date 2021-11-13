using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.PropertyContactModels
{
    public class PropertyContactCreate
    {
        [Display(Name = "Position With Property")]
        public string PropContactPosition { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PropContactPhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string PropContactEmail { get; set; }
    }
}
