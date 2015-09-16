using PeixeiraConnection;
using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class DisciplinaController : Controller
    {
        Database database = new Database();
        DisciplinaRepositorio discRep = new DisciplinaRepositorio();

        // GET: Disciplina
        public ActionResult Disciplina()
        {
            var disciplina = discRep.getAll();
            return View(disciplina);
        }

        public ActionResult CreateDisciplina()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDisciplina(Disciplina disciplina)
        {
            discRep.Create(disciplina);
            return RedirectToAction("Disciplina");
        }

        public ActionResult DeleteDisciplina(int Id)
        {
            discRep.Delete(Id);
            return RedirectToAction("Disciplina");
        }

        public ActionResult UpdateDisciplina(int Id)
        {
            var disciplina = discRep.getOne(Id);
            return View(disciplina);
        }

        [HttpPost]
        public ActionResult UpdateDisciplina(Disciplina disciplina)
        {
            discRep.Update(disciplina);
            return RedirectToAction("Disciplina");
        }
    }
}