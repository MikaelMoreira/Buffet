using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.ViewModels.Cliente
{
    public class ClienteViewModel
    {

        public string mensagem_sucesso { get; set; }
        
        public string[] mensagem_erro { get; set; }

        public List<TipoClienteEntity> Tipo{ get; set; }

        public ClienteViewModel()
        {
            Tipo = new List<TipoClienteEntity>
            {
                new TipoClienteEntity(1, "")
            };
        }
       
    }
}