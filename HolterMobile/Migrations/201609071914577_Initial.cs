namespace HolterMobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.TB_ATIVIDADES",
                c => new
                    {
                        id_atividade = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.id_atividade);
            
            CreateTable(
                "dbo.TB_CHAT",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        id_usuario_emissor = c.Int(nullable: false),
                        id_usuario_receptor = c.Int(nullable: false),
                        horario = c.DateTime(nullable: false),
                        mensagem = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
                        sexo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        dt_nasc = c.DateTime(nullable: false),
                        bpm_min = c.Int(nullable: false),
                        bpm_max = c.Int(nullable: false),
                        altura = c.Double(nullable: false),
                        peso = c.Double(nullable: false),
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
                        ds_username = c.String(),
                        ds_senha = c.String(),
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
                        bpm = c.Int(nullable: false),
                        horario = c.DateTime(nullable: false),
                        ds_atividade = c.String(),
                        latitude = c.String(),
                        longitude = c.String(),
                    })
                .PrimaryKey(t => t.id_monitoramento)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_paciente, cascadeDelete: true)
                .Index(t => t.id_paciente);
            
            CreateTable(
                "dbo.TB_PACIENTE_MEDICO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_paciente = c.Int(nullable: false),
                        id_medico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TB_RESPONSAVEIS",
                c => new
                    {
                        id_responsavel = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        nome = c.String(),
                        tel_responsavel = c.String(),
                    })
                .PrimaryKey(t => t.id_responsavel)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario);
            
            CreateTable(
                "dbo.TB_TEMP_PRESS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        horario = c.DateTime(nullable: false),
                        temperatura = c.Double(nullable: false),
                        pressao = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TB_USUARIO", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_TEMP_PRESS", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_RESPONSAVEIS", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_MONITORAMENTO", "id_paciente", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_LOGIN", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_LOGIN", "id_perfil", "dbo.TB_PERFIL");
            DropForeignKey("dbo.TB_LOG_ACESSO", "id_usuario", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_LOG_ACESSO", "id_perfil", "dbo.TB_PERFIL");
            DropForeignKey("dbo.TB_ENDERECO", "id_usuario", "dbo.TB_USUARIO");
            DropIndex("dbo.TB_TEMP_PRESS", new[] { "id_usuario" });
            DropIndex("dbo.TB_RESPONSAVEIS", new[] { "id_usuario" });
            DropIndex("dbo.TB_MONITORAMENTO", new[] { "id_paciente" });
            DropIndex("dbo.TB_LOGIN", new[] { "id_perfil" });
            DropIndex("dbo.TB_LOGIN", new[] { "id_usuario" });
            DropIndex("dbo.TB_LOG_ACESSO", new[] { "id_perfil" });
            DropIndex("dbo.TB_LOG_ACESSO", new[] { "id_usuario" });
            DropIndex("dbo.TB_ENDERECO", new[] { "id_usuario" });
            DropTable("dbo.TB_TEMP_PRESS");
            DropTable("dbo.TB_RESPONSAVEIS");
            DropTable("dbo.TB_PACIENTE_MEDICO");
            DropTable("dbo.TB_MONITORAMENTO");
            DropTable("dbo.TB_LOGIN");
            DropTable("dbo.TB_PERFIL");
            DropTable("dbo.TB_LOG_ACESSO");
            DropTable("dbo.TB_USUARIO");
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_CHAT");
            DropTable("dbo.TB_ATIVIDADES");
            DropTable("dbo.TB_APARELHO");
        }
    }
}
