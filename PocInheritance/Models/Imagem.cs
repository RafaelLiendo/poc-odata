using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PocInheritance.Models
{
    public class Imagem : Midia
    {
        public string Descricao { get; set; }
        public int UploadId { get; set; }
        [ForeignKey("UploadId")]
        public Upload Upload { get; set; }

        //Remover        
        public int? GaleriaId { get; set; }
        [ForeignKey("GaleriaId")]
        public Galeria Galeria { get; set; }
    }
}