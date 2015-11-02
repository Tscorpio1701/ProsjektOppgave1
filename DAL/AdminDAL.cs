using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProsjektOppgave1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace ProsjektOppgave1.DAL
{
    public class AdminDAL
    {
        public List<Admin> HentAdmins()
        {
            var db = new ButikkContext();
            List<Admin> alleAdmin = db.Admins.ToList();
            return alleAdmin;

        }

        public bool leggTilAdmin(Admin innAdmin)
        {
            using (var context = new ButikkContext())
            {
                var admin = new Admin()
                {
                    Brukernavn = innAdmin.Brukernavn,
                    Passord = innAdmin.Passord
                };
                context.Admins.Add(admin);
                var saved = context.SaveChanges();
                return saved >= 1;
            }
        }

        public bool endreAdmin(int id, Admin admin)
        {
            var db = new ButikkContext();
            try
            {
                Admin endreAdmin = db.Admins.Find(id);
                endreAdmin.Brukernavn = admin.Brukernavn;
                endreAdmin.Passord = admin.Passord;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool slettAdmin(int slettId)
        {
            var db = new ButikkContext();
            try
            {
                Admin admin = db.Admins.Find(slettId);
                db.Admins.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Admin hentEnAdmin(int id)
        {
            var db = new ButikkContext();
            var enAdmin = db.Admins.Find(id);
            if(enAdmin == null)
            {
                return null;
            }
            else
            {
                var utAdmin = new Admin()
                {
                    Brukernavn = enAdmin.Brukernavn,
                    Passord = enAdmin.Passord
                };
                return utAdmin;
            }
        }        
    }
}
