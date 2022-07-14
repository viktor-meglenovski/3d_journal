using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace web.Controllers
{
    [Authorize]
    public class MyProfileController : Controller
    {
        private readonly IUserRepository userRepository;
        public MyProfileController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userRepository.Get(userId);
            return View(user);
        }
        [HttpGet]
        public IActionResult View(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == userId)
            {
                return RedirectToAction("Index");
            }
            var user = userRepository.Get(id);
            return View(user);
        }
    }
}
