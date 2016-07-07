namespace HolterMobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_APARELHO",
                c => new
                    {
                        id_aparelho = c.Int(nullable: false, identity: true),
                        modelo = c.String(),
                    })
                .PrimaryKey(t => t.id_aparelho);
            
            CreateTable(
                "dbo.TB_ENDERECO",
                c => new
                    {
                        id_endereco = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        fl_principal = c.Boolean(nullable: false),
                        cep = c.String(),
                        complemento = c.String(),
                        numero = c.String(),
                    })
                .PrimaryKey(t => t.id_endereco)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario);
            
            CreateTable(
                "dbo.TB_USUARIO",
                c => new
                    {
                        id_usuario = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        sobrenome = c.String(),
                        idade = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_usuario);
            
            CreateTable(
                "dbo.TB_LOG_ACESSO",
                c => new
                    {
                        id_log = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        id_perfil = c.Int(nullable: false),
                        horario = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_log)
                .ForeignKey("dbo.TB_PERFIL", t => t.id_perfil, cascadeDelete: true)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario)
                .Index(t => t.id_perfil);
            
            CreateTable(
                "dbo.TB_PERFIL",
                c => new
                    {
                        id_perfil = c.Int(nullable: false, identity: true),
                        ds_perfil = c.String(),
                    })
                .PrimaryKey(t => t.id_perfil);
            
            CreateTable(
                "dbo.TB_LOGIN",
                c => new
                    {
                        id_login = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        id_perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_login)
                .ForeignKey("dbo.TB_PERFIL", t => t.id_perfil, cascadeDelete: true)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario)
                .Index(t => t.id_perfil);
            
            CreateTable(
                "dbo.TB_MONITORAMENTO",
                c => new
                    {
                        id_monitoramento = c.Int(nullable: false, identity: true),
                        id_paciente = c.Int(nullable: false),
                        id_aparelho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_monitoramento)
                .ForeignKey("dbo.TB_APARELHO", t => t.id_aparelho, cascadeDelete: true)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_paciente, cascadeDelete: true)
                .Index(t => t.id_paciente)
                .Index(t => t.id_aparelho);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_MONITORAMENTO", "id_paciente", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_MONITORAMENTO", "id_aparelho", "dbo.TB_APARELHO");
            DropForeignKey("dbo.TB_LOGIN", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_LOGIN", "id_perfil", "dbo.TB_PERFIL");
            DropForeignKey("dbo.TB_LOG_ACESSO", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_LOG_ACESSO", "id_perfil", "dbo.TB_PERFIL");
            DropForeignKey("dbo.TB_ENDERECO", "id_usuario", "dbo.TB_USUARIO");
            DropIndex("dbo.TB_MONITORAMENTO", new[] { "id_aparelho" });
            DropIndex("dbo.TB_MONITORAMENTO", new[] { "id_paciente" });
            DropIndex("dbo.TB_LOGIN", new[] { "id_perfil" });
            DropIndex("dbo.TB_LOGIN", new[] { "id_usuario" });
            DropIndex("dbo.TB_LOG_ACESSO", new[] { "id_perfil" });
            DropIndex("dbo.TB_LOG_ACESSO", new[] { "id_usuario" });
            DropIndex("dbo.TB_ENDERECO", new[] { "id_usuario" });
            DropTable("dbo.TB_MONITORAMENTO");
            DropTable("dbo.TB_LOGIN");
            DropTable("dbo.TB_PERFIL");
            DropTable("dbo.TB_LOG_ACESSO");
            DropTable("dbo.TB_USUARIO");
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_APARELHO");
        }
    }
}
