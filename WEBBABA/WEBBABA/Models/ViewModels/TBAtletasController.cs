using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WEBBABA.Infra.EF;
using System.Collections.Generic;
using System.Linq;

namespace WEBBABA.Models.ViewModels
{
    public class TBAtletasController : Controller
    {
        private solnascenteEntities db = new solnascenteEntities();
        private IQueryable<AtletaModel> atleta = new IQueryable<AtletaModel>();
        // GET: TBAtletas
        public async Task<ActionResult> Index()
        {
            atleta = db.TBAtleta.Include(t => t.TBSituacao);
            return View(await atletas.ToListAsync());
        }

        // GET: TBAtletas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBAtleta tBAtleta = await db.TBAtletas.FindAsync(id);
            if (tBAtleta == null)
            {
                return HttpNotFound();
            }
            return View(tBAtleta);
        }

        // GET: TBAtletas/Create
        public ActionResult Create()
        {
            ViewBag.idSituacaoAtleta = new SelectList(db.TBSituacaos, "idSituacao", "nomeSituacao");
            return View();
        }

        // POST: TBAtletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idAtleta,nomeAtleta,sobrenomeAtleta,apelidoAtleta,coleteNumeroAtleta,nascimentoAtleta,idSituacaoAtleta,telefoneAtleta,dataCadastroAtleta,posicaoAtleta,comissaoAtleta")] TBAtleta tBAtleta)
        {
            if (ModelState.IsValid)
            {
                db.TBAtletas.Add(tBAtleta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idSituacaoAtleta = new SelectList(db.TBSituacaos, "idSituacao", "nomeSituacao", tBAtleta.idSituacaoAtleta);
            return View(tBAtleta);
        }

        // GET: TBAtletas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBAtleta tBAtleta = await db.TBAtletas.FindAsync(id);
            if (tBAtleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSituacaoAtleta = new SelectList(db.TBSituacaos, "idSituacao", "nomeSituacao", tBAtleta.idSituacaoAtleta);
            return View(tBAtleta);
        }

        // POST: TBAtletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idAtleta,nomeAtleta,sobrenomeAtleta,apelidoAtleta,coleteNumeroAtleta,nascimentoAtleta,idSituacaoAtleta,telefoneAtleta,dataCadastroAtleta,posicaoAtleta,comissaoAtleta")] TBAtleta tBAtleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBAtleta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idSituacaoAtleta = new SelectList(db.TBSituacaos, "idSituacao", "nomeSituacao", tBAtleta.idSituacaoAtleta);
            return View(tBAtleta);
        }

        // GET: TBAtletas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBAtleta tBAtleta = await db.TBAtletas.FindAsync(id);
            if (tBAtleta == null)
            {
                return HttpNotFound();
            }
            return View(tBAtleta);
        }

        // POST: TBAtletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBAtleta tBAtleta = await db.TBAtletas.FindAsync(id);
            db.TBAtletas.Remove(tBAtleta);
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
