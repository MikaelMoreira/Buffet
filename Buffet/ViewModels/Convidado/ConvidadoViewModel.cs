using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Convidado
{
    public class ConvidadoViewModel
    {
        public string mensagem_sucesso { get; set; }

        public string[] mensagem_erro { get; set; }

        public List<SituacaoConvidadoEntity> Situacao { get; set; }
        public List<EventoEntity> Eventos { get; set; }



        public ConvidadoViewModel()
        {
            

            Situacao = new List<SituacaoConvidadoEntity>
            {
                new SituacaoConvidadoEntity(0, "")
            };

            Eventos = new List<EventoEntity>
            {
                new EventoEntity(0, "")
            };

        }

    }
}
