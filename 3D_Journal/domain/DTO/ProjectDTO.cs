using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DTO
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
