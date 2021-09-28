using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBBABA.Infra.EF;

namespace WEBBABA.Controllers
{
    public class CategoriasController : Controller
    {
        private solnascenteEntities db = new solnascenteEntities();

        // GET: Categorias
        public async Task<ActionResult> Index()
        {
            return View(await db.TBCategorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategoria tBCategoria = await db.TBCategorias.FindAsync(id);
            if (tBCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tBCategoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nomeCategoria,dataCadastroCategoria")] TBCategoria tBCategoria)
        {
            if (ModelState.IsValid)
            {
                tBCategoria.dataCadastroCategoria = DateTime.Now;
                db.TBCategorias.Add(tBCategoria);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBCategoria);
        }

        // GET: Categorias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategoria tBCategoria = await db.TBCategorias.FindAsync(id);
            if (tBCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tBCategoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCategoria,nomeCategoria,dataCadastroCategoria")] TBCategoria tBCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBCategoria).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBCategoria);
        }

        // GET: Categorias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategoria tBCategoria = await db.TBCategorias.FindAsync(id);
            if (tBCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tBCategoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBCategoria tBCategoria = await db.TBCategorias.FindAsync(id);
            db.TBCategorias.Remove(tBCategoria);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
