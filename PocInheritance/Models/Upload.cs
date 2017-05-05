using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Upload
    {
        public int Id { get; set; }
        public byte[] Blob { get; set; }

        //Remover
        public ICollection<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}