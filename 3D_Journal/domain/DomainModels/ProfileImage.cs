using domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class ProfileImage:Image
    {
        public static Guid DefaultProfilePictureId = new Guid("0f5a63ee-9c7b-4113-a4c8-fd010a17d8d7");
        public virtual AppUser AppUser { get; set; }
        //public string AppUserId { get; set; }
    }
}
