using domain.DomainModels;
using domain.DTO;
using domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUserRepository userRepository;
        private readonly IRepository<ProfileImage> profileImageRepository;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserRepository userRepository, IRepository<ProfileImage> profileImageRepository)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
            this.profileImageRepository = profileImageRepository;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new AppUser
                    {
                        FirstName = request.Name,
                        LastName = request.LastName,
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        ProfileImageId=null,
                        ProfileImage=null,
                        Role = "User"
                    };
                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    Directory.CreateDirectory($".\\wwwroot\\userUploads\\{user.Id}");
                    if(user.Role=="User")
                        return RedirectToAction("Index", "MyProfile");
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userRepository.Get(userId);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditProfile(string firstName, string lastName, IFormFile profilePicture)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userRepository.Get(userId);
            if (profilePicture != null)
            {
                string imagePath = saveProfileImage(profilePicture,userId);
                ProfileImage profileImage = profileImageRepository.Insert(new ProfileImage { ImagePath = imagePath, AppUser=user });
                user.ProfileImageId = profileImage.Id;
                user.ProfileImage = profileImage;
            }
            user.FirstName = firstName;
            user.LastName = lastName;
            userRepository.Update(user);
            return RedirectToAction("Index", "MyProfile");

        }
        [HttpPost]
        public ActionResult ProfileImageUpload([FromForm] IFormFile profilePicture)
        {
            string newPath=saveImage(profilePicture);
            return Json(new { success = true, newImagePath = newPath });
        }
        public string saveImage(IFormFile file)
        {
            string pathToUpload = $".\\wwwroot\\temp\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var newPath = "/temp/" + file.FileName;
            return newPath;
        }
        public string saveProfileImage(IFormFile file, string userId)
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
    }
}
