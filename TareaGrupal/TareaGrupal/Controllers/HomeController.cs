using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TareaGrupal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Principal()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            
            return View();

        }
    }
}
