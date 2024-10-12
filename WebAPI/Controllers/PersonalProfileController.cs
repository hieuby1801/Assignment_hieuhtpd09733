using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PersonalProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
