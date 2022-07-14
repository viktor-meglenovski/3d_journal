using domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class Software:BaseEntity
    {
        public string Name { get; set; }
        virtual public SoftwareImage Logo { get; set; }
        public Guid LogoId { get; set; }
        virtual public List<ProjectSoftware> UsedInProjects { get; set; }
    }
}
