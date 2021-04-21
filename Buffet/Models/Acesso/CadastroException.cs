using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Acesso
{
    public class CadastroException : Exception
    {
        public IEnumerable<IdentityError> Erros { get; set; }

        public CadastroException(IEnumerable<IdentityError> erros)
        {
            Erros = erros;
        }
    }
}