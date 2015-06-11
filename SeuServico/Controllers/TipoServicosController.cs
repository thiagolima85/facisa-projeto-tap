using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeuServico.Models;

namespace SeuServico.Controllers
{
    public class TipoServicosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: TipoServicos
        public ActionResult Index()
        {
            return View(db.TipoServicos.ToList());
        }

        // GET: TipoServicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tipoServico = db.TipoServicos.Find(id);
            if (tipoServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoServico);
        }

        // GET: TipoServicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo")] TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                db.TipoServicos.Add(tipoServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoServico);
        }

        // GET: TipoServicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tipoServico = db.TipoServicos.Find(id);
            if (tipoServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoServico);
        }

        // POST: TipoServicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo")] TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoServico);
        }

        // GET: TipoServicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tipoServico = db.TipoServicos.Find(id);
            if (tipoServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoServico);
        }

        // POST: TipoServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServico tipoServico = db.TipoServicos.Find(id);
            db.TipoServicos.Remove(tipoServico);
            db.SaveChanges();
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
