﻿using Microsoft.AspNetCore.Mvc;

namespace Dive_Deep.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
