using GuestBook.Domain;
using GuestBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;

        private readonly ILogger<HomeController> _logger;


        public AccountController(UserManager<AppUser> userManager,
                                  SignInManager<AppUser> signInManager,
                                   ILogger<HomeController> _logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._logger = _logger;
        }

        //REGISTER
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //create new identityUser
                var user = new AppUser {UserName = model.Email, Email = model.Email };

                //Create the account using userManager
                var registerResult = await userManager.CreateAsync(user, model.Password);

                //if created successfully sign in
                if (registerResult.Succeeded)
                {
                    await signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, false);
                    return RedirectToAction("index", "home");
                }

                //if not created successfully add the errors to the model state which will show in the validation-summary div
                foreach (var error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }


        //LOGOUT
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
                                    //action  //controller
            return RedirectToAction("index", "home");
        }



        //LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (loginResult.Succeeded)
                {                          //action  //controller
                    return RedirectToAction("index","home");

                }
               
                ModelState.AddModelError(string.Empty, "Invalid Login attempt");
       
            }

            return View(model);
        }


    }
}
