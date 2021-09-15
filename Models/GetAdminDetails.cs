using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.Models
{
    public class GetAdminDetails
    {
        public string AdminId { get; set; }
        public string AdminFname { get; set; }
        public string AdminLname { get; set; }
        public string AdminGender { get; set; }
        public string AdminPhoneNumber { get; set; }
    }
}
