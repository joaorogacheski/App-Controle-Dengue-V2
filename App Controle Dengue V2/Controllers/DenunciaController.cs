using App_Controle_Dengue_V2.DAL;
using App_Controle_Dengue_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Controle_Dengue_V2.Controllers
{
    public class DenunciaController : Controller
    {


        // GET: Denuncia
        public ActionResult Index()
        {
            return View(DenunciaDAO.RetornarListaFocos());
        }

        public ActionResult DenunciarFoco()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DenunciarFoco(string txtEndereco, string txtBairro, string txtDescricao, string txtDoentes)
        {
            FocoDengue f = new FocoDengue
            {
                Usuario = "Anonimo",
                Endereco = txtEndereco,
                Bairro = txtBairro,
                Descricao = txtDescricao,
                Doentes = txtDoentes
            };


            if (DenunciaDAO.DenunciarFoco(f))
            {
                return RedirectToAction("Index", "Denuncia");
            }

            //if (DenunciaDAO.BuscarUsuarioporNome(txtNomeUsuario) == null && UsuarioDAO.BuscarUsuarioporCPF(u) == null)
            //{
            //   DenunciaDAO.DenunciarFoco(f);


            //return RedirectToAction("Index", "Home");
            //}
            else
            {
                return View();
            }
        }

        public ActionResult RemoverFoco(int? id)
        {
            DenunciaDAO.RemoverFoco(DenunciaDAO.BuscarFocoporId(id));
            return RedirectToAction("Index", "Denuncia");
        }
        public void GetQtd(List<FocoDengue> f)
        { 
        
            ViewBag.ddlTeste = f.Count;

        }
    }
}