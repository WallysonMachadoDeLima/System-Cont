﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Cont.Database;
using MySql.Data.MySqlClient;
using System_Cont.Helpers;
using System.IO;

namespace System_Cont.Models
{
    internal class FuncionarioDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirFuncionario " +
                "(@nome_funcionario, @email, @senha, @cpf, @rg, @numeroInscricao);";

                comando.Parameters.AddWithValue("@nome_funcionario", funcionario.NomeFuncionario);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@senha", funcionario.Senha);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@numeroInscricao", funcionario.Numero_Inscricao);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
                else
                {
                    string saida = Directory.GetCurrentDirectory();
                    saida = saida.Substring(0, saida.Length - 9) + @"Funcionarios\";
                    Directory.CreateDirectory(saida + funcionario.NomeFuncionario);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Funcionario> List()
        {
            try
            {
                var lista = new List<Funcionario>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Funcionario";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();

                    funcionario.Id = reader.GetInt32("id_fun");
                    funcionario.NomeFuncionario = DAOHelper.GetString(reader, "nome_fun");
                    funcionario.Email = DAOHelper.GetString(reader, "email_fun");
                    funcionario.Rg = DAOHelper.GetString(reader, "rg_fun");
                    funcionario.Cpf = DAOHelper.GetString(reader, "cpf_fun");
                    funcionario.Numero_Inscricao = DAOHelper.GetString(reader, "numero_inscricao_fun");
                    funcionario.Senha = DAOHelper.GetString(reader, "senha_fun");


                    lista.Add(funcionario);

                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Login(string nome, string senha)
        {
            string confirmacao = "No";
            string nomeAdv = null;
            int idAdv = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select id_fun, nome_fun from Funcionario where nome_fun = '"+nome+"' and senha_fun = '"+senha+"'";

                var funcionario = new Funcionario();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    nomeAdv = DAOHelper.GetString(reader, "nome_fun");
                    idAdv = DAOHelper.GetInt(reader, "id_fun");
                }
                reader.Close();
                if (nome == nomeAdv)
                {
                    var dao2 = new CaixaDAO();

                    confirmacao = "Yes";
                    VrsGlobais.nomeLogado = nomeAdv;
                    VrsGlobais.idFuncionario = idAdv;
                    dao2.Insert(dao2.SaldoAtual(), idAdv);
                }
                return confirmacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] InfoUsuario()
        {
            string[] infoFuncionario = new string[99];
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select * from Funcionario where id_fun = "+VrsGlobais.idFuncionario+"";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    infoFuncionario[0] = Convert.ToString(DAOHelper.GetInt(reader, "id_fun"));
                    infoFuncionario[1] = DAOHelper.GetString(reader, "nome_fun");
                    infoFuncionario[2] = DAOHelper.GetString(reader, "email_fun");
                    infoFuncionario[3] = DAOHelper.GetString(reader, "senha_fun");
                    infoFuncionario[4] = DAOHelper.GetString(reader, "cpf_fun");
                    infoFuncionario[5] = DAOHelper.GetString(reader, "rg_fun");
                    infoFuncionario[6] = DAOHelper.GetString(reader, "numero_inscricao_fun");
                }

                reader.Close();
                return infoFuncionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
