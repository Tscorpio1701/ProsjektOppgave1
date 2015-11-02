using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.Models;

namespace ProsjektOppgave1.DAL
{
    public interface IKundeRepository
    {
        bool endreKunde(int id, KundeBLL innKunde);
        List<KundeBLL> hentAlle();
        KundeBLL hentEnKunde(int id);
        bool settInn(KundeBLL innKunde);
        bool slettKunde(int id);
    }
}
