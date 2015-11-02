using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProsjektOppgave1.Models;
using System.Data.Entity.Validation;
using System.Web.Security;
using ProsjektOppgave1.BLL;


namespace ProsjektOppgave1.Controllers
{
    public class VareController : Controller
    {        
        public ActionResult VareListe()
        {
            var VareDb = new VareBLL();
            List<Vare> hentAlleVarer = VareDb.HentAlleVarer();
            return View(hentAlleVarer);   
        }

        public ActionResult VareDetaljer(int id)
        {
            var VareDb = new VareBLL();
            Vare enVare = VareDb.hentEnVare(id);
            return View(enVare);
        }

        public ActionResult RegistrerVare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerVare(Vare innVare)
        {
            if(ModelState.IsValid)
            {
                var vare = new VareBLL();
                bool insertOK = vare.leggTilVare(innVare);
                if(insertOK)
                {
                    return RedirectToAction("VareListe");
                }
            }
            return View();
        }

        public ActionResult EndreVare(int id)
        {
            var vareDb = new VareBLL();
            Vare enVare = vareDb.hentEnVare(id);
            return View(enVare);
        }

        [HttpPost]
        public ActionResult endreVare(int id, Vare endreVare)
        {
            if(ModelState.IsValid)
            {
                var Vare = new VareBLL();
                bool endringOk = Vare.endreVare(id, endreVare);
                if(endringOk)
                {
                    return RedirectToAction("VareListe");
                }
            }
            return View();
        }

        public ActionResult slettVare(int id)
        {
            var vareDb = new VareBLL();
            Vare enVare = vareDb.hentEnVare(id);
            return View(enVare);
        }

        [HttpPost]
        public ActionResult slettVare(int id, Vare slettVare)
        {
            var VareDb = new VareBLL();
            bool slettOk = VareDb.slettVare(id);
            if(slettOk)
            {
                return RedirectToAction("VareListe");
            }
            return View();
        }

        


    }
}