using domain.DomainModels;
using domain.Identity;
using domain.Relations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ISoftwareRepository softwareRepositoryAdvanced;
        private readonly IRepository<Software> softwareRepository;

        public AdminController(IUserRepository userRepository, ISoftwareRepository softwareRepositoryAdvanced, IRepository<Software> softwareRepository)
        {
            this.userRepository = userRepository;
            this.softwareRepositoryAdvanced = softwareRepositoryAdvanced;
            this.softwareRepository = softwareRepository;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                return View();
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        public IActionResult CleanTemp()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                string path= $".\\wwwroot\\temp";
                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        public IActionResult ShowAllSoftware()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                var model = softwareRepositoryAdvanced.GetAllWithLogo();
                return View(model);
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        public IActionResult AddSoftware()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                return View();
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        [HttpPost]
        public IActionResult AddSoftware(string name, IFormFile logo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                SoftwareImage si = new SoftwareImage { ImagePath = saveImage(logo) };
                Software s = new Software { Name = name, Logo = si, LogoId = si.Id, UsedInProjects = new List<ProjectSoftware>() };
                softwareRepository.Insert(s);
                return RedirectToAction("ShowAllSoftware");
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        public IActionResult DeleteSoftware(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            if (user.Role == "Admin")
            {
                Software toDelete = softwareRepositoryAdvanced.GetWithLogo(id);
                var filename = $".\\wwwroot\\{toDelete.Logo.ImagePath}";
                System.IO.File.Delete(filename);
                softwareRepository.Delete(toDelete);
                return RedirectToAction("ShowAllSoftware");
            }
            return RedirectToAction("NoPermissions", "Home");
        }

        public string saveImage(IFormFile file)
        {
            string pathToUpload = $".\\wwwroot\\images\\software\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var newPath = "/images/software/" + file.FileName;
            return newPath;
        }
    }
}
