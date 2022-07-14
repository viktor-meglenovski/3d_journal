using domain.DomainModels;
using domain.Relations;
using Microsoft.EntityFrameworkCore;
using repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Project> entities;

        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Project>();
        }
        public Project GetProjectWithDetails(Guid id)
        {
            return entities
                .Include(x => x.Creator)
                .Include("Creator.ProfileImage")
                .Include(x => x.LikedByUsers)
                .Include(x => x.MainImage)
                .Include(x => x.OtherImages)
                .Include(x => x.SoftwaresUsed)
                .Include("SoftwaresUsed.Software")
                .Include("SoftwaresUsed.Software.Logo")
                .Include(x=>x.UploadedFile)
                .SingleOrDefaultAsync(x=>x.Id==id).Result;
        }

        public Project UpdateProject(string title, string description, string mainImage, List<ProjectSoftware> softwaresUsed)
        {
            throw new NotImplementedException();
        }
    }
}
