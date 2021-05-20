using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Buffet.Models.Buffet.Convidado.ConvidadoService;

namespace Buffet.RequestModels.Convidado
{
    public class AdicionarConvidadoRequestModel : IDadosBasicosConvidado
    {

      
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string DataDeNascimento { get; set; }

        public string Email { get; set; }

        public string Evento { get; set; }

        public string Situacao { get; set; }

        public string Observacao { get; set; }

        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }


        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }


    }
}
