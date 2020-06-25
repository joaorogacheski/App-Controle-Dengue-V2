namespace App_Controle_Dengue_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesteV4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Focos", "Bairro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Focos", "Bairro");
        }
    }
}
