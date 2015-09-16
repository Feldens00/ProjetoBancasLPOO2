using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class DisciplinaRepositorio
    {
        Database conn = new Database();
        public List<Disciplina> disciplina = new List<Disciplina>();

        public IEnumerable<Disciplina> getAll()
        {
            //List<Disciplinas> disciplinas = new List<Disciplinas>();

            string sql = "select * from disciplinas";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                disciplina.Add(new Disciplina((int)dr["id"], (string)dr["nome"]));

            }
            return disciplina;
        }


        public void Create(Disciplina pDisciplina)
        {
            //disciplina.Add(pDisciplina);
            string sql = "insert into disciplinas values(";
            sql += pDisciplina.Id + ",'" + pDisciplina.Nome + "')";
            conn.executarComando(sql);
        }

        // get one pesquisa so  uma tupla/ linha , get all pesquisa tds 
        public Disciplina getOne(int pId)
        {


            string sql = "select * from disciplinas where id=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);


            dr.Read();
           Disciplina disciplinaEditando = new Disciplina((int)dr["id"], (string)dr["nome"]);




            return disciplinaEditando;
        }


       
        public void Update(Disciplina pDisciplina)
        {
            //int aux = disciplina.FindIndex(x => x.Id == pDisciplina.Id);
            //disciplina[aux] = pDisciplina;
            string update = "Update disciplinas set nome='" + pDisciplina.Nome + "' where id=" + pDisciplina.Id;
            conn.executarComando(update);

        }
        public void Delete(int pId)
        {
            //sciplina.RemoveAt(disciplina.FindIndex(x => x.Id == pId));
            string delete = "Delete from  disciplinas where id=" + pId;
            conn.executarComando(delete);
        }
    }
}