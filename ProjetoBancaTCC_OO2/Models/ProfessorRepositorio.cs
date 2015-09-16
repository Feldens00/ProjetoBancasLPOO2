using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class ProfessorRepositorio
    {
        Database conn = new Database();
        private List<Professor> professor = new List<Professor>();

        public IEnumerable<Professor> getAll()
        {
            //List<Professor> professor = new List<Professor>();

            string sql = "select * from professores";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                professor.Add(new Professor((int)dr["id"], (string)dr["nome"]));

            }
            return professor;
        }
        public void Create(Professor pProfessor)
        {
            //professor.Add(pProfessor);

            string sql = "insert into professores values(";
            sql += pProfessor.Id + ",'" + pProfessor.Nome + "')";
            conn.executarComando(sql);
        }

        // get one pesquisa so  uma tupla/ linha , get all pesquisa tds 
        public Professor getOne(int pId)
        {


            string sql = "select * from professores where id=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);


            dr.Read();
            Professor professorEditando = new Professor((int)dr["id"], (string)dr["nome"]);




            return professorEditando;
        }
        public void Update(Professor pProfessor)
        {
            // int aux = professor.FindIndex(x => x.Id == pProfessor.Id);
            //professor[aux] = pProfessor;

            string update = "Update professores set nome='" + pProfessor.Nome + "' where id=" + pProfessor.Id;
            conn.executarComando(update);


        }
        public void Delete(int pId)
        {

            //professor.RemoveAt(professor.FindIndex(x => x.Id == pId));
            string delete = "Delete from  professores where id=" + pId;
            conn.executarComando(delete);
        }
    }
}