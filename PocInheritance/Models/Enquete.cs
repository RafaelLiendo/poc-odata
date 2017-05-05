using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Enquete : Conteudo
    {
        ICollection<Alternativa> Alternativas { get; set; } = new List<Alternativa>();
    }
}