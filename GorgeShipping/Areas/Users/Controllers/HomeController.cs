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
                Addresses2 = new Models.Address(),
                TelephoneNumbers = new Models.TelNo()
            };
        }

        public IActionResult Index(Guid? id)
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
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(UserListVM);
            }

            _db.Users.Add(UserListVM.Users);

            UserListVM.Addresses.UserId = UserListVM.Users.id;

            UserListVM.TelephoneNumbers.UserId = UserListVM.Users.id;
            UserListVM.TelephoneNumbers.IsDefault = true;

            _db.TelephoneNumbers.Add(UserListVM.TelephoneNumbers);
            _db.Addresses.Add(UserListVM.Addresses);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserListVM.Addresses = await _db.Addresses.FirstOrDefaultAsync(u => u.UserId == id);
            UserListVM.Addresses2 = await _db.Addresses.LastOrDefaultAsync(u => u.UserId == id);

            UserListVM.TelephoneNumbers = await _db.TelephoneNumbers.FirstOrDefaultAsync(u => u.UserId == id);
            UserListVM.TelephoneNumbers2 = await _db.TelephoneNumbers.LastOrDefaultAsync(u => u.UserId == id);


            if (UserListVM.Users == null)
            {
                return NotFound();
            }
            return View(UserListVM);

        }

    }
}