using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.DAL
{
    public class BestillingDAL
    {
        public List<Bestilling> hentAlleBestillinger()
        {
            var db = new ButikkContext();
            List<Bestilling> alleBestillinger = db.Bestillinger.ToList();
            return alleBestillinger;
        }

        public bool leggTilBestilling(Bestilling innBestilling)
        {
            using (var context = new ButikkContext())
            {
                var bestilling = new Bestilling()
                {
                    OrdreDato = innBestilling.OrdreDato,
                    Total = innBestilling.Total,
                    Varer = innBestilling.Varer
                };
                context.Bestillinger.Add(bestilling);
                var saved = context.SaveChanges();
                return saved >= 1;
            }
        }

        public bool endreBestilling(int id, Bestilling bestilling)
        {
            var db = new ButikkContext();

            try
            {
                Bestilling endreBestilling = db.Bestillinger.Find(id);
                endreBestilling.OrdreDato = bestilling.OrdreDato;
                endreBestilling.Total = bestilling.Total;
                endreBestilling.Varer = bestilling.Varer;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool slettBestilling(int slettID)
        {
            var db = new ButikkContext();

            try
            {
                Bestilling bestilling = db.Bestillinger.Find(slettID);
                db.Bestillinger.Remove(bestilling);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Bestilling hentEnBestilling(int id)
        {
            var db = new ButikkContext();
            var enDbBestilling = db.Bestillinger.Find(id);
            
            if(enDbBestilling == null)
            {
                return null;
            }
            else
            {
                var utBestilling = new Bestilling()
                {
                    OrdreDato = enDbBestilling.OrdreDato,
                    Total = enDbBestilling.Total,
                    Varer = enDbBestilling.Varer
                };
                return utBestilling;
            }

        }
       
    }
}
