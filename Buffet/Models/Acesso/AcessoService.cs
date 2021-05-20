using System;
using System.Threading.Tasks;
using Buffet.Models.Buffet.User;
using Microsoft.AspNetCore.Identity;


namespace Buffet.Models.Acesso
{
    public class AcessoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        
        
        

        public AcessoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AutenticarUsuario(string email, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(email, senha, false, false);
            
            if (!result.Succeeded)
            {
                throw new Exception ("Usuário ou Senha inválidos");
            }
        }
        public async Task RegistrarUsuario(string email, string senha)
        {
            var user = new Usuario()
            {
                UserName = email,
                Email = email

            };

            var result = await _userManager.CreateAsync(user, senha);

            if (!result.Succeeded)
            {
                throw new CadastroException (result.Errors);
            }
        }

        public async Task VerificarLogin(string email, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(email, senha, false, false);
            
            if (!result.Succeeded)
            {
                throw new LoginException("Usuário ou Senha inválidos");
            }
        }

    };
}