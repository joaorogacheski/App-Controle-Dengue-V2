using App_Controle_Dengue_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static Usuario BuscarUsuarioporCPF(Usuario u)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Cpf.Equals(u.Cpf));
        }


        public static Usuario BuscarUsuarioporNome(string txtNomeUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.NomeUsuario.Equals(txtNomeUsuario));
        }


        public static Usuario BuscarUsuarioporId(int? id)
        {
            return ctx.Usuarios.Find(id);
        }


        public static Usuario Login(string txtNomeUsuario, string txtSenha)
        {

            return ctx.Usuarios.FirstOrDefault(x => x.NomeUsuario.Equals(txtNomeUsuario) && x.Senha.Equals(txtSenha));

        }


        public static bool CadastrarUsuario(Usuario u)
        {
            if (BuscarUsuarioporCPF(u) == null)
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Usuario> RetornarUsuario()
        {
            return ctx.Usuarios.ToList();
        }

        public static void RemoverUsuario(Usuario u)
        {
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
        }

        public static void AlterarUsuario(Usuario u)
        {
            ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}