using System;

namespace Buffet.Models.Acesso
{
    public class LoginException : Exception
    {
        public String Erro { get; set; }

        public LoginException(String erro )
        {
            Erro = erro;
        }
        
    }
}