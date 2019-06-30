using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GorgeShipping.Data;
using GorgeShipping.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GorgeShipping.Areas.Users.Controllers
{
    [Area("Users")]
    public class AddressController : Controller
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public UserListViewModel UserListVM { get; set; }
        public AddressController(ApplicationDbContext db)
        {
            _db = db;
            UserListVM = new UserListViewModel
            {
                Users = new Models.User(),
                Addresses = new Models.Address(),
                Addresses2 = new Models.Address(),
                TelephoneNumbers = new Models.TelNo()
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(UserListVM);
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Guid id)
        {
            if (ModelState.IsValid)
            {

                UserListVM.Addresses.UserId = id;
                _db.Addresses.Add(UserListVM.Addresses);

                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(UserListVM);
        }

    }
}