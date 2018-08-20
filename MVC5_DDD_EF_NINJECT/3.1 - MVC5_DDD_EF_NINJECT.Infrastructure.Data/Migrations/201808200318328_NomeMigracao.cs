namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModulosAcesso",
                c => new
                    {
                        IdModulo = c.Int(nullable: false, identity: true),
                        NomeModulo = c.String(nullable: false, maxLength: 200, unicode: false),
                        NomeMenuAcesso = c.String(nullable: false, maxLength: 200, unicode: false),
                        UrlMenu = c.String(nullable: false, maxLength: 300, unicode: false),
                        FlAtivo = c.Boolean(nullable: false),
                        IdModuloPai = c.Int(),
                        ModulosAcessos_IdModuloAcesso = c.Int(),
                    })
                .PrimaryKey(t => t.IdModulo)
                .ForeignKey("dbo.ModulosAcesso", t => t.ModulosAcessos_IdModuloAcesso)
                .Index(t => t.ModulosAcessos_IdModuloAcesso);
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        IdPerfilUsuario = c.Int(nullable: false, identity: true),
                        NomePerfil = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        FlAtivo = c.Boolean(nullable: false),
                        FlAdminMaster = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerfilUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        IdPerfilUsuario = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 2048, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.PerfilUsuario", t => t.IdPerfilUsuario)
                .Index(t => t.IdPerfilUsuario)
                .Index(t => t.Email, unique: true, name: "IX_LoginNameUser");
            
            CreateTable(
                "dbo.PerfilModulo",
                c => new
                    {
                        IdMdoulo = c.Int(nullable: false),
                        IdPerfilUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdMdoulo, t.IdPerfilUsuario })
                .ForeignKey("dbo.ModulosAcesso", t => t.IdMdoulo)
                .ForeignKey("dbo.PerfilUsuario", t => t.IdPerfilUsuario)
                .Index(t => t.IdMdoulo)
                .Index(t => t.IdPerfilUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerfilModulo", "IdPerfilUsuario", "dbo.PerfilUsuario");
            DropForeignKey("dbo.PerfilModulo", "IdMdoulo", "dbo.ModulosAcesso");
            DropForeignKey("dbo.Usuario", "IdPerfilUsuario", "dbo.PerfilUsuario");
            DropForeignKey("dbo.ModulosAcesso", "ModulosAcessos_IdModuloAcesso", "dbo.ModulosAcesso");
            DropIndex("dbo.PerfilModulo", new[] { "IdPerfilUsuario" });
            DropIndex("dbo.PerfilModulo", new[] { "IdMdoulo" });
            DropIndex("dbo.Usuario", "IX_LoginNameUser");
            DropIndex("dbo.Usuario", new[] { "IdPerfilUsuario" });
            DropIndex("dbo.ModulosAcesso", new[] { "ModulosAcessos_IdModuloAcesso" });
            DropTable("dbo.PerfilModulo");
            DropTable("dbo.Usuario");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.ModulosAcesso");
        }
    }
}
