using System;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public TipoClienteEntity Tipo { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string Observacao { get; set; }

        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }

        public ClienteEntity(TipoClienteEntity tipo, string nome, string cpf, string cnpj, DateTime dataDeNascimento, string email)
        {
            Tipo = tipo;
            Nome = nome;
            CPF = cpf;
            CNPJ = cnpj;
            DataDeNascimento = dataDeNascimento;
            Email = email;
        }
    }
}