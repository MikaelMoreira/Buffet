using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Situações
{
    public class SituacaoEventoEntity
    {
        [Key] public int Id { get; set; }

        public string Descricao { get; set; }

        public SituacaoEventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public SituacaoEventoEntity()
        {
            
        }



    }





}