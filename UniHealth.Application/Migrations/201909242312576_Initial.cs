namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        RG = c.String(),
                        Nome = c.String(),
                        Senha = c.String(),
                        Inclusao = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
