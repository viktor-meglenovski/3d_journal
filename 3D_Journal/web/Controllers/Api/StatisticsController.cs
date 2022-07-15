using domain.DomainModels;
using domain.DTO;
using domain.Identity;
using domain.Relations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using repository.Interface;
using service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly UserManager<AppUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IRepository<Software> softwareRepository;

        public StatisticsController(IProjectService projectService, UserManager<AppUser> userManager, IUserRepository userRepository, IRepository<Software> softwareRepository)
        {
            this.projectService = projectService;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.softwareRepository = softwareRepository;
        }

        [HttpGet("[action]")]
        public List<ProjectDTO> GetProjectsBySoftware(Guid? softwareId)
        {
            var result = this.projectService.getProjectsBySoftware(softwareId);
            return result;
        }

        [HttpGet("[action]")]
        public List<Software> GetSoftware()
        {
            return softwareRepository.GetAll().ToList();
        }

        [HttpGet("[action]")]
        public List<UserDTOWithId> GetAllUsers()
        {
            List<UserDTOWithId> result = new List<UserDTOWithId>();
            foreach(AppUser user in userRepository.GetAll().ToList())
            {
                result.Add(new UserDTOWithId { Id=user.Id,Email = user.Email, FirstName = user.FirstName, LastName = user.LastName });
            }
            return result;
        }

        [HttpGet("[action]")]
        public UserDtoForExport GetDetailsForUser(string id)
        {
            var user = userRepository.Get(id);
            int likes = 0;
            int income = 0;
            foreach(Project p in user.Projects)
            {
                likes += p.LikedByUsers.Count;
                income += p.Price * p.PurchasedBy.Count;
            }
            return new UserDtoForExport { Id = id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Projects = user.Projects.Count, Likes = likes, Income = income };
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserDto> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new AppUser
                    {
                        FirstName = item.Name,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        //PhoneNumber = item.PhoneNumber,
                        Role = "User",
                        Projects = new List<Project>(),
                        LikedProjects=new List<Like>(),
                        PurchasedProjects=new List<Purchase>(),
                        ProfileImage=null,
                        ProfileImageId=null

                    };
                    var result = userManager.CreateAsync(user, item.Password).Result;

                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
