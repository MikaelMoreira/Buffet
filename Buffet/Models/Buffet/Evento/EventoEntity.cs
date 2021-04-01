using System;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public TipoEventoEntity Tipo { get; set; }

        public string Decricao { get; set; }

        public DateTime DataEHoraInic { get; set; }

        public DateTime DataEHoraFim { get; set; }

        public ClienteEntity Cliente { get; set; }

        public SituacaoEventoEntity Situacao { get; set; }

        public Local Local { get; set; }

        public string Observacao { get; set; }
        
        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }
    }
}