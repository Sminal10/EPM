using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.Models
{
    public class ModelShowAnnouncement
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Desc { get; set; }
    }
}
