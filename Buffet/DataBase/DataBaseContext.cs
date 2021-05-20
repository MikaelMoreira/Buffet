using System;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Local;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;
using Buffet.Models.Buffet.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Buffet.DataBase
{
    public class DataBaseContext : IdentityDbContext<Usuario,Papel, Guid>
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<ConvidadoEntity> Convidados { get; set; }
        public DbSet<LocalEntity> Locais { get; set; }
        public DbSet<SituacaoConvidadoEntity> SituacaoConvidado { get; set; }
        public DbSet<SituacaoEventoEntity> SituacaoEvento { get; set; }
        public DbSet<TipoClienteEntity> TipoCliente { get; set; }
        public DbSet<TipoEventoEntity> TipoEvento { get; set; }
        
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
                :base(options)
        {
            
        }
    }
}