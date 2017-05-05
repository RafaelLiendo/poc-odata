namespace PocInheritance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alternativas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.Int(nullable: false),
                        EnqueteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conteudos", t => t.EnqueteId, cascadeDelete: false)
                .Index(t => t.EnqueteId);
            
            CreateTable(
                "dbo.Conteudos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ordem = c.Int(nullable: false),
                        ArtigoId = c.Int(),
                        Descricao = c.String(),
                        UploadId = c.Int(),
                        GaleriaId = c.Int(),
                        Url = c.String(),
                        Texto = c.String(),
                        Importancia = c.Int(),
                        Texto1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artigos", t => t.ArtigoId)
                .ForeignKey("dbo.Conteudos", t => t.GaleriaId)
                .ForeignKey("dbo.Uploads", t => t.UploadId, cascadeDelete: false)
                .Index(t => t.ArtigoId)
                .Index(t => t.UploadId)
                .Index(t => t.GaleriaId);
            
            CreateTable(
                "dbo.Artigos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Layout = c.Boolean(nullable: false),
                        Titulo = c.String(),
                        Thumbnail = c.Binary(),
                        ResponsavelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.ResponsavelId)
                .Index(t => t.ResponsavelId);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Blob = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descrição = c.String(),
                        Editoria = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Curtidas",
                c => new
                    {
                        ArtigoIdId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtigoIdId, t.UsuarioId })
                .ForeignKey("dbo.Artigos", t => t.ArtigoIdId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.ArtigoIdId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ArtigosTags",
                c => new
                    {
                        ArtigoIdId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtigoIdId, t.TagId })
                .ForeignKey("dbo.Artigos", t => t.ArtigoIdId, cascadeDelete: false)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
                .Index(t => t.ArtigoIdId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Respostas",
                c => new
                    {
                        AlternativaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlternativaId, t.UsuarioId })
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.AlternativaId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Respostas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Respostas", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.Alternativas", "EnqueteId", "dbo.Conteudos");
            DropForeignKey("dbo.ArtigosTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ArtigosTags", "ArtigoIdId", "dbo.Artigos");
            DropForeignKey("dbo.Curtidas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Curtidas", "ArtigoIdId", "dbo.Artigos");
            DropForeignKey("dbo.Artigos", "ResponsavelId", "dbo.Usuarios");
            DropForeignKey("dbo.Conteudos", "UploadId", "dbo.Uploads");
            DropForeignKey("dbo.Conteudos", "GaleriaId", "dbo.Conteudos");
            DropForeignKey("dbo.Conteudos", "ArtigoId", "dbo.Artigos");
            DropIndex("dbo.Respostas", new[] { "UsuarioId" });
            DropIndex("dbo.Respostas", new[] { "AlternativaId" });
            DropIndex("dbo.ArtigosTags", new[] { "TagId" });
            DropIndex("dbo.ArtigosTags", new[] { "ArtigoIdId" });
            DropIndex("dbo.Curtidas", new[] { "UsuarioId" });
            DropIndex("dbo.Curtidas", new[] { "ArtigoIdId" });
            DropIndex("dbo.Artigos", new[] { "ResponsavelId" });
            DropIndex("dbo.Conteudos", new[] { "GaleriaId" });
            DropIndex("dbo.Conteudos", new[] { "UploadId" });
            DropIndex("dbo.Conteudos", new[] { "ArtigoId" });
            DropIndex("dbo.Alternativas", new[] { "EnqueteId" });
            DropTable("dbo.Respostas");
            DropTable("dbo.ArtigosTags");
            DropTable("dbo.Curtidas");
            DropTable("dbo.Tags");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Uploads");
            DropTable("dbo.Artigos");
            DropTable("dbo.Conteudos");
            DropTable("dbo.Alternativas");
        }
    }
}
