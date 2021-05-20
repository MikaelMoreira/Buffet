using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Buffet.Models.Buffet.Tipos;
using Buffet.Models.Buffet.Local;

namespace Buffet.ViewModels.Local
{
    public class LocalViewModel
    {

        public string mensagem_sucesso { get; set; }
        
        public string[] mensagem_erro { get; set; }

             
       
    }
}