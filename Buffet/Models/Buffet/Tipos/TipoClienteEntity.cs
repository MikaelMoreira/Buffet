using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Buffet.Models.Buffet.Tipos
{
    public class TipoClienteEntity
    {
        
        [Key] public int Id { get; set; }

        public string Descricao { get; set; }


        public TipoClienteEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public TipoClienteEntity( int id)
        {
            Id = id;
        }

        public TipoClienteEntity()
        {
        }
    }
}