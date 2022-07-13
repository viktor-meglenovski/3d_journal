using domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class Software:BaseEntity
    {
        public string Name { get; set; }
        public Image Logo { get; set; }
        virtual public List<ProjectSoftware> UsedInProjects { get; set; }
    }
}
