using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Journal_Statistics.Models
{
    public class Project
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
