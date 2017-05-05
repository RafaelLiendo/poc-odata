using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        public int Descricao { get; set; }
        public ICollection<Usuario> RespondidoPorUsuarios { get; set; } = new List<Usuario>();

        //Remover
        public int EnqueteId { get; set; }
        [ForeignKey("EnqueteId")]
        public Enquete Enquete { get; set; }
    }
}