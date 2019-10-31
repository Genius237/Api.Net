using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using WebApplication1.Controllers;

namespace WebApplication1
{
    [TestClass]
    public class TestSimpleEleveController
    {
        [TestMethod]
        public void GetAllEleves_ShouldReturnAllEleves()
        {
            var testEleves = GetTestEleves();
            var controller = new SimpleEleveController(testEleves);

            var result = controller.GetAllEleves() as List<Eleve>;
            Assert.AreEqual(testEleves.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllProductsAsync_ShouldReturnAllEleves()
        {
            var testEleves = GetTestEleves();
            var controller = new SimpleEleveController(testEleves);

            var result = await controller.GetAllElevesAsync() as List<Eleve>;
            Assert.AreEqual(testEleves.Count, result.Count);
        }

        [TestMethod]
        public void GetEleve_ShouldReturnCorrectEleve()
        {
            var testEleves = GetTestEleves();
            var controller = new SimpleEleveController(testEleves);

            var result = controller.GetEleve(3) as OkNegotiatedContentResult<Eleve>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testEleves[2].Nom, result.Content.Nom);
        }

        [TestMethod]
        public async Task GetEleveAsync_ShouldReturnCorrectEleve()
        {
            var testEleves = GetTestEleves();
            var controller = new SimpleEleveController(testEleves);

            var result = await controller.GetEleveAsync(3) as OkNegotiatedContentResult<Eleve>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testEleves[2].Nom, result.Content.Nom);
        }

        [TestMethod]
        public void GetEleve_ShouldNotFindEleve()
        {
            var controller = new SimpleEleveController(GetTestEleves());

            var result = controller.GetEleve(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Eleve> GetTestEleves()
        {
            var testEleves = new List<Eleve>();
            /*testEleves.Add(new Eleve { Id=1, Nom = "BIRAM", Prenom = "Steeve Ursil", Age="26", Matricule="2546GERT44", Classe="2nd" });
            testEleves.Add(new Eleve { Id=2, Nom = "POUTONG", Prenom = "Thierry", Age = "26", Matricule = "278EYTUO94", Classe = "2nd" });
            testEleves.Add(new Eleve { Id=3, Nom = "KENTSA", Prenom = "Arthur", Age = "26", Matricule = "874FGKUR78", Classe = "2nd" });*/

            return testEleves;
        }
    }
}
