using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.DAL;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.BLL
{
    public class BestillingBLL
    {
        public List<Bestilling> hentAlleBestillinger()
        {
            var BestillingDAL = new BestillingDAL();
            List<Bestilling> allebestillinger = BestillingDAL.hentAlleBestillinger();
            return allebestillinger;
        }

        public bool leggTilBestilling(Bestilling innBestilling)
        {
            var BestillingDAL = new BestillingDAL();
            return BestillingDAL.leggTilBestilling(innBestilling);
        }

        public bool endreBestilling(int id, Bestilling innBestilling)
        {
            var BestillingDAL = new BestillingDAL();
            return BestillingDAL.endreBestilling(id, innBestilling);
        }

        public bool slettBestilling(int slettId)
        {
            var BestillingDAL = new BestillingDAL();
            return BestillingDAL.slettBestilling(slettId);
        }

        public Bestilling hentEnBestilling(int id)
        {
            var BestillingDAL = new BestillingDAL();
            return BestillingDAL.hentEnBestilling(id);
        }
    }
    
}
