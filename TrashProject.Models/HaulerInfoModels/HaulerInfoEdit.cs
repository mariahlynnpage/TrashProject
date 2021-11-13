using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashProject.Models.HaulerInfoModels
{
    public class HaulerInfoEdit
    {
        [Key]
        public int HaulerId { get; set; }
        [Display(Name = "Hauler Name")]
        public string HaulerName { get; set; }
        [Display(Name = "Phone Number")]
        public string HaulerPhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string HaulerEmail { get; set; }
    }
}
