using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Acesso;
using Buffet.RequestModels;
using Buffet.ViewModels;

namespace Buffet.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AcessoService _acessoService;

        public HomeController(AcessoService acessoService, ILogger<HomeController> logger)
        {
            _acessoService = acessoService ;
            _logger = logger;
        }
        
        
        public IActionResult Index()
        {
            return View();
        }
        
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Cadastro()
        {

            var viewmodel = new CadastroViewModel();

            viewmodel.Mensagem = (string) TempData["msg-cadastro"];
            viewmodel.Erro = (string[]) TempData["msg-erro"];

        


            return View(viewmodel);
        }
        
        [HttpPost]
        public async Task<RedirectResult> Cadastro(CadastroRequestModel request)
        {
            var redirectUrl = "/Home/Cadastro";

            var email = request.Email;
            var senha = request.Senha;
            var confirmasenha = request.ConfirmarSenha;

            if (email == null)
            {
                TempData["msg-cadastro"] = "Por favor informe o e-mail.";
                return Redirect(redirectUrl);
            }

            try
            {
                await _acessoService.RegistrarUsuario(email, senha);
                return Redirect(url:"/Home/Login");
            }
            catch (CadastroException e)
            {
                var listErrors = new List<string>();

                foreach (var identityError in e.Erros)
                {
                    listErrors.Add(identityError.Description);
                }
                TempData["msg-erro"] = listErrors;
            }

            return Redirect(redirectUrl);
            
            
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            var viewmodel = new LoginViewModel();
            
            viewmodel.MensagemEmail = (string) TempData["login-email"];
            viewmodel.MensagemSenha = (string) TempData["login-senha"]; 
            viewmodel.Erro = (string) TempData["login-erro"];
           

            return View(viewmodel);
        }
        
        [HttpPost]
        public async Task<RedirectResult> Login(LoginRequestModel request)
        {
            var redirectUrl = "/Home/Login";

            var email = request.Email;
            var senha = request.Senha;
            
            if (email == null)
            {
                TempData["login-email"] = "Por favor informe o e-mail.";
                return Redirect(redirectUrl);
            }
            
            if (senha == null)
            {
                TempData["login-senha"] = "Por favor informe a senha.";
                return Redirect(redirectUrl);
            }

            try
            {
                await _acessoService.VerificarLogin(email, senha);
                return Redirect(url:"/Interno/Index");
            }
            catch (LoginException e)
            {
                e.Erro = "Não foi possível logar, Pois o Usuário e a Senha estão incorretos";
                TempData["login-erro"] = e.Erro;
                
            }
            
            return Redirect(redirectUrl);
        }
        
        
        public IActionResult Termo()
        {
            return View();
        }
        
        
        public IActionResult Recuperacao()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}