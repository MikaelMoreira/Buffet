using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;
using Buffet.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet.Local;

namespace Buffet.ViewModels.Evento
{
    public class EventoViewModel
    {

        public string mensagem_sucesso { get; set; }

        public string[] mensagem_erro { get; set; }


        public List<TipoEventoEntity> Tipo { get; set; }

        public List<ClienteEntity> Cliente { get; set; }

        public List<SituacaoEventoEntity> Situacao { get; set; }

        public List<LocalEntity> local  { get; set; }


        public EventoViewModel()
        {
            Tipo = new List<TipoEventoEntity>
            {
                new TipoEventoEntity(0, "")
            };

            Cliente = new List<ClienteEntity>
            {
                new ClienteEntity(0, "")
            };

            Situacao = new List<SituacaoEventoEntity>
            {
                new SituacaoEventoEntity(0, "")
            };

            local = new List<LocalEntity>
            {
                new LocalEntity(0, "")
            };

        }

    }
}
