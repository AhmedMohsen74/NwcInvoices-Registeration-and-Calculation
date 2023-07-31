using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;
using System.Diagnostics;

namespace NWC_Water_Consumption_project.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Button9()
        {
            // Get the current process ID
            int currentProcessId = Process.GetCurrentProcess().Id;

            // Get the current process
            Process currentProcess = Process.GetProcessById(currentProcessId);

            // Stop the current process
            currentProcess.Kill();
            // Return a view or redirect to another page
            return View();

        }
    }
}