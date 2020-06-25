namespace App_Controle_Dengue_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(),
                        Idade = c.Int(nullable: false),
                        Senha = c.String(),
                        Cpf = c.String(),
                        Telefone = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
