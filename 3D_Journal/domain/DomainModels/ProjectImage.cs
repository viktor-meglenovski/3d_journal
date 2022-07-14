using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class ProjectImage:Image
    {
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
