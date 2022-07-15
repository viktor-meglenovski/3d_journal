using domain.DomainModels;
using domain.Identity;
using domain.Relations;
using repository.Interface;
using service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly ISoftwareRepository softwareRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IProjectRepository projectRepositoryAdvanced;
        private readonly IRepository<Purchase> purchaseRepository;
        public ProjectService(ISoftwareRepository softwareRepository, IRepository<Project> projectRepository, IProjectRepository projectRepositoryAdvanced, IRepository<Purchase> purchaseRepository)
        {
            this.softwareRepository = softwareRepository;
            this.projectRepository = projectRepository;
            this.projectRepositoryAdvanced = projectRepositoryAdvanced;
            this.purchaseRepository = purchaseRepository;
        }
        public Project CreateNewProject(AppUser creator, string name, string description, int price, List<Guid> softwaresUsed, string mainImage, List<string> otherImages, string filePath)
        {
            List<Software> software = softwareRepository.GetAllWithLogoFromIdList(softwaresUsed);
            List<ProjectSoftware> projectSoftwares = new List<ProjectSoftware>();
            foreach(Software s in software)
            {
                projectSoftwares.Add(new ProjectSoftware { Software = s, SoftwareId = s.Id });
            }
          
            UploadedFile uploadedFile = new UploadedFile { Path = filePath };
            ProjectImage mainImg = new ProjectImage { ImagePath = mainImage };
            List<OtherProjectImage> otherImgs = new List<OtherProjectImage>();
            foreach(string s in otherImages)
            {
                otherImgs.Add(new OtherProjectImage { ImagePath = s });
            }
            Project p = new Project { Name=name, Description=description,MainImage=mainImg, TimeStamp=DateTime.Now, OtherImages=otherImgs, SoftwaresUsed=projectSoftwares, LikedByUsers=new List<Like>(), Creator=creator, CreatorId=creator.Id,UploadedFile=uploadedFile, UploadedFileId=uploadedFile.Id, Price=price};
            return projectRepository.Insert(p);
        }

        public Project Delete(Project p)
        {
            return projectRepository.Delete(p);
        }

        public Project EditProject(Guid id, string name, string description, int price, List<Guid> softwaresUsed, string mainImage, List<string> otherImages, string uploadedFile)
        {
            Project Project = projectRepositoryAdvanced.GetProjectWithDetails(id);

            Project.Name = name;
            Project.Description = description;
            Project.Price = price;

            List<Software> software = softwareRepository.GetAllWithLogoFromIdList(softwaresUsed);
            List<ProjectSoftware> projectSoftwares = new List<ProjectSoftware>();
            foreach (Software s in software)
            {
                projectSoftwares.Add(new ProjectSoftware { Software = s, SoftwareId = s.Id });
            }
            Project.SoftwaresUsed = projectSoftwares;

            if (mainImage != "")
            {
                ProjectImage mainImg = new ProjectImage { ImagePath = mainImage };
                Project.MainImage = mainImg;
            }
            if (uploadedFile != "")
            {
                UploadedFile uplFile = new UploadedFile { Path = uploadedFile };
                Project.UploadedFile = uplFile;
            }
            foreach(string oi in otherImages)
            {
                Project.OtherImages.Add(new OtherProjectImage { ImagePath = oi, ProjectId = id, Project = Project });
            }
            return projectRepository.Update(Project);
        }

        public Project Get(Guid id)
        {
            return projectRepositoryAdvanced.GetProjectWithDetails(id);
        }

        public List<Project> GetAllProjectWithDetails()
        {
            return projectRepositoryAdvanced.GetAllProjectWithDetails();
        }

        public bool Order(AppUser user, Guid projectId)
        {
            var project = Get(projectId);
            var newPurchase = new Purchase { User = user, UserId = user.Id, Project = project, ProjectId = project.Id };
            purchaseRepository.Insert(newPurchase);
            return true;
        }

        public List<Project> Search(string text)
        {
            List<Project> result = new List<Project>();
            foreach(Project p in GetAllProjectWithDetails())
            {
                if(p.Name.Contains(text) || p.Description.Contains(text))
                {
                    result.Add(p);
                }
            }
            return result;
        }
    }
}
