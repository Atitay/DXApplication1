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
            if (!ModelState.IsValid)
            {
                return View(UserListVM);
            }

            UserListVM.Addresses.UserId = id;
            _db.Addresses.Add(UserListVM.Addresses);
          
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserListVM.Addresses = await _db.Addresses.FirstOrDefaultAsync(u => u.UserId == id);


            if (UserListVM.Users == null)
            {
                return NotFound();
            }
            return View(UserListVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Edit Action  Method
        public async Task<IActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = _db.Users.Where(m => m.id == UserListVM.Users.id).FirstOrDefault();

                UserListVM.Addresses.UserId = UserListVM.Users.id;

                var AddrFromDb = _db.Addresses.Where(m => m.UserId == UserListVM.Addresses.UserId).FirstOrDefault();
 
                AddrFromDb.AddressDetail = UserListVM.Addresses.AddressDetail;
                AddrFromDb.District = UserListVM.Addresses.District;
                AddrFromDb.Province = UserListVM.Addresses.Province;
                AddrFromDb.Code = UserListVM.Addresses.Code;
                AddrFromDb.Note = UserListVM.Addresses.Note;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(UserListVM);
        }
    }
}