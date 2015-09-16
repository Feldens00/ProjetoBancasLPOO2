using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class AlunoRepositorio
    {
        Database conn = new Database();
        private List<Aluno> aluno = new List<Aluno>();

        public IEnumerable<Aluno> getAll()
        {
            //List<Aluno> aluno = new List<Aluno>();

            string sql = "select * from alunos";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                aluno.Add(new Aluno((int)dr["id"], (string)dr["nome"]));

            }
            return aluno;
        }

        public void Create(Aluno pAluno)
        {
            string sql = "insert into alunos values(";
            sql += pAluno.Id + ",'" + pAluno.Nome + "')";
            conn.executarComando(sql);
        }

        // get one pesquisa so  uma tupla/ linha , get all pesquisa tds 

        public Aluno getOne(int pId)
        {
           
            
            string sql = "select * from alunos where id="+pId;
            MySqlDataReader dr = conn.executarConsulta(sql);


            dr.Read();
            Aluno alunoEditando = new Aluno((int)dr["id"], (string)dr["nome"]);

                

            
            return alunoEditando;
        }
        public void Update(Aluno pAluno)
        {
            /*int aux = aluno.FindIndex(x => x.Id == pAluno.Id);
            aluno[aux] = pAluno;*/
            string update = "Update alunos set nome='" + pAluno.Nome + "' where id=" + pAluno.Id;
            conn.executarComando(update);//pexeira


        }
        public void Delete(int pId)
        {
            string sql = "Delete from  alunos where id ="+pId;
            conn.executarComando(sql);

            //aluno.RemoveAt(aluno.FindIndex(x => x.Id == pId));
        }
    }
}