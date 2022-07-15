using domain.DomainModels;
using domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.Interface
{
    public interface IProjectRepository
    {
        Project GetProjectWithDetails(Guid id);
        Project UpdateProject(string title, string description, string mainImage, List<ProjectSoftware> softwaresUsed);
        List<Project> GetAllProjectWithDetails();
    }
}
