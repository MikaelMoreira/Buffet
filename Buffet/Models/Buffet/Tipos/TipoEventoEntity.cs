using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Tipos
{
    public class TipoEventoEntity
    {
        [Key]public int Id { get; set; }

        public string Descricao { get; set; }


        public TipoEventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }


        public TipoEventoEntity()
        {
         
        }



    }
}