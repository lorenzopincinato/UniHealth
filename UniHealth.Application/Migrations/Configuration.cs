namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniHealth.Application.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniHealth.Application.DbUniHealthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniHealth.Application.DbUniHealthContext context)
        {
            if (!context.PerfilUsuarios.Where(x => x.Tipo == "Comum").Any() && 
                !context.PerfilUsuarios.Where(x => x.Tipo == "Administrador").Any())
            {
                context.PerfilUsuarios.Add(new PerfilUsuario { Tipo = "Comum" });
                context.PerfilUsuarios.Add(new PerfilUsuario { Tipo = "Administrador" });
            }

            if (!context.StatusUsuarios.Where(x => x.Estado == "Normal").Any() &&
                !context.StatusUsuarios.Where(x => x.Estado == "Bloquado").Any() &&
                !context.StatusUsuarios.Where(x => x.Estado == "Excluido").Any())
            {
                context.StatusUsuarios.Add(new StatusUsuario { Estado = "Normal" });
                context.StatusUsuarios.Add(new StatusUsuario { Estado = "Bloqueado" });
                context.StatusUsuarios.Add(new StatusUsuario { Estado = "Excluido" });
            }
        }
    }
}
