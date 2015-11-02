using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsjektOppgave1.BLL;
using ProsjektOppgave1.DAL;
using ProsjektOppgave1.Models;
using ProsjektOppgave1.Controllers;
using System.Web.Mvc;

namespace EnhetsTest
{
    [TestClass]
    public class KundeControllerTest
    {
        [TestMethod]
        public void Liste()
        {
            // Arrange
            var controller = new KundeController(new ProsjektOppgave1.BLL.KundeBLL(new KundeRepositoryStub()));
            // uten test : var controller = new PersonController();
            var forventetResultat = new List<ProsjektOppgave1.Models.KundeBLL>();
            var kunde = new ProsjektOppgave1.Models.KundeBLL()
            {
                ID = 1,
                Fornavn = "Per",
                Etternavn = "Olsen",
                Adresse = "Osloveien 82",
                Passord = "1234",
            };
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);

            // Act
            var actionResult = (ViewResult)controller.Liste();
            var resultat = (List<ProsjektOppgave1.Models.KundeBLL>)actionResult.Model;
            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].ID, resultat[i].ID);
                Assert.AreEqual(forventetResultat[i].Fornavn, resultat[i].Fornavn);
                Assert.AreEqual(forventetResultat[i].Etternavn, resultat[i].Etternavn);
                Assert.AreEqual(forventetResultat[i].Adresse, resultat[i].Adresse);
                Assert.AreEqual(forventetResultat[i].Passord, resultat[i].Passord);
            }
            /*
            Det som kommer under er bare for å vise hva Assert.IsTrue kan gjøre (dvs alt!)
            string forventet1 = "Her er en mulighet";
            string forventet2 = "Her er en mulighet til";
            string virkelig = "Her er en mulighet";
            if (virkelig == forventet1 || virkelig==forventet2)
                test = true;
            else 
                test = false;
            Assert.IsTrue(test);
             
             */
        }
    }
}
