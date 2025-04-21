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


        [Authorize] // Garante que apenas usuários autenticados possam acessar
        public IActionResult Welcome()
        {
            var userName = User.Identity.Name; // Obtém o nome do usuário logado
            ViewData["UserName"] = userName;
            return View();
        }
    }
}
