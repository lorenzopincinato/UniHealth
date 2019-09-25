namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerfilUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "StatusUsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "PerfilUsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "PerfilUsuarioId");
            AddForeignKey("dbo.Usuarios", "PerfilUsuarioId", "dbo.PerfilUsuarios", "Id", cascadeDelete: true);
            DropColumn("dbo.Usuarios", "Status");
            DropColumn("dbo.Usuarios", "Perfil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Perfil", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Usuarios", "PerfilUsuarioId", "dbo.PerfilUsuarios");
            DropIndex("dbo.Usuarios", new[] { "PerfilUsuarioId" });
            DropColumn("dbo.Usuarios", "PerfilUsuarioId");
            DropColumn("dbo.Usuarios", "StatusUsuarioId");
            DropTable("dbo.PerfilUsuarios");
        }
    }
}
