namespace App_Controle_Dengue_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testev2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Idade", c => c.String());
            AlterColumn("dbo.Usuarios", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Telefone", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "Idade", c => c.Int(nullable: false));
        }
    }
}
