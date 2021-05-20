using Buffet.DataBase;
using Buffet.RequestModels.Convidado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Situações
{
    public class SituacaoConvidadoService
    {
        private readonly DataBaseContext _databaseContext;

        public SituacaoConvidadoService(

            DataBaseContext dataBaseContext
        )
        {
            _databaseContext = dataBaseContext;
        }

        

        public List<SituacaoConvidadoEntity> ObterTodos()
        {
            return _databaseContext.SituacaoConvidado
                .ToList();
        }

        public SituacaoConvidadoEntity ObterPorId(int id)
        {
            try
            {
               return _databaseContext.SituacaoConvidado.Find(id);
            }
           catch
            {
                throw new Exception("Situação do Convidado de ID #" + id + " não encontrada");
            }
        }


    }
}
