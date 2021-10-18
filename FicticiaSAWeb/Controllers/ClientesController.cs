using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FicticiaSAWeb.Models;

namespace FicticiaSAWeb.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private FicticiaSADatabaseEntities1 db = new FicticiaSADatabaseEntities1();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Generos);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.idGenero = new SelectList(db.Generos, "idGenero", "genero");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,nombreCompleto,identificacion,edad,idGenero,estado,maneja,lentes,otraEnfermedad,descripcionOtraEnfermedad")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGenero = new SelectList(db.Generos, "idGenero", "genero", clientes.idGenero);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGenero = new SelectList(db.Generos, "idGenero", "genero", clientes.idGenero);
            return View(clientes);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,nombreCompleto,identificacion,edad,idGenero,estado,maneja,lentes,otraEnfermedad,descripcionOtraEnfermedad")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGenero = new SelectList(db.Generos, "idGenero", "genero", clientes.idGenero);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
