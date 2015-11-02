using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.DAL;
using ProsjektOppgave1.Models;

namespace BLL
{
    public class AdminBLL
    {
        public List<Admin> HentAlleAdmins()
        {
            var AdminDAL = new AdminDAL();
            List<Admin> alleAdmin = AdminDAL.HentAdmins();
            return alleAdmin;
        }

        public bool leggTilAdmin(Admin innAdmin)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.leggTilAdmin(innAdmin);
        }

        public bool endreAdmin(int id, Admin admin)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.endreAdmin(id, admin);
        }

        public bool slettAdmin(int slettId)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.slettAdmin(slettId);
        }

        public Admin hentEnAdmin(int id)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.hentEnAdmin(id);
        }
    }
}
