using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sitedyplom.Data;
using Sitedyplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private ApplicationDbContext db;
        private readonly SignInManager<User> signInManager;

        public UserController(ApplicationDbContext context, SignInManager<User> signInMgr, UserManager<User> userMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            db = context;
        }

        
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {

                        return Redirect("Index");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
        

            return View(new CreateUserViewModel());
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View(new CreateUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.UserName, Email = model.Email };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    return Redirect("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           
           await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
