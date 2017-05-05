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
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using PocInheritance.Models;

namespace PocInheritance.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using PocInheritance.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Artigo>("Artigos");
    builder.EntitySet<Conteudo>("Conteudos"); 
    builder.EntitySet<Usuario>("Usuarios"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ArtigosController : ODataController
    {
        private Contexto db = new Contexto();

        // GET: odata/Artigos
        [EnableQuery]
        public IQueryable<Artigo> GetArtigos()
        {
            return db.Artigos;
        }

        // GET: odata/Artigos(5)
        [EnableQuery]
        public SingleResult<Artigo> GetArtigo([FromODataUri] int key)
        {
            return SingleResult.Create(db.Artigos.Where(artigo => artigo.Id == key));
        }

        // PUT: odata/Artigos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Artigo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artigo artigo = await db.Artigos.FindAsync(key);
            if (artigo == null)
            {
                return NotFound();
            }

            patch.Put(artigo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(artigo);
        }

        // POST: odata/Artigos
        public async Task<IHttpActionResult> Post(Artigo artigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artigos.Add(artigo);
            await db.SaveChangesAsync();

            return Created(artigo);
        }

        // PATCH: odata/Artigos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Artigo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artigo artigo = await db.Artigos.FindAsync(key);
            if (artigo == null)
            {
                return NotFound();
            }

            patch.Patch(artigo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(artigo);
        }

        // DELETE: odata/Artigos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Artigo artigo = await db.Artigos.FindAsync(key);
            if (artigo == null)
            {
                return NotFound();
            }

            db.Artigos.Remove(artigo);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Artigos(5)/Conteudos
        [EnableQuery]
        public IQueryable<Conteudo> GetConteudos([FromODataUri] int key)
        {
            return db.Artigos.Where(m => m.Id == key).SelectMany(m => m.Conteudos);
        }

        // GET: odata/Artigos(5)/Likes
        [EnableQuery]
        public IQueryable<Usuario> GetLikes([FromODataUri] int key)
        {
            return db.Artigos.Where(m => m.Id == key).SelectMany(m => m.CurtidoPorUsuarios);
        }

        // GET: odata/Artigos(5)/Responsavel
        [EnableQuery]
        public SingleResult<Usuario> GetResponsavel([FromODataUri] int key)
        {
            return SingleResult.Create(db.Artigos.Where(m => m.Id == key).Select(m => m.Responsavel));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtigoExists(int key)
        {
            return db.Artigos.Count(e => e.Id == key) > 0;
        }
    }
}
