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
    public class IndividusController : ApiController
    {
        private TestEntities1 db = new TestEntities1();

        // GET: api/Individus
        public IQueryable<Individu> GetIndividus()
        {
            return db.Individus;
        }

        // GET: api/Individus/5
        [ResponseType(typeof(Individu))]
        public async Task<IHttpActionResult> GetIndividu(int id)
        {
            Individu individu = await db.Individus.FindAsync(id);
            if (individu == null)
            {
                return NotFound();
            }

            return Ok(individu);
        }

        // PUT: api/Individus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIndividu(int id, Individu individu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != individu.Id)
            {
                return BadRequest();
            }

            db.Entry(individu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividuExists(id))
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

        // POST: api/Individus
        [ResponseType(typeof(Individu))]
        public async Task<IHttpActionResult> PostIndividu(Individu individu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Individus.Add(individu);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndividuExists(individu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = individu.Id }, individu);
        }

        // DELETE: api/Individus/5
        [ResponseType(typeof(Individu))]
        public async Task<IHttpActionResult> DeleteIndividu(int id)
        {
            Individu individu = await db.Individus.FindAsync(id);
            if (individu == null)
            {
                return NotFound();
            }

            db.Individus.Remove(individu);
            await db.SaveChangesAsync();

            return Ok(individu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndividuExists(int id)
        {
            return db.Individus.Count(e => e.Id == id) > 0;
        }
    }
}