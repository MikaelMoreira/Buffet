using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Local

{
    public class LocalEntity
    {
        [Key] public int Id { get; set; } 
        
        public string Descricao { get; set; }

        public string Endereco { get; set; }



        public LocalEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public LocalEntity()
        {
           
        }





    }
}