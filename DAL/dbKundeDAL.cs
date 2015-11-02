using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.DAL
{
    public class dbKundeDAL
    {
        [Key]
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public byte[] Passord { get; set; }

        public List<KundeBLL> hentAlle()
        {
            var db = new ButikkContext();
            List<KundeBLL> alleKunder = db.Kunde.Select(k => new KundeBLL()
            {
                Fornavn = k.Fornavn,
                Etternavn = k.Etternavn,
                Adresse = k.Adresse  
            }).ToList();
            //List<Kunde> alleKunder = db.Kunde.ToList();
            return alleKunder;
        }

        public bool leggTilKunde(KundeBLL innKunde)
        {
            using (var context = new ButikkContext())
            {
                var kunde = new dbKundeDAL()
                {
                    Fornavn = innKunde.Fornavn,
                    Etternavn = innKunde.Etternavn,
                    Adresse = innKunde.Adresse,
                    Passord = lagHash(innKunde.Passord)
                };
                context.Kunde.Add(kunde);
                var saved = context.SaveChanges();
                return saved >= 1;
            }
        }
        private static byte[] lagHash(string passord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(passord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public bool endreKunde(int id, KundeBLL kunde)
        {
            var db = new ButikkContext();
            try
            {
                dbKundeDAL endreKunde = db.Kunde.Find(id);
                endreKunde.Fornavn = kunde.Fornavn;
                endreKunde.Etternavn = kunde.Etternavn;
                endreKunde.Adresse = kunde.Adresse;
                endreKunde.Passord = lagHash(kunde.Passord);

                db.SaveChanges();
                return true;
            }       
            catch
            {
                return false;
            }
        }

        public bool slettKunde(int slettId)
        {
            var db = new ButikkContext();
            try
            {
                dbKundeDAL slettKunde = db.Kunde.Find(slettId);
                db.Kunde.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public KundeBLL hentEnKunde(int id)
        {
            var db = new ButikkContext();

            var enDbKunde = db.Kunde.Find(id);

            if (enDbKunde == null)
            {
                return null;
            }
            else
            {
                var utKunde = new KundeBLL()
                {
                    Fornavn = enDbKunde.Fornavn,
                    Etternavn = enDbKunde.Etternavn,
                    Adresse = enDbKunde.Adresse,
                    
                };
                return utKunde;
            }
        }
    }
}

