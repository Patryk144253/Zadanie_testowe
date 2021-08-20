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
    public class RezerwacjaController : Controller
    {
        private AplicationDbContext db = new AplicationDbContext();

        // GET: Rezerwacja
        public async Task<ActionResult> Index()
        {
            return View(await db.Rezerwacja.ToListAsync());
        }

        // GET: Rezerwacja/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = await db.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezerwacja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Kod_rezerwacji,Data_utworzenia,Cena,Data_zameldowania,Data_wymeldowania,Waluta,Prowizja,Zrodlo")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Rezerwacja.Add(rezerwacja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacja/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = await db.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Kod_rezerwacji,Data_utworzenia,Cena,Data_zameldowania,Data_wymeldowania,Waluta,Prowizja,Zrodlo")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezerwacja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = await db.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rezerwacja rezerwacja = await db.Rezerwacja.FindAsync(id);
            db.Rezerwacja.Remove(rezerwacja);
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
