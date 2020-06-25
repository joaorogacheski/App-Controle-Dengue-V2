using App_Controle_Dengue_V2.DAL;
using App_Controle_Dengue_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Controle_Dengue_V2.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult CadastrarUsuario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(string txtNomeUsuario, string txtSenha, string txtCPF, string txtTelefone, string txtIdade, DateTime txtDataNascimento )
        {
            Usuario u = new Usuario
            {
                NomeUsuario = txtNomeUsuario,
                Senha = txtSenha,
                Cpf = txtCPF,
                Telefone = txtTelefone,
                Idade = txtIdade,
                DataNascimento = txtDataNascimento
            };


            if (UsuarioDAO.BuscarUsuarioporNome(txtNomeUsuario) == null && UsuarioDAO.BuscarUsuarioporCPF(u) == null)
            {
                UsuarioDAO.CadastrarUsuario(u);


                return RedirectToAction("DenunciarFoco", "Denuncia");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AlterarUsuario(int? id)
        {

            ViewBag.Usuario = UsuarioDAO.BuscarUsuarioporId(id);
            return View();
        }


        [HttpPost]
        public ActionResult AlterarUsuario(int txtId, string txtNomeUsuario, string txtCPF, string txtSenha, DateTime txtDataNascimento)
        {
            Usuario u = UsuarioDAO.BuscarUsuarioporId(txtId);
            u.NomeUsuario = txtNomeUsuario;
            u.Cpf = txtCPF;
            u.Senha = txtSenha;
            u.DataNascimento = txtDataNascimento;

            UsuarioDAO.AlterarUsuario(u);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoverUsuario(int? id)
        {
            UsuarioDAO.RemoverUsuario(UsuarioDAO.BuscarUsuarioporId(id));
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ListarUsuario(int? id)
        {

            ViewBag.Usuarios = UsuarioDAO.RetornarUsuario();
            return View();
        }



    }
}