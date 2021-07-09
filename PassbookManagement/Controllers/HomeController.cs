using System.Diagnostics;
using PassbookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassbookManagement.Framework;
using System.Threading.Tasks;

namespace PassbookManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("usrName,pasWord")] LoginHandler logHandler)
        {
            
            if(ModelState.IsValid)
            {

                //Route
                if (logHandler.EmployeeLogin())
                {
                    SessionHelper.SetSession(HttpContext, new SessionData() { Username = "NV_01", Type = "employee" });
                    return RedirectToAction("Create", "EmpPassbook", new { area = "BankEmployees" });
                }
                else
                    if (logHandler.CustomerLogin())
                    {
                        SessionHelper.SetSession(HttpContext, new SessionData() { Username = logHandler.GetUserName(), Type = "customer" });
                        return RedirectToAction("Create", "CusPassbook", new { area = "Customers" });
                    }
                    else
                    {
                        ViewBag.error = "Ten dang nhap hoac mk khong dung";
                        ModelState.AddModelError("", "Ten dang nhap hoac mat khau khong dung!");
                    }
            }
            else
            {
                ViewBag.error = "Dang nhap that bai";

            }


            return View(logHandler);
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
