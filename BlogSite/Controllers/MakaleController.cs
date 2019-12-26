using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class MakaleController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        // GET: Makale
        public async Task<ActionResult> Index()
        {
            var makales = db.Makales.Include(m => m.Kategori).Include(m => m.Yazar);
            return View(await makales.ToListAsync());
        }

        // GET: Makale/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = await db.Makales.FindAsync(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Makale/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategorilers, "Id", "Adi");
            ViewBag.YazarId = new SelectList(db.Yazarlars, "Id", "Adi");
            return View();
        }

        // POST: Makale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Baslik,Icerik,EklenmeTarihi,YazarId,KategoriId")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makales.Add(makale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategorilers, "Id", "Adi", makale.KategoriId);
            ViewBag.YazarId = new SelectList(db.Yazarlars, "Id", "Adi", makale.YazarId);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = await db.Makales.FindAsync(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategorilers, "Id", "Adi", makale.KategoriId);
            ViewBag.YazarId = new SelectList(db.Yazarlars, "Id", "Adi", makale.YazarId);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Baslik,Icerik,EklenmeTarihi,YazarId,KategoriId")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategorilers, "Id", "Adi", makale.KategoriId);
            ViewBag.YazarId = new SelectList(db.Yazarlars, "Id", "Adi", makale.YazarId);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = await db.Makales.FindAsync(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Makale makale = await db.Makales.FindAsync(id);
            db.Makales.Remove(makale);
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
