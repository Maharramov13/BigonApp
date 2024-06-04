using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BigonApp.MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

     
    }
}
