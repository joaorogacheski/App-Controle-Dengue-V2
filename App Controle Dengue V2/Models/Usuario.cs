using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Idade { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}