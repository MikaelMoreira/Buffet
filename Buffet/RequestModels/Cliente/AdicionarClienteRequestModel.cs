using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet.Tipos;
using static Buffet.Models.Buffet.Tipos.TipoClienteService;

namespace Buffet.RequestModels.Cliente
{
    public class AdicionarClienteRequestModel : IDadosBasicosCliente
    {

        public string Nome { get; set; }
        public string  Tipo { get; set;}
        public string CpfCnpj { get; set; }
        public string Data { get; set; }
        public string Email  { get; set; }
        public string Endereco { get; set; }
        public string Observacao { get; set; }
        public string DataAdicao { get; set; }
        
        public string DataModificacao { get; set; }
        


        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }



    }
}
