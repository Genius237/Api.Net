using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ElevesController : ApiController
    {
        private TestEntities1 db = new TestEntities1();

        // GET: api/Eleves
        public IQueryable<Eleve> GetEleves()
        {
            return db.Eleves;
        }

        // GET: api/Eleves/5
        [ResponseType(typeof(Eleve))]
        public async Task<IHttpActionResult> GetEleve(int id)
        {
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            return Ok(eleve);
        }

        // PUT: api/Eleves/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEleve(int id, Eleve eleve)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eleve.Id)
            {
                return BadRequest();
            }

            db.Entry(eleve).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Eleves
        [ResponseType(typeof(Eleve))]
        public async Task<IHttpActionResult> PostEleve(Eleve eleve)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Eleves.Add(eleve);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EleveExists(eleve.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eleve.Id }, eleve);
        }

        // DELETE: api/Eleves/5
        [ResponseType(typeof(Eleve))]
        public async Task<IHttpActionResult> DeleteEleve(int id)
        {
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            db.Eleves.Remove(eleve);
            await db.SaveChangesAsync();

            return Ok(eleve);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EleveExists(int id)
        {
            return db.Eleves.Count(e => e.Id == id) > 0;
        }
    }
}