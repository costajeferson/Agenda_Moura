using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MOURA_AGENDA.Models;

namespace MOURA_AGENDA.Controllers
{
    public class AgendaController : Controller
    {
        private AGENDA_MOURAEntities db = new AGENDA_MOURAEntities();

        // GET: Agenda
        public ActionResult Index()
        {
            return View(db.AGENDA.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.AGENDA.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOME,SOBRENOME,TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL,CELULAR_RECADOS,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.AGENDA.Add(agendum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agendum);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.AGENDA.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // POST: Agenda/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOME,SOBRENOME,TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL,CELULAR_RECADOS,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendum);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.AGENDA.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendum agendum = db.AGENDA.Find(id);
            db.AGENDA.Remove(agendum);
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
