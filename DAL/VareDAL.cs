using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.DAL
{
    public class VareDAL
    {
        public List<Vare> HentAlleVarer()
        {
            var db = new ButikkContext();
            List<Vare> alleVarer = db.Varer.ToList();
            return alleVarer;

        }

        public bool leggTilVare(Vare innVare)
        {
            using (var context = new ButikkContext())
            {
                var vare = new Vare()
                {
                    Varenavn = innVare.Varenavn,
                    Pris = innVare.Pris,
                    Varebeholdning = innVare.Varebeholdning,
                };
                context.Varer.Add(vare);
                var saved = context.SaveChanges();
                return saved >= 1;
            }
        }

        public bool endreVare(int id, Vare vare)
        {
            var db = new ButikkContext();

            try
            {
                Vare endreVare = db.Varer.Find(id);
                endreVare.Varenavn = vare.Varenavn;
                endreVare.Pris = vare.Pris;
                endreVare.Varebeholdning = vare.Varebeholdning;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool slettVare(int slettId)
        {
            var db = new ButikkContext();
            try
            {
                Vare vare = db.Varer.Find(slettId);
                db.Varer.Remove(vare);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }


        public Vare hentEnVare(int id)
        {
            var db = new ButikkContext();

            var enDbVare = db.Varer.Find(id);

            if (enDbVare == null)
            {
                return null;
            }
            else
            {
                var utVare = new Vare()
                {
                    Varenavn = enDbVare.Varenavn,
                    Pris = enDbVare.Pris,
                    Varebeholdning = enDbVare.Varebeholdning,

                };
                return utVare;
            }
        }
    }
}
