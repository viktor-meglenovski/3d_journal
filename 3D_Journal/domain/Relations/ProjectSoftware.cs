using domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Relations
{
    public class ProjectSoftware:BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Guid SoftwareId { get; set; }
        virtual public Project Project { get; set; }
        virtual public Software Software { get; set; }
    }
}
