using domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using repository.Interface;
using service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService projectService;
        private readonly IUserRepository userRepository;

        public HomeController(ILogger<HomeController> logger, IProjectService projectService, IUserRepository userRepository)
        {
            _logger = logger;
            this.projectService = projectService;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var model = projectService.GetAllProjectWithDetails().OrderByDescending(x=>x.LikedByUsers.Count).Take(10).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NoPermissions()
        {
            return View();
        }
        [Authorize]
        public IActionResult Search(string searchText)
        {
            ViewBag.Projects = projectService.Search(searchText);
            ViewBag.Users = userRepository.search(searchText);
            ViewBag.SearchText = searchText;
            return View();
        }
    }
}
