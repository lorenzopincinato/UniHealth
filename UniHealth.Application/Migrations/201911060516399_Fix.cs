namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlimentoConsumidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Refeicao = c.String(),
                        AlimentoId = c.Int(nullable: false),
                        UnidadesConsumidas = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimentoes", t => t.AlimentoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.AlimentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlimentoConsumidoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.AlimentoConsumidoes", "AlimentoId", "dbo.Alimentoes");
            DropIndex("dbo.AlimentoConsumidoes", new[] { "AlimentoId" });
            DropIndex("dbo.AlimentoConsumidoes", new[] { "UsuarioId" });
            DropTable("dbo.AlimentoConsumidoes");
        }
    }
}
