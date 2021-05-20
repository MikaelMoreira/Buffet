using Buffet.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Tipos
{
    public class TipoEventoService
    {

        private readonly DataBaseContext _databaseContext;

        public TipoEventoService(

            DataBaseContext dataBaseContext
        )
        {
            _databaseContext = dataBaseContext;
        }

        public ICollection<TipoEventoEntity> ObterTodos()
        {
            return _databaseContext.TipoEvento
                .ToList();
        }

        public TipoEventoEntity ObterPorId(int id)
        {
            try
            {
                return _databaseContext.TipoEvento.Find(id);
            }
            catch
            {
                throw new Exception("TipoEvento de ID #" + id + " não encontrada");
            }
        }


    }
}
