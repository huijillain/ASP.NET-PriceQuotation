using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceQuotationMVC.Models;

namespace PriceQuotationMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]                 // when user open URL, GET will open
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = 0;    // assign initial value to 0
            ViewBag.Total = 0;
            return View();     // return view from homepage
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)   // this Index will take FutureValueModel, process data here
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountAmount = model.CalculateDiscountAmount();
                ViewBag.Total = model.CalculateTotal();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.Total = 0;
            }
            return View(model);
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
