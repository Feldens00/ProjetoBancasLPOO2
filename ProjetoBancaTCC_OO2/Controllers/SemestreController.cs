using PeixeiraConnection;
using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class SemestreController : Controller
    {
        Database database = new Database();
        SemestreRepositorio semestreRep = new SemestreRepositorio();

        // GET: Semestre
        public ActionResult Semestre()
        {
            var semestre = semestreRep.getAll();

            return View(semestre);
        }

        public ActionResult CreateSemestre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSemestre(Semestre semestre)
        {
            semestreRep.Create(semestre);
            return RedirectToAction("Semestre");
        }

        public ActionResult DeleteSemestre(int Id)
        {
            semestreRep.Delete(Id);
            return RedirectToAction("Semestre");
        }

        public ActionResult UpdateSemestre(int Id)
        {
            //var semestre = SemestreRepositorio.semestre.Find(x => x.Id == Id);
            var semestre = semestreRep.getOne(Id);
            return View(semestre);
        }

        [HttpPost]
        public ActionResult UpdateSemestre(Semestre semestre)
        {
            semestreRep.Update(semestre);
            return RedirectToAction("Semestre");
        }
    }
}