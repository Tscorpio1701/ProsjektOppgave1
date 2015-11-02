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
using System.Collections.Generic;

namespace ProsjektOppgave1.Controllers
{
    public class BestillingController : Controller
    {
        // GET: Bestilling
        public ActionResult BestillingListe()
        {
            var bestillingDb = new BestillingBLL();
            List<Bestilling> alleBestillinger = bestillingDb.hentAlleBestillinger();
            return View(alleBestillinger);
        }

        public ActionResult BestillingDetaljer(int id)
        {
            var bestillingDb = new BestillingBLL();
            Bestilling enBestilling = bestillingDb.hentEnBestilling(id);
            return View(enBestilling);
        }

        public ActionResult RegistrerBestilling()
        {
            return View();
        }

        public ActionResult RegistrerBestilling(Bestilling innBestilling)
        {
            if(ModelState.IsValid)
            {
                var bestilling = new BestillingBLL();
                bool insertOk = bestilling.leggTilBestilling(innBestilling);
                if(insertOk)
                {
                    return RedirectToAction("BestillingListe");
                }
            }
            return View();
        }

        [HttpPost]

        public ActionResult endreBestilling(int id)
        {
            var bestillingDb = new BestillingBLL();
            Bestilling enBestilling = bestillingDb.hentEnBestilling(id);
            return View(enBestilling);
        }

        public ActionResult endreBestilling(int id, Bestilling endreBestilling)
        {
            if(ModelState.IsValid)
            {
                var bestilling = new BestillingBLL();
                bool endringOk = bestilling.endreBestilling(id, endreBestilling);
                if(endringOk)
                {
                    return RedirectToAction("BestillingListe");
                }
            }
            return View();
        }

        public ActionResult slettBestilling(int id)
        {
            var bestillingDb = new BestillingBLL();
            Bestilling enBestilling = bestillingDb.hentEnBestilling(id);
            return View(enBestilling);
        }

        [HttpPost]
        public ActionResult slettBestilling(int id, Bestilling slettBestilling)
        {
            var bestillingDb = new BestillingBLL();
            bool slettOk = bestillingDb.slettBestilling(id);
            if(slettOk)
            {
                return RedirectToAction("BestillingListe");
            }
            return View();
        }
    }
}