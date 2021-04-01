using System;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situações;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        public string Nome { get; set; }

        public string CPF { get; set; }
        
        public DateTime DataDeNascimento { get; set; }

        public string Email { get; set; }

        public EventoEntity Evento { get; set; }

        public SituacaoConvidadoEntity Situacao { get; set; }
        
        public string Observacao { get; set; }

        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }
    }
}