using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : ApiController
    {
        static readonly IEleveRepository repository = new EleveRepository();
        public IEnumerable<Eleve> GetAllEleves()
        {
            return repository.GetAll();
        }

        public Eleve GetEleve(int id)
        {
            Eleve item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public Eleve PostEleve(Eleve item)
        {
            item = repository.Add(item);
            return item;
        }

        public void PutEleve(int id, Eleve eleve)
        {
            eleve.Id = id;
            if (!repository.Update(eleve))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteEleve(int id)
        {
            Eleve item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
