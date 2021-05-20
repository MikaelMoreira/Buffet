using System.Collections.Generic;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.ViewModels.Cliente
{
    public class ListaClienteViewModel
    {
        public List<ClienteEntity> clientes { get; set; }
        public string Nome { get; set; }
        public string CpfCNPJ { get; set; }
        

        public ListaClienteViewModel()
        {
            clientes = new List<ClienteEntity>
            {
                
                new ClienteEntity("","")
                
            };

        }
    }
    
}