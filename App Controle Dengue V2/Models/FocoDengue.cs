using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.Models
{

    [Table("Focos")]
    public class FocoDengue
    {
        [Key]
        public int FocoId { get; set; }
        public string Usuario { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public string Bairro { get; set; }
        public string Doentes { get; set; }

    }
}