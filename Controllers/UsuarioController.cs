using DecideAi.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using DecideAi.Data;
using DecideAi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DecideAi.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Cadastro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                // Criptografar senha
                usuarioModel.Senha = usuarioModel.Senha;

                _context.Usuario.Add(usuarioModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O Usuário foi cadastrado com sucesso";
                return RedirectToAction("Login");
            }
            return View(usuarioModel);
        }


        // Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var user = _context.Usuario.FirstOrDefault(u => u.Email == email);
            if (user != null && user.Senha == senha)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Nome),
            new Claim(ClaimTypes.Email, user.Email)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Lembrar do login
                };

                await HttpContext.SignInAsync("CookieAuth",
                    new ClaimsPrincipal(claimsIdentity), authProperties);


                // Redireciona para a página de boas-vindas
                return RedirectToAction("Welcome", "Home");
            }

            ModelState.AddModelError("", "Email ou senha inválidos");
            return View();
        }

    }
}
