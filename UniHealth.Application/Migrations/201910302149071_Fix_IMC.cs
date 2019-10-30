namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_IMC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IMCs", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.IMCs", "UsuarioId");
            AddForeignKey("dbo.IMCs", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IMCs", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.IMCs", new[] { "UsuarioId" });
            DropColumn("dbo.IMCs", "UsuarioId");
        }
    }
}
