using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.DAL;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.DAL
{
    public class KundeRepositoryStub : DAL.IKundeRepository
    {
        public bool endreKunde(int id, KundeBLL innKunde)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<KundeBLL> hentAlle()
        {
            var kundeListe = new List<KundeBLL>();
            var kunde = new KundeBLL()
            {
                ID = 1,
                Fornavn = "Per",
                Etternavn = "Olsen",
                Adresse = "Osloveien 82",
                Passord = "1234"
            };
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            return kundeListe;
        }

        public KundeBLL hentEnKunde(int id)
        {
            if (id == 0)
            {
                var kunde = new KundeBLL();
                kunde.ID = 0;
                return kunde;
            }
            else
            {
                var kunde = new KundeBLL()
                {
                    ID = 1,
                    Fornavn = "Per",
                    Etternavn = "Olsen",
                    Adresse = "Osloveien 82",
                    Passord = "1234"
                };
                return kunde;
            }
        }

        public bool settInn(KundeBLL innKunde)
        {
            if (innKunde.Fornavn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool slettKunde(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
