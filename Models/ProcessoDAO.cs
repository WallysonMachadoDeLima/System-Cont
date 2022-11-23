using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Cont.Database;
using MySql.Data.MySqlClient;
using System_Cont.Helpers;

namespace System_Cont.Models
{
    internal class ProcessoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Processo processo)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirProcesso " +
                "(@numeroProcesso, @tipo, @status, @responsavel, @cliente, @idCliente, @idFuncionario);";

                comando.Parameters.AddWithValue("@numeroProcesso", processo.NumeroProcesso);
                comando.Parameters.AddWithValue("@tipo", processo.Tipo);
                comando.Parameters.AddWithValue("@status", processo.Status);
                comando.Parameters.AddWithValue("@responsavel", processo.ResponsavelProcesso);
                comando.Parameters.AddWithValue("@cliente", processo.ClienteProcesso);
                comando.Parameters.AddWithValue("@idCliente", processo.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", processo.Funcionario.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Processo> List()
        {
            try
            {
                var lista = new List<Processo>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Processo";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var processo = new Processo();

                    processo.Id = reader.GetInt32("id_pro");
                    processo.NumeroProcesso = DAOHelper.GetString(reader, "numero_pro");
                    processo.Tipo = DAOHelper.GetString(reader, "tipo_pro");
                    processo.Status = DAOHelper.GetString(reader, "status_pro");
                    processo.ResponsavelProcesso = DAOHelper.GetString(reader, "responsavel_pro");
                    processo.ClienteProcesso = DAOHelper.GetString(reader, "cliente_pro");


                    lista.Add(processo);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Processo t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Processo where id_pro = @id";

                comando.Parameters.AddWithValue("@id", t.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                    throw new Exception("Registro não removido da base de dados." +
                        "Verifique e tente novamente");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
