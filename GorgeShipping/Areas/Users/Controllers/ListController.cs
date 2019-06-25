using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using GorgeShipping.Data;
using GorgeShipping.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GorgeShipping.Controllers
{
    [Area("Users")]
    public class ListController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserListViewModel UserListVM { get; set; }
        public ListController(ApplicationDbContext db)
        {
            _db = db;

            UserListVM = new UserListViewModel
            {
                Users = new Models.User(),
                Addresses = new Models.Address(),
                TelephoneNumbers = new Models.TelNo()
            };
        }


        public IActionResult Index()
        {
            var lstUser =  _db.Users.Include(a => a.Addresses).Include(a => a.TelephoneNumbers).ToList();
            return View(lstUser);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(UserListVM);
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(UserListVM);
            }

            _db.Users.Add(UserListVM.Users);

            UserListVM.Addresses.UserId = UserListVM.Users.id;
            UserListVM.TelephoneNumbers.UserId = UserListVM.Users.id;          

            _db.Addresses.Add(UserListVM.Addresses);
            _db.TelephoneNumbers.Add(UserListVM.TelephoneNumbers);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}