using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace GorgeShipping.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        //public JsonResult GetUsers()
        //{
        //    string[] users = new string[] { "Ya", "Bum", "Tai" };
            
        //    return Json(users);
        //}

        public IActionResult Create()
        {
            return View();
        }
    }
}