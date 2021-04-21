namespace Buffet.Models.Buffet.Situações
{
    public class SituacaoConvidadoEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public SituacaoConvidadoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}