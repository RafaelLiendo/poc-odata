using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    [Table("Artigos")]
    public class Artigo
    {
        public int Id { get; set; }       
        public bool Layout { get; set; }        
        public string Titulo { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? ResponsavelId { get; set; }
        [ForeignKey("ResponsavelId")]
        public Usuario Responsavel { get; set; }
        public ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();
        public ICollection<Usuario> CurtidoPorUsuarios { get; set; } = new List<Usuario>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}