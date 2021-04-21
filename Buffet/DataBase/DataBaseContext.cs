using System;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet.Cliente;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Buffet.DataBase
{
    public class DataBaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
                :base(options)
        {
            
        }
    }
}