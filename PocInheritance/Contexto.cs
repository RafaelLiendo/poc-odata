using PocInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

public class Contexto : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public Contexto() : base("name=Contexto")
    {
        Database.Log = m => Debug.WriteLine(m);
    }

    public DbSet<Alternativa> Alternativas { get; set; }
    public DbSet<Artigo> Artigos { get; set; }    
    public DbSet<Conteudo> Conteudos { get; set; }
    public DbSet<Enquete> Enquetes { get; set; }
    public DbSet<Galeria> Galerias { get; set; }
    public DbSet<Imagem> Imagens { get; set; }
    public DbSet<Midia> Midias { get; set; }
    public DbSet<Paragrafo> Paragrafos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Titulo> Titulos { get; set; }
    public DbSet<Upload> Uploads { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Video> Videos { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Alternativa>()
                .HasMany(s => s.RespondidoPorUsuarios)
                .WithMany(c => c.AlternativasRespondidas)
                .Map(cs =>
                {
                    cs.MapLeftKey("AlternativaId");
                    cs.MapRightKey("UsuarioId");
                    cs.ToTable("Respostas");
                });

        modelBuilder.Entity<Artigo>()
                .HasMany(s => s.CurtidoPorUsuarios)
                .WithMany(c => c.ArtigosCurtidos)
                .Map(cs =>
                {
                    cs.MapLeftKey("ArtigoIdId");
                    cs.MapRightKey("UsuarioId");
                    cs.ToTable("Curtidas");
                });

        modelBuilder.Entity<Artigo>()
                .HasMany(s => s.Tags)
                .WithMany(c => c.Artigos)
                .Map(cs =>
                {
                    cs.MapLeftKey("ArtigoIdId");
                    cs.MapRightKey("TagId");
                    cs.ToTable("ArtigosTags");
                });
    }
}
