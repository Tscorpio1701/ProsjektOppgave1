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
using BLL;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ProsjektOppgave1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminListe()
        {
            var AdminDb = new AdminBLL();
            List<Admin> hentAdmins = AdminDb.HentAlleAdmins();
            return View(hentAdmins);
        }

        public ActionResult AdminDetaljer(int id)
        {
            var AdminDb = new AdminBLL();
            var enAdmin = AdminDb.hentEnAdmin(id);
            return View(enAdmin);
        }

        public ActionResult LeggTilAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LeggTilAdmin(Admin innAdmin)
        {
            if(ModelState.IsValid)
            {
                var Admin = new AdminBLL();
                bool insertOk = Admin.leggTilAdmin(innAdmin);
                if(insertOk)
                {
                    giveRole(innAdmin);
                    return RedirectToAction("AdminListe");
                }
            }
            return View();
        }

        public void giveRole(Admin innAdmin)
        {
            Roles.AddUserToRole(innAdmin.Brukernavn, "Admin");
        }

        public ActionResult EndreAdmin(int id)
        {
            var AdminDb = new AdminBLL();
            Admin enAdmin = AdminDb.hentEnAdmin(id);
            return View(enAdmin);
        }

        [HttpPost]
        public ActionResult EndreAdmin(int id, Admin endreAdmin)
        {
            if(ModelState.IsValid)
            {
                var Admin = new AdminBLL();
                bool endringOk = Admin.endreAdmin(id, endreAdmin);
                if(endringOk)
                {
                    return RedirectToAction("AdminListe");
                }
            }
            return View();
        }

        public ActionResult SlettAdmin(int id)
        {
            var AdminDB = new AdminBLL();
            Admin enAdmin = AdminDB.hentEnAdmin(id);
            return View(enAdmin);
        }

        [HttpPost]
        public ActionResult SlettAdmin(int id, Admin slettId)
        {
            if(ModelState.IsValid)
            {
                var Admin = new AdminBLL();
                bool slettOk = Admin.slettAdmin(id);
                if(slettOk)
                {
                    return RedirectToAction("AdminListe");
                }
            }
            return View();
        }
    }
}