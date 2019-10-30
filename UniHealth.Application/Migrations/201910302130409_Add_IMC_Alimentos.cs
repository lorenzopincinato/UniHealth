namespace UniHealth.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IMC_Alimentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IMCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Peso = c.Double(nullable: false),
                        Altura = c.Double(nullable: false),
                        DataCalculo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IMCs");
        }
    }
}
