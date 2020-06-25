using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.Models
{
    [Table("Email")]
    public class Email
    {
        

        [Key]
        public int EmailId { get; set; }

        [Required]
        [Display(Name = "Primeiro Nome")]

        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        
        public string EndEmail { get; set; }
    }
}