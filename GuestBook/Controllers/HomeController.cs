using GuestBook.Database;
using GuestBook.Domain;
using GuestBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> userManager;

        private readonly IRepository guestBookRepository;

        private IWebHostEnvironment hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IRepository guestBookRepository, 
                              IWebHostEnvironment hostEnvironment, UserManager<AppUser> userManager)
        {
            _logger = logger;
            this.guestBookRepository = guestBookRepository;
            this.hostEnvironment = hostEnvironment;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Index(int currentGroup)
        {
            ViewData["Group"] = currentGroup;
            var vm = new CommentsViewModel
            {
                Comments = guestBookRepository.GetComments(),
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Title = model.Title,
                    //Name = userManager.GetUserName(User),
                    Name = User.Identity.Name,
                    Date = DateTime.Now,
                    Text = model.Text,
                    Mood = (Mood)model.Mood,
                    PhotoUrl = "/Photos/user-photo.png"
                };

                guestBookRepository.AddComment(newComment);
                return RedirectToAction(nameof(Index));
            }

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


        [HttpGet]
        [Authorize]
        public IActionResult Edit([FromRoute] int id)
        {
            var comment = guestBookRepository.GetComment(id);

            if (User.Identity.Name == comment.Name)
            {
                EditViewModel vm = new EditViewModel
                {
                    Title = comment.Title,
                    Text = comment.Text,
                    Mood = comment.Mood
                };

                return View(vm);
            }

            return RedirectToAction("Index", "Home");
            
        }
    }
}
