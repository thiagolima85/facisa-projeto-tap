﻿using System;
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
    public class ServicosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Servicos
        public ActionResult Index()
        {
            return View(db.Servicos.ToList());
        }

        // GET: Servicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Servico servico = db.Servicos.Include("Tipo").Where(n => n.Id == id).First();

            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: Servicos/Create
        public ActionResult Create()
        {
            ViewBag.tiposServicos = db.TipoServicos;

            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                servico.Tipo = db.TipoServicos.Find(servico.Tipo.Id);

                db.Servicos.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servico);
        }

        // GET: Servicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Custo")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // GET: Servicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servicos.Find(id);
            db.Servicos.Remove(servico);
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
