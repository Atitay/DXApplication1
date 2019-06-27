using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorgeShipping.Data;
using GorgeShipping.Models;
using GorgeShipping.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GorgeShipping.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserListViewModel UserListVM { get; set; }
        public HomeController(ApplicationDbContext db)
        {
            _db = db;

            UserListVM = new UserListViewModel
            {
                Users = new Models.User(),
                Addresses = new Models.Address(),
                TelephoneNumbers = new Models.TelNo()
            };
        }

        public IActionResult  Index(string searchPhone = null)
        {
            var lstUser = _db.Users.Include(a => a.TelephoneNumbers).ToList();
          
            return View(lstUser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _db.Users.Add(user);      

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


    }
}