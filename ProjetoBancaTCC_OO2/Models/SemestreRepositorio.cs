using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class SemestreRepositorio
    {
        Database conn = new Database();
        public List<Semestre> semestre = new List<Semestre>();

        public IEnumerable<Semestre> getAll()
        {
            //List<Semestre> semestre = new List<Semestre>();

            string sql = "select * from semestres";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                semestre.Add(new Semestre((int)dr["id"], (string)dr["nome"]));

            }
            return semestre;
        }

        public void Create(Semestre pSemestre)
        {
            //semestre.Add(pSemestre);
            string sql = "insert into semestres values(";
            sql += pSemestre.Id + ",'" + pSemestre.Nome + "')";
            conn.executarComando(sql);
        }

        // get one pesquisa so  uma tupla/ linha , get all pesquisa tds 

        public Semestre getOne(int pId)
        {


            string sql = "select * from semestres where id=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);


            dr.Read();
            Semestre semestreEditando = new Semestre((int)dr["id"], (string)dr["nome"]);




            return semestreEditando;
        }
        public void Update(Semestre pSemestre)
        {
            //int aux = semestre.FindIndex(x => x.Id == pSemestre.Id);
           // semestre[aux] = pSemestre;
            string update = "Update semestres set nome='" + pSemestre.Nome + "' where id=" + pSemestre.Id;
            conn.executarComando(update);

        }
        public void Delete(int pId)
        {
            
           // semestre.RemoveAt(semestre.FindIndex(x => x.Id == pId));
            string delete = "Delete from  semestres where id=" + pId;
            conn.executarComando(delete);
        }
    }
}