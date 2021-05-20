using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Buffet.Tipos;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public ClienteEntity()
        {
            
        }

        [Key] public int Id { get; set; }
        
        public TipoClienteEntity Tipo { get; set; }

        public string Nome { get; set; }

        public string CPF_CNPJ { get; set; }

        public string DataDeNascimento { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string Observacao { get; set; }

        public DateTime DataDeinsercao { get; set; }

        public DateTime DataDeModificacao { get; set; }


        public ClienteEntity(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public ClienteEntity( string nome, string cpfCnpj)
        {
            Nome = nome;
            CPF_CNPJ = cpfCnpj;
        }



    }
}