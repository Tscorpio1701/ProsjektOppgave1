using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.DAL;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.BLL
{
    public class KundeBLL
    {
        private KundeRepositoryStub kundeRepositoryStub;

        public KundeBLL(KundeRepositoryStub kundeRepositoryStub)
        {
            this.kundeRepositoryStub = kundeRepositoryStub;
        }

        public List<Models.KundeBLL> hentAlle()
            {
                var KundeDAL = new dbKundeDAL();
            List<Models.KundeBLL> alleKunder = KundeDAL.hentAlle();
                return alleKunder;
            }
            public bool leggTilKunde(Models.KundeBLL innKunde)
            {
                var KundeDAL = new dbKundeDAL();
                return KundeDAL.leggTilKunde(innKunde);
            }
            public bool endreKunde(int id, Models.KundeBLL innKunde)
            {
                var KundeDAL = new dbKundeDAL();
                return KundeDAL.endreKunde(id, innKunde);
            }
            public bool slettKunde(int slettId)
            {
                var KundeDAL = new dbKundeDAL();
                return KundeDAL.slettKunde(slettId);
            }
            public KundeBLL hentEnKunde(int id)
            {
                var KundeDAL = new dbKundeDAL();
                return KundeDAL.hentEnKunde(id);
            }
        }

    }

