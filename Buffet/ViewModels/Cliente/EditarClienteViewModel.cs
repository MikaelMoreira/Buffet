using System.Collections.Generic;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.ViewModels.Cliente
{
    public class EditarClienteViewModel
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string CpfCnpj { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }

        public string Endereco { get; set; }
        public string Observacao { get; set; }
            
        public string DataAdicao { get; set; }
            
        public string DataModificacao { get; set; }
        
        public string mensagem_sucesso { get; set; }
        
        public string[] mensagem_erro { get; set; }

        public List<TipoClienteEntity> Tipo{ get; set; }

        public EditarClienteViewModel()
        {
            Tipo = new List<TipoClienteEntity>
            {
                new TipoClienteEntity(1, "")
            };
        }
    }
}