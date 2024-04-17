using Microsoft.AspNetCore.Mvc;
using PortalUploadingMeterData.Models;
using System.Diagnostics;

namespace PortalUploadingMeterData.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public IActionResult DropDatabase()
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        context.DropDatabase();
        //    }

        //    return Content("Database dropped successfully.");
        //}
        public IActionResult Index()
        {
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