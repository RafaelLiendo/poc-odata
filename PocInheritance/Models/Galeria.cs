using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Galeria : Midia
    {
        public ICollection<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}