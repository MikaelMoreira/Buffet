using Buffet.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Situações
{
    public class SituacaoEventoService
    {
        private readonly DataBaseContext _databaseContext;

        public SituacaoEventoService(

            DataBaseContext dataBaseContext
        )
        {
            _databaseContext = dataBaseContext;
        }

        public ICollection<SituacaoEventoEntity> ObterTodos()
        {
            return _databaseContext.SituacaoEvento
                .ToList();
        }

        public SituacaoEventoEntity ObterPorId(int id)
        {
            try
            {
                return _databaseContext.SituacaoEvento.Find(id);
            }
            catch
            {
                throw new Exception("Situação do evento de ID #" + id + " não encontrada");
            }
        }

    }
}
