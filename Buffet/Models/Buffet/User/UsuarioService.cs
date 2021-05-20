using System.Collections.Generic;
using Buffet.DataBase;

namespace Buffet.Models.Buffet.User
{
    public class UsuarioService
    {
        private readonly DataBaseContext _dataBaseContext;

        public UsuarioService(DataBaseContext dataBaseContext)
        {

            _dataBaseContext = dataBaseContext;

        }

        
        
    }
}