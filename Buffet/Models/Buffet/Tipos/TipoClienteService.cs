using System;
using Buffet.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buffet.Models.Buffet.Tipos
{
    public class TipoClienteService
    {
        private readonly DataBaseContext _databaseContext;


        public TipoClienteService(
            
            DataBaseContext dataBaseContext          
        )
        {
            _databaseContext = dataBaseContext;
        }



        public ICollection<TipoClienteEntity> ObterTodos()
        {
            return _databaseContext.TipoCliente
                .ToList();
        }
        
        public TipoClienteEntity ObterPorId(int id)
        {
            try {
                return _databaseContext.TipoCliente.Find(id);
            } catch {
                throw new Exception("TipoCliente de ID #" + id + " não encontrada");
            }
        }

        public interface IDadosBasicosCliente
        {
            public string Nome { get; set; }
            
            public string Tipo { get; set; }

            public string CpfCnpj { get; set; }
            public string Data { get; set; }
            public string Email { get; set; }

            public string Endereco { get; set; }
            public string Observacao { get; set; }
            
            public string DataAdicao { get; set; }
            
            public string DataModificacao { get; set; }

        }







    }
}