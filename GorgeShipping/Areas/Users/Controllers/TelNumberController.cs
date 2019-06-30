using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GorgeShipping.Data;
using GorgeShipping.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GorgeShipping.Areas.Users.Controllers
{
    [Area("Users")]
    public class TelNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserListViewModel UserListVM { get; set; }
        public TelNumberController(ApplicationDbContext db)
        {
            _db = db;

            UserListVM = new UserListViewModel
            {
                Users = new Models.User(),
                Addresses = new Models.Address(),
                Addresses2 = new Models.Address(),
                TelephoneNumbers = new Models.TelNo(),
                TelephoneNumbers2 = new Models.TelNo()

            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Guid id)
        {
            if (ModelState.IsValid)
            {
                UserListVM.TelephoneNumbers.UserId = id;
                _db.TelephoneNumbers.Add(UserListVM.TelephoneNumbers);

                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(UserListVM);
        }

    }
}