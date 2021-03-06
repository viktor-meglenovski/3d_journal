using domain.DomainModels;
using domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Relations
{
    public class Purchase:BaseEntity
    {
        virtual public AppUser User { get; set; }
        public string UserId { get; set; }
        virtual public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
