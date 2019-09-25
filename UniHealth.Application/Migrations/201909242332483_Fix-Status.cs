namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Usuarios", "StatusUsuarioId");
            AddForeignKey("dbo.Usuarios", "StatusUsuarioId", "dbo.StatusUsuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "StatusUsuarioId", "dbo.StatusUsuarios");
            DropIndex("dbo.Usuarios", new[] { "StatusUsuarioId" });
            DropTable("dbo.StatusUsuarios");
        }
    }
}
