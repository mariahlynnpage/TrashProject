using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.PropertyModels
{
    public class PropertyCreate
    {
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
