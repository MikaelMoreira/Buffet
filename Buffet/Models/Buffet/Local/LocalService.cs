using Buffet.DataBase;
using Buffet.Models.Buffet.Local;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Buffet.Models.Buffet.Local
{
    public class LocalService
    {
        private readonly DataBaseContext _databaseContext;


        public LocalService(

            DataBaseContext databaseContext         
        )

        {
            _databaseContext = databaseContext;           
        }

        public List<LocalEntity> ObterTodos()
        {
            return _databaseContext.Locais
                .ToList();
        }

       public LocalEntity ObterPorId(int id)
        {
            try
            {
                return _databaseContext.Locais.Find(id);
            }
            catch
            {
                throw new Exception("Local do ID #" + id + " não encontrado");
            }
        }

        private LocalEntity ValidarDadosBasicos(
            IDadosBasicosLocais dadosBasicos
        )
        {

            var entidade = new LocalEntity();

            entidade.Descricao = dadosBasicos.Descricao;
            entidade.Endereco = dadosBasicos.Endereco;


            return entidade;
        }

        public interface IDadosBasicosLocais
        {
            public string Descricao { get; set; }

            public string Endereco { get; set; }
           
        }

        public LocalEntity Adicionar(IDadosBasicosLocais dadosBasicos)
        {
            var novoLocal = ValidarDadosBasicos(dadosBasicos); ;
            _databaseContext.Locais.Add(novoLocal);
            _databaseContext.SaveChanges();

            return novoLocal;
        }


    }
}