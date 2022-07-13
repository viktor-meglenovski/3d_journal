using domain.Identity;
using domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class Project:BaseEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image MainImage { get; set; }
        public DateTime TimeStamp { get; set; }
        virtual public List<Image> Images { get; set; }
        virtual public List<ProjectSoftware> SoftwaresUsed { get; set; }
        virtual public List<Like> LikedByUsers { get; set; }
        virtual public List<AppUser> Likes { get; set; }

        virtual public AppUser Creator { get; set; }
        public string CreatorId { get; set; }
        
    }
}
