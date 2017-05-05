using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Titulo : Conteudo
    {
        public int Importancia { get; set; }
        public string Texto { get; set; }
    }
}