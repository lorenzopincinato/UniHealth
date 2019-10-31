namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Alimento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CaloriaUnidade = c.Double(nullable: false),
                        Unidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alimentoes");
        }
    }
}
