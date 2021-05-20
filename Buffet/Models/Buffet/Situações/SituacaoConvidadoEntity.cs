using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Situações
{
    public class SituacaoConvidadoEntity
    {
        [Key] public int Id { get; set; }

        public string Descricao { get; set; }

        public SituacaoConvidadoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public SituacaoConvidadoEntity()
        {

        }




    }
}