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
                Addresses2 = new Models.Address(),
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

            UserListVM.TelephoneNumbers.IsDefault = true;

            _db.Addresses.Add(UserListVM.Addresses);
            _db.TelephoneNumbers.Add(UserListVM.TelephoneNumbers);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserListVM.Users = await _db.Users.SingleOrDefaultAsync(u => u.id == id);

            UserListVM.TelephoneNumbers = await _db.TelephoneNumbers.FirstOrDefaultAsync(u => u.UserId == id);
            
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
           
                UserListVM.TelephoneNumbers.UserId = UserListVM.Users.id;
               
                var TelFromDb = _db.TelephoneNumbers.Where(m => m.UserId == UserListVM.TelephoneNumbers.UserId).FirstOrDefault();
           
                var AddrFromDb = _db.Addresses.Where(m => m.UserId == UserListVM.Addresses.UserId).FirstOrDefault();
               

                userFromDb.Name = UserListVM.Users.Name;
                userFromDb.Email = UserListVM.Users.Email;                

                TelFromDb.TelNumber = UserListVM.TelephoneNumbers.TelNumber;
                

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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserListVM.Users = await _db.Users.SingleOrDefaultAsync(u => u.id == id);
            UserListVM.TelephoneNumbers = await _db.TelephoneNumbers.FirstOrDefaultAsync(u => u.UserId == id);
            UserListVM.Addresses = await _db.Addresses.FirstOrDefaultAsync(u => u.UserId == id);

            if (UserListVM.Users == null)
            {
                return NotFound();
            }
            return View(UserListVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Delete Action  Method
        public async Task<IActionResult> Delete(Guid id)
        {
            var lstUser = await _db.Users.FindAsync(id);

            _db.Users.Remove(lstUser);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}