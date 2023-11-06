using Child_Care_Mangement_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
       

        public HomeController(ILogger<HomeController> logger,SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user!=null)
            {
                if(await userManager.IsInRoleAsync(user,"Admin"))
                {
                    return RedirectToAction("Index", "Admin", null);
                }
                else if (await userManager.IsInRoleAsync(user, "Parent"))
                {
                    return RedirectToAction("Index", "Parent", null);
                }
                else if (await userManager.IsInRoleAsync(user, "Supervisor")|| await userManager.IsInRoleAsync(user, "Carer"))
                {
                    return RedirectToAction("Index", "Carer", null);
                }

            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Programs()
        {
            return View();
        }
        public IActionResult Contact()
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
