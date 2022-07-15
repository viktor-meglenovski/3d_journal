using domain.DomainModels;
using domain.Relations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }    
        public virtual ProfileImage ProfileImage { get; set; }
        public Guid? ProfileImageId { get; set; }
        
        virtual public List<Project> Projects { get; set;}
        virtual public List<Like> LikedProjects { get; set; }
        virtual public List<Purchase> PurchasedProjects { get; set; }
    }
}
