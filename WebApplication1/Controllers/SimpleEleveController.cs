using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SimpleEleveController : ApiController
    {
        List<Eleve> eleves = new List<Eleve>();

        public SimpleEleveController() { }

        public SimpleEleveController(List<Eleve> eleves)
        {
            this.eleves = eleves;
        }

        public IEnumerable<Eleve> GetAllEleves()
        {
            return eleves;
        }

        public async Task<IEnumerable<Eleve>> GetAllElevesAsync()
        {
            return await Task.FromResult(GetAllEleves());
        }

        public IHttpActionResult GetEleve(int id)
        {
            var eleve = eleves.FirstOrDefault((p) => p.Id == id);
            if (eleve == null)
            {
                return NotFound();
            }
            return Ok(eleve);
        }

        public async Task<IHttpActionResult> GetEleveAsync(int id)
        {
            return await Task.FromResult(GetEleve(id));
        }
    }
}
