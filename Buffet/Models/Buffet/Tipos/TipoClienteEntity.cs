using System.Numerics;

namespace Buffet.Models.Buffet.Tipos
{
    public class TipoClienteEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }


        public TipoClienteEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}