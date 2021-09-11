using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.Models
{
    public class AdminLoginClass
    {
        [Required(ErrorMessage = "Please Enter Username !")]
        [Display(Name = "Enter Username")]
        public string AdminUserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password !")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}
