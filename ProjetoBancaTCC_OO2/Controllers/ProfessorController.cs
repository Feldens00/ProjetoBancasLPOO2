using PeixeiraConnection;
using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class ProfessorController : Controller
    {
        Database database = new Database();
        ProfessorRepositorio profRep = new ProfessorRepositorio();

        // GET: Professor
        public ActionResult Professor()
        {
            var professor = profRep.getAll();

            return View(professor);
        }

        [HttpGet]
        public ActionResult CreateProfessor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfessor(Professor professor)
        {
            profRep.Create(professor);
            return RedirectToAction("Professor");
        }

        public ActionResult DeleteProfessor(int Id)
        {
            profRep.Delete(Id);
            return RedirectToAction("Professor");
        }

        public ActionResult UpdateProfessor(int Id)
        {
            var professor = profRep.getOne(Id);
            return View(professor);
            
        }

        [HttpPost]
        public ActionResult UpdateProfessor(Professor professor)
        {
            profRep.Update(professor);
            return RedirectToAction("Professor");
        }
    }
}