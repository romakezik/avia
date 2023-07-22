using avia.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace avia.Controllers
{

    public class HomeController : Controller
    {
        private EFDBContext _context;

        public HomeController(EFDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsersId") != null)
            {
                int userId = int.Parse(HttpContext.Session.GetString("UsersId"));

                // Найти пользователя в БД по ID
                Users user = _context.Users.FirstOrDefault(u => u.UsersID == userId);

                if (user != null)
                {
                    HomeModel _model = new HomeModel() { HelloMessage = "Hi, " + user.Login + "!" };
                    return View(_model);
                }
                else
                {
                    HomeModel _model = new HomeModel() { HelloMessage = "Hi, " + "unloginned user" + "!" };
                    return View(_model);
                }

            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
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