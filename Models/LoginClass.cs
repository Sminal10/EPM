using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EPM.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please Enter Username !")]
        [Display(Name ="Enter Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please Enter Password !")]
        [Display(Name ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
