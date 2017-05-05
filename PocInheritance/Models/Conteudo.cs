using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    [Table("Conteudos")]
    public abstract class Conteudo
    {
        public int Id { get; set; }
        public int Ordem { get; set; }

        //Remover
        public int? ArtigoId { get; set; }
        [ForeignKey("ArtigoId")]
        public Artigo Artigo { get; set; }        
    }
}