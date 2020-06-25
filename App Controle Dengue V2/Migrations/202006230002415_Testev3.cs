namespace App_Controle_Dengue_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testev3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Focos",
                c => new
                    {
                        FocoId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Endereco = c.String(),
                        Descricao = c.String(),
                        Doentes = c.String(),
                    })
                .PrimaryKey(t => t.FocoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Focos");
        }
    }
}
