using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sisteme1.Models;
using System.Diagnostics;

namespace Sisteme1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult FormaTeDhenaPersonale()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormaTeDhenaPersonale(Guest guest)
        {
            HttpContext.Session.SetString("Preferenca Muzikore", guest.MusicName);
            return RedirectToAction("Profil");
        }
        [Authorize]
        public IActionResult Profil()
        {
            var guest = new Guest
            {
                MusicName = HttpContext.Session.GetString("Preferenca Muzikore"),
            };

            return View(guest);
        }
        public IActionResult Pastro()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Profil");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}