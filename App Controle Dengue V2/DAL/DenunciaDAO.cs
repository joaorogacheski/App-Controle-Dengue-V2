using App_Controle_Dengue_V2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace App_Controle_Dengue_V2.DAL
{
    public class DenunciaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static FocoDengue BuscarFocoDengueporID(FocoDengue f)
        {
            return ctx.FocoDengues.FirstOrDefault(x => x.FocoId.Equals(f.FocoId));
        }



        public static FocoDengue BuscarFocoporId(int? id)
        {
            return ctx.FocoDengues.Find(id);
        }




        public static bool DenunciarFoco(FocoDengue f)
        {
            if (BuscarFocoDengueporID(f) == null)
            {
                ctx.FocoDengues.Add(f);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<FocoDengue> RetornarListaFocos()
        {
            return ctx.FocoDengues.ToList();
        }

        public static void RemoverFoco(FocoDengue f)
        {
            ctx.FocoDengues.Remove(f);
            ctx.SaveChanges();
        }

        public static void AlterarFoco(FocoDengue f)
        {
            ctx.Entry(f).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static bool getQtd(List<FocoDengue> f)
        {
            int count = 5;
            if (f.Count >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}