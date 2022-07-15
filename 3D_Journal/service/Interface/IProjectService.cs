using domain.DomainModels;
using domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Interface
{
    public interface IProjectService
    {
        Project CreateNewProject(AppUser creator, string name, string description,int price, List<Guid> softwaresUsed, string mainImage, List<string> otherImages, string uploadedFile);
        Project Get(Guid id);
        Project EditProject(Guid id, string name, string description, int price, List<Guid> softwaresUsed, string mainImage, List<string> otherImages, string uploadedFile);
        Project Delete(Project p);
        Boolean Order(AppUser user, Guid projectId);
        List<Project> Search(string text);
        List<Project> GetAllProjectWithDetails();
    }
}
