using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbControleDengue") { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<FocoDengue> FocoDengues { get; set; }
    }
}