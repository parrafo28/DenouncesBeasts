using System.Diagnostics;
using DenouncesBeasts.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenouncesBeasts.Frontend.Controllers
{
    public class HomeController : Controller
    {
         

        public IActionResult Index()
        {
            ViewBag.WhatEver = "Aqui hay algo";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
