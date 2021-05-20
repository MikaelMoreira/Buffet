using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Local;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        [Key] public int Id { get; set; }
        
        public TipoEventoEntity Tipo { get; set; }

        public string Descricao { get; set; }

        public string DataInic { get; set; }
        
        public string HoraInic { get; set; }

        public string DataFim { get; set; }
        
        public string HoraFim { get; set; }

        public ClienteEntity Cliente { get; set; }

        public SituacaoEventoEntity Situacao { get; set; }

        public LocalEntity Local { get; set; }

        public string Observacao { get; set; }
        
        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }


        public EventoEntity()
        {

        }

        public EventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

       




    }
}