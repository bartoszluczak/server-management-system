using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class UpdatesDetails
    {
        public string InstallDate { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string FixComments { get; set; }
        public string Description { get; set; }
        public string HotFixID { get; set; }
        public string InstalledBy { get; set;  }
        public string InstalledOn { get; set; }
        public string ServicePackInEffect { get; set; }
    }
}
