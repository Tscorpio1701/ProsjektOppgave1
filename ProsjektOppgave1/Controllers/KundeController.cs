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
    public class KundeController : Controller
    {
        private BLL.KundeBLL kundeBLL;

        public KundeController(BLL.KundeBLL kundeBLL)
        {
            this.kundeBLL = kundeBLL;
        }

        public ActionResult kundeListe()
        {
            var kundeDb = new BLL.KundeBLL();
            List<Models.KundeBLL> alleKunder = kundeDb.hentAlle();
            return View(alleKunder);
        }

        public ActionResult kundeDetaljer(int id = 0)
        {
            var kundeDb = new BLL.KundeBLL();
            Models.KundeBLL enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrer(Models.KundeBLL innKunde)
        {
            if (ModelState.IsValid)
            {
                var kundeDb = new BLL.KundeBLL();
                bool insertOK = kundeDb.leggTilKunde(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("kundeListe");
                }
            }
            return View();
        }

        public ActionResult Endre(int id)
        {
            var kundeDb = new BLL.KundeBLL();
            Models.KundeBLL enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Endre(int id, Models.KundeBLL endreKunde)
        {
            if (ModelState.IsValid)
            {
                var kundeDb = new BLL.KundeBLL();
                bool endringOK = kundeDb.endreKunde(id, endreKunde);
                if (endringOK)
                {
                    return RedirectToAction("kundeListe");
                }
            }
            return View();
        }

        public ActionResult slettKunde(int id)
        {
            var kundeDb = new BLL.KundeBLL();
            Models.KundeBLL enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult slettKunde(int id, Models.KundeBLL slettKunde)
        {
            var kundeDb = new BLL.KundeBLL();
            bool slettOK = kundeDb.slettKunde(id);
            if (slettOK)
            {
                return RedirectToAction("kundeListe");
            }
            return View();
        }





        //View for Hjemmeside
        public ActionResult Home()
        {
            /*if (Session["Innlogget"] == null)
            {
                Session["Innlogget"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["Innlogget"];
            }*/
            return View();
        }

        

   /*     public ActionResult visBestilling()
        {
            if (Session["Innlogget"] == null)
            {
                Session["Innlogget"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["Innlogget"];
                bool innlogget = (bool)Session["Innlogget"];
                if (innlogget) return View(db.Kunder.ToList());
            }


            return RedirectToAction("Home");
        }

        // View klasse som skal vise bestillings info
        public ActionResult visBestilling(int id = 0)
        {

            dbKunde kunde = db.Kunder.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }
*/        

        // Klasse for håndtering av innlogging
        /*public ActionResult LoggInn()
        {
            if (Session["Innlogget"] == null)
            {
                Session["Innlogget"] = false;
                ViewBag.InnLogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["Innlogget"];
            }

            return View();
        }*/


        // Klasse som forsikrer at session er gyldig for den kunden som er logget inn
        /*[HttpPost]
        public ActionResult LoggInn(Kunde innBruker)
        {
            if (Bruker_i_DB(innBruker))
            {
                Session["Innlogget"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                Session["Innlogget"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }*/

        // Utloggings klasse
        /*public ActionResult UtLogg(Kunde kunde)
        {
            bool innlogget = (bool)Session["Innlogget"];
            if(innlogget)
            {
                Session["Innlogget"] = false;
                ViewBag.Innlogget = false;
            }
            return RedirectToAction("LoggInn");
        }*/




      /*  private bool Bruker_i_DB(Kunde innBruker)
        {
                byte[] passordDb = lagHash(innBruker.Passord);
                dbKunde funnetBruker = db.Kunder.FirstOrDefault
                (b => b.Passord == passordDb && b.Fornavn == innBruker.Fornavn);
                if (funnetBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
        }
*/
    
    }
}

