using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situações;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        [Key] public int Id { get; set; }
        
        public string Nome { get; set; }

        public string CPF { get; set; }
        
        public string DataDeNascimento { get; set; }

        public string Email { get; set; }

        public EventoEntity Evento { get; set; }

        public SituacaoConvidadoEntity Situacao { get; set; }
        
        public string Observacao { get; set; }

        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }



        public ConvidadoEntity()
        {

        }

        public ConvidadoEntity(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }







    }

}