using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        //Remover
        public ICollection<Alternativa> AlternativasRespondidas { get; set; } = new List<Alternativa>();
        public ICollection<Artigo> ArtigosCurtidos { get; set; } = new List<Artigo>();
        public ICollection<Artigo> Artigos { get; set; } = new List<Artigo>();
    }
}