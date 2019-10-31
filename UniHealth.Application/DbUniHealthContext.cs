using System.Data.Entity;
using UniHealth.Application.Models;

namespace UniHealth.Application
{
    public class DbUniHealthContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<StatusUsuario> StatusUsuarios { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public virtual DbSet<IMC> IMCs { get; set; }
        public virtual DbSet<Alimento> Alimentos { get; set; }

        public DbUniHealthContext(string connectionString) : base(connectionString) { }

        public DbUniHealthContext() : base("name=UniHealthConnection") { }
    }
}
