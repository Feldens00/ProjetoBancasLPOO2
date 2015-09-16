using PeixeiraConnection;
using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class AlunoController : Controller
    {
        Database database = new Database();
        AlunoRepositorio alunoRep = new AlunoRepositorio();

        // GET: Aluno
        public ActionResult Aluno()
        {
            var aluno = alunoRep.getAll();

            return View(aluno);
        }
        [HttpGet]
        public ActionResult CreateAluno()
        {
           
            return View();
        }

       [HttpPost]
        public ActionResult CreateAluno(Aluno aluno)
        {
            alunoRep.Create(aluno);
            return RedirectToAction("Aluno");
        }

        public ActionResult Delete(int Id)
       {
           alunoRep.Delete(Id);
           return RedirectToAction("Aluno");
       }

       public ActionResult Update(int Id)
        {
            var aluno = alunoRep.getOne(Id);
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Update(Aluno aluno)
        {
            alunoRep.Update(aluno);
            return RedirectToAction("Aluno");
        }
    }
}