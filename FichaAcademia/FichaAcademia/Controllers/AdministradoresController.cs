using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FichaAcademia.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdministradoresController(IAdministradorRepositorio administradorRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _administradorRepositorio = administradorRepositorio;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) // Limpa as sessoes
            {
                HttpContext.SignOutAsync(); //Desloga
                HttpContext.Session.Clear(); //Limpa a sessao
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdministradorViewModel administradorViewModel)
        {
            //Se nao existe
            if(! _administradorRepositorio.AdministradorExiste(administradorViewModel.Email, administradorViewModel.Senha))
            {
                ModelState.AddModelError(string.Empty, "Email e/ou senha inválido!");
                return View(administradorViewModel);
            }

            //Loga o usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, administradorViewModel.Email)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            //Armazenar email em uma sessao
            HttpContext.Session.SetString("Usuario", administradorViewModel.Email);

            ViewData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return RedirectToAction("Index", "Alunos");
        }

        public async Task<IActionResult> Logout()
        {
            //Desloga e redireciona para a pagina de Login
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
