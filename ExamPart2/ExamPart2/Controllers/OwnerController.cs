using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPart2.Models;
using ExamPart2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamPart2.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        private IdentityDbContext db;
        public OwnerController(IdentityDbContext context)
        {
            db = context;
        }
        public IActionResult GetList()
        {
            ViewBag.User = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Restaurants).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRestaurant(RestaurantModel restaurant)
        {
            var u=db.Users.Where(x => x.Login==User.Identity.Name).Include(x=>x.Restaurants).FirstOrDefault();
            u.Restaurants.Add(new Restaurant { Name=restaurant.Name,Foods=new List<Food>()});
            return View();
        }
    }
}