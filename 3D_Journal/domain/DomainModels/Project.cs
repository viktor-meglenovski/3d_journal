using domain.Identity;
using domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? MainImageId { get; set; }
        public ProjectImage MainImage { get; set; }
        public DateTime TimeStamp { get; set; }
        virtual public List<OtherProjectImage> OtherImages { get; set; }
        virtual public List<ProjectSoftware> SoftwaresUsed { get; set; }
        virtual public List<Like> LikedByUsers { get; set; }
        virtual public AppUser Creator { get; set; }
        public string CreatorId { get; set; }
        virtual public UploadedFile UploadedFile { get; set; }
        public Guid? UploadedFileId { get; set; }
        public int Price { get; set; }
        virtual public List<Purchase> PurchasedBy { get; set; }
        
    }
}
