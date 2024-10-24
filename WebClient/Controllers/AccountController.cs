using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
