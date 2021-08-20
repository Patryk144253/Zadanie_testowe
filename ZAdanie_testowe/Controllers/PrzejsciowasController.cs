using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZAdanie_testowe.Data;
using ZAdanie_testowe.Models;

namespace ZAdanie_testowe.Controllers
{
    public class PrzejsciowasController : Controller
    {
        private AplicationDbContext db = new AplicationDbContext();

        // GET: Przejsciowas
        public async Task<ActionResult> Index()
        {
            var przejsciowa = db.Przejsciowa.Include(p => p.Gosc).Include(p => p.Rezerwacja);
            return View(await przejsciowa.ToListAsync());
        }

        // GET: Przejsciowas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przejsciowa przejsciowa = await db.Przejsciowa.FindAsync(id);
            if (przejsciowa == null)
            {
                return HttpNotFound();
            }
            return View(przejsciowa);
        }

        // GET: Przejsciowas/Create
        public ActionResult Create()
        {
            ViewBag.GoscId = new SelectList(db.Gosc, "ID", "Imie");
            ViewBag.RezerwacjaId = new SelectList(db.Rezerwacja, "ID", "Kod_rezerwacji");
            return View();
        }

        // POST: Przejsciowas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RezerwacjaId,GoscId")] Przejsciowa przejsciowa)
        {
            if (ModelState.IsValid)
            {
                db.Przejsciowa.Add(przejsciowa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GoscId = new SelectList(db.Gosc, "ID", "Imie", przejsciowa.GoscId);
            ViewBag.RezerwacjaId = new SelectList(db.Rezerwacja, "ID", "Kod_rezerwacji", przejsciowa.RezerwacjaId);
            return View(przejsciowa);
        }

        // GET: Przejsciowas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przejsciowa przejsciowa = await db.Przejsciowa.FindAsync(id);
            if (przejsciowa == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoscId = new SelectList(db.Gosc, "ID", "Imie", przejsciowa.GoscId);
            ViewBag.RezerwacjaId = new SelectList(db.Rezerwacja, "ID", "Kod_rezerwacji", przejsciowa.RezerwacjaId);
            return View(przejsciowa);
        }

        // POST: Przejsciowas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RezerwacjaId,GoscId")] Przejsciowa przejsciowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przejsciowa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GoscId = new SelectList(db.Gosc, "ID", "Imie", przejsciowa.GoscId);
            ViewBag.RezerwacjaId = new SelectList(db.Rezerwacja, "ID", "Kod_rezerwacji", przejsciowa.RezerwacjaId);
            return View(przejsciowa);
        }

        // GET: Przejsciowas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przejsciowa przejsciowa = await db.Przejsciowa.FindAsync(id);
            if (przejsciowa == null)
            {
                return HttpNotFound();
            }
            return View(przejsciowa);
        }

        // POST: Przejsciowas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Przejsciowa przejsciowa = await db.Przejsciowa.FindAsync(id);
            db.Przejsciowa.Remove(przejsciowa);
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
