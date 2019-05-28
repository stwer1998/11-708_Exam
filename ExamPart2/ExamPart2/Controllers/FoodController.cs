using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExamPart2.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult GetFoods()
        {
            return View();
        }

        public IActionResult AddFood()
        {
            return View();
        }
    }
}