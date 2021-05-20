using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;
using Buffet.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Buffet.Models.Buffet.Evento.EventoService;

namespace Buffet.RequestModels.Evento
{
    public class AdicionarEventoRequestModel : IDadosBasicosEvento
    {

         public int Id { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public string DataInic { get; set; }

        public string HoraInic { get; set; }

        public string DataFim { get; set; }

        public string HoraFim { get; set; }

        public string Cliente { get; set; }

        public string Situacao { get; set; }

        public string local{ get; set; }

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
