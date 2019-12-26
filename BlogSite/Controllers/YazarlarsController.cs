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
    public class YazarlarsController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        // GET: Yazarlars
        public async Task<ActionResult> Index()
        {
            return View(await db.Yazarlars.ToListAsync());
        }

        // GET: Yazarlars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazarlar yazarlar = await db.Yazarlars.FindAsync(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // GET: Yazarlars/Create
        public ActionResult Create()
        {
            var yazarlar = new Yazarlar();
            return View(yazarlar);
        }

        // POST: Yazarlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Adi,Soyad")] Yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                db.Yazarlars.Add(yazarlar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(yazarlar);
        }

        // GET: Yazarlars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazarlar yazarlar = await db.Yazarlars.FindAsync(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: Yazarlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Adi,Soyad")] Yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yazarlar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(yazarlar);
        }

        // GET: Yazarlars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazarlar yazarlar = await db.Yazarlars.FindAsync(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: Yazarlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Yazarlar yazarlar = await db.Yazarlars.FindAsync(id);
            db.Yazarlars.Remove(yazarlar);
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
