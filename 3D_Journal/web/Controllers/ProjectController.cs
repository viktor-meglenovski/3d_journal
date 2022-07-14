using domain.DomainModels;
using domain.Identity;
using domain.Relations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository.Interface;
using service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ISoftwareRepository softwareRepository;
        private readonly IProjectService projectService;
        private readonly IUserRepository userRepository;
        private readonly IRepository<OtherProjectImage> otherProjectImageRepository;
        private readonly IRepository<ProjectImage> projectImageRepository;
        private readonly IRepository<UploadedFile> uploadedFileRepository;
        private readonly IRepository<Like> likeRepository;
        public ProjectController(ISoftwareRepository softwareRepository, IProjectService projectService, IUserRepository userRepository, IRepository<OtherProjectImage> otherProjectImageRepository, IRepository<ProjectImage> projectImageRepository, IRepository<UploadedFile> uploadedFileRepository, IRepository<Like> likeRepository)
        {
            this.softwareRepository = softwareRepository;
            this.projectService = projectService;
            this.userRepository = userRepository;
            this.otherProjectImageRepository = otherProjectImageRepository;
            this.projectImageRepository = projectImageRepository;
            this.uploadedFileRepository = uploadedFileRepository;
            this.likeRepository = likeRepository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Softwares = softwareRepository.GetAllWithLogo();
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string description, int price, List<Guid> softwaresUsed, IFormFile mainImage, List<IFormFile> otherImages, IFormFile uploadedFile)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = userRepository.Get(userId);
            string mainImagePath = saveImage(userId, mainImage);
            string uploadedFilePath = saveImage(userId, uploadedFile);
            List<string> otherImagesPaths = new List<string>();
            foreach(IFormFile f in otherImages)
            {
                otherImagesPaths.Add(saveImage(userId,f));
            }
            Project p=projectService.CreateNewProject(user, name, description, price, softwaresUsed, mainImagePath, otherImagesPaths,uploadedFilePath);
            return RedirectToAction("View", "Project", new { id = p.Id });
        }
        public string saveImage(string userId, IFormFile file)
        {
            string pathToUpload = $".\\wwwroot\\userUploads\\{userId}\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var newPath = "/userUploads/"+userId+"/" + file.FileName;
            return newPath;
        }
        [HttpGet]
        public IActionResult View(Guid id)
        {
            var project = projectService.Get(id);
            ViewBag.IsLiked = true;
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(project);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var project = projectService.Get(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (project.CreatorId == userId)
            {
                ViewBag.Softwares = softwareRepository.GetAllWithLogo();
                return View(project);
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Guid id, string name, string description, int price, List<Guid> softwaresUsed, IFormFile mainImage, List<IFormFile> otherImages, IFormFile uploadedFile)
        {
            var project = projectService.Get(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (project.CreatorId == userId)
            {
                string mainImagePath = "";
                if (mainImage != null)
                {
                    mainImagePath = saveImage(userId, mainImage);
                    var filename = $".\\wwwroot\\{project.MainImage.ImagePath}";
                    System.IO.File.Delete(filename);
                    projectImageRepository.Delete(project.MainImage);
                }
                string uploadedFilePath = "";
                if (uploadedFile != null)
                {
                    uploadedFilePath = saveImage(userId, uploadedFile);
                    var filename = $".\\wwwroot\\{project.UploadedFile.Path}";
                    System.IO.File.Delete(filename);
                    uploadedFileRepository.Delete(project.UploadedFile);
                }
                
                List<string> otherImagesPaths = new List<string>();
                foreach (IFormFile f in otherImages)
                {
                    otherImagesPaths.Add(saveImage(userId, f));
                }
                Project p = projectService.EditProject(id, name, description, price, softwaresUsed, mainImagePath, otherImagesPaths, uploadedFilePath);
                return RedirectToAction("View", "Project", new { id=id});
            }
            return RedirectToAction("NoPermissions", "Home");
           
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var project = projectService.Get(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (project.CreatorId == userId)
            {
                projectService.Delete(project);
                System.IO.File.Delete($".\\wwwroot\\{project.MainImage.ImagePath}");
                System.IO.File.Delete($".\\wwwroot\\{project.UploadedFile.Path}");
                foreach(OtherProjectImage i in project.OtherImages)
                {
                    System.IO.File.Delete($".\\wwwroot\\{i.ImagePath}");
                }
                return RedirectToAction("Index", "MyProfile");
            }
            return RedirectToAction("NoPermissions", "Home");
        }
        [HttpGet]
        public IActionResult DeleteImage(Guid id)
        {
            var toDelete = otherProjectImageRepository.Get(id);
            if (toDelete != null)
            {
                var project = projectService.Get(toDelete.ProjectId);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (project.CreatorId != userId)
                    return RedirectToAction("NoPermissions","Home");

                var filename= $".\\wwwroot\\{toDelete.ImagePath}";
                System.IO.File.Delete(filename);
                otherProjectImageRepository.Delete(toDelete);
                return Json(true);

            }
            return Json(false);
        }
        [HttpGet]
        public IActionResult Like(Guid id)
        {
            var project = projectService.Get(id);
            if (project != null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                AppUser user = userRepository.Get(userId);
                var exists = likeRepository.GetAll().Where(x => x.UserId == userId && x.ProjectId == id).FirstOrDefault();
                if (exists == null)
                    likeRepository.Insert(new Like { Project=project, ProjectId=id, UserId=userId, User=user});
                else
                    likeRepository.Delete(exists);
                var newCount = likeRepository.GetAll().Where(x => x.ProjectId == id).Count();
                return Json(new { success = true, newCount = newCount });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public ActionResult ViewLikes(Guid id)
        {
            if (User.IsInRole("Administrator"))
                return View("~/Views/Administrator/NoPermissionsAdministrator.cshtml");
            var project = projectService.Get(id);
            if (project != null)
            {
                return PartialView(project.LikedByUsers.Select(x=>x.User).ToList());
            }
            return new NotFoundResult();
        }
    }
}
