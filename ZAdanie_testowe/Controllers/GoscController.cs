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
using System.Data.SqlClient;
using System.Configuration;

namespace ZAdanie_testowe.Controllers
{
    public class GoscController : Controller
    {
        private AplicationDbContext db = new AplicationDbContext();

        // GET: Gosc
        public async Task<ActionResult> Index()
        {
            return View(await db.Gosc.ToListAsync());
        }

        public async Task<ActionResult> GetPiotr()
        {
            AplicationDbContext data = new AplicationDbContext();

            var gosc = from s in db.Gosc
                         select s;

           
                gosc = gosc.Where(s => s.Imie.Contains("Piotr") && s.Miasto == "Wrocław" || s.Imie.Contains("Piotr") && s.Miasto == null);
            

            return View(await gosc.ToListAsync());
        }

        // GET: Gosc/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gosc gosc = await db.Gosc.FindAsync(id);
            if (gosc == null)
            {
                return HttpNotFound();
            }
            return View(gosc);
        }

        // GET: Gosc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gosc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Imie,Nazwisko,Email,Data_urodzenia,Kod_Pocztowy,NrTel,Adres,Miasto")] Gosc gosc)
        {
            if (ModelState.IsValid)
            {
                db.Gosc.Add(gosc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gosc);
        }

        // GET: Gosc/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gosc gosc = await db.Gosc.FindAsync(id);
            if (gosc == null)
            {
                return HttpNotFound();
            }
            return View(gosc);
        }

        // POST: Gosc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Imie,Nazwisko,Email,Data_urodzenia,Kod_Pocztowy,NrTel,Adres,Miasto")] Gosc gosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gosc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gosc);
        }

        // GET: Gosc/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gosc gosc = await db.Gosc.FindAsync(id);
            if (gosc == null)
            {
                return HttpNotFound();
            }
            return View(gosc);
        }

        // POST: Gosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gosc gosc = await db.Gosc.FindAsync(id);
            db.Gosc.Remove(gosc);
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
