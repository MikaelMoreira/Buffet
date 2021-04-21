namespace Buffet.Models.Buffet.Tipos
{
    public class TipoEventoEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public TipoEventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}