using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideAi.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [Authorize] // Garante que apenas usu�rios autenticados possam acessar
        public IActionResult Welcome()
        {
            var userName = User.Identity.Name; // Obt�m o nome do usu�rio logado
            ViewData["UserName"] = userName;
            return View();
        }
    }
}
