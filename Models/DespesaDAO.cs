using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System_Cont.Database;
using System_Cont.Helpers;
using System_Cont.Views;

namespace System_Cont.Models
{
    internal class DespesaDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Despesa VALUES " +
                "(null, @nome, @descricao, @valor, @data_despesa);";

                comando.Parameters.AddWithValue("@nome", despesa.NomeDes);
                comando.Parameters.AddWithValue("@descricao", despesa.DescricaoDes);
                comando.Parameters.AddWithValue("@valor", despesa.ValorDes);
                comando.Parameters.AddWithValue("@data_despesa", despesa.Data_Despesa?.ToString("yyyy-MM-dd"));



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

        public List<Despesa> List()
        {
            try
            {
                var lista = new List<Despesa>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Despesa";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var despesa = new Despesa();

                    despesa.Id = reader.GetInt32("id_des");
                    despesa.NomeDes = DAOHelper.GetString(reader, "nome_des");
                    despesa.DescricaoDes = DAOHelper.GetString(reader, "descricao_des");
                    despesa.ValorDes = DAOHelper.GetDouble(reader, "valor_des");
                    despesa.Data_Despesa = DAOHelper.GetDateTime(reader, "data_despesa_des");

                    lista.Add(despesa);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double DespesaAlugue()
        {
            double total = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_des) from despesa where nome_des = 'Aluguel'";

                var recebimento = new Recebimento();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    total = DAOHelper.GetDouble(reader, "sum(valor_des)");

                }

                reader.Close();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double DespesaEnergia()
        {
            double total = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_des) from despesa where nome_des = 'Energia'";

                var recebimento = new Recebimento();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    total = DAOHelper.GetDouble(reader, "sum(valor_des)");

                }

                reader.Close();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double DespesaAgua()
        {
            double total = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_des) from despesa where nome_des = 'Agua'";

                var recebimento = new Recebimento();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    total = DAOHelper.GetDouble(reader, "sum(valor_des)");

                }

                reader.Close();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double DespesaInternet()
        {
            double total = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_des) from despesa where nome_des = 'Internet'";

                var recebimento = new Recebimento();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    total = DAOHelper.GetDouble(reader, "sum(valor_des)");

                }

                reader.Close();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double SomaDespesa()
        {
            double totalDespesa = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_des) from Despesa";

                var despesa = new Despesa();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    totalDespesa = DAOHelper.GetDouble(reader, "sum(valor_des)");

                }

                reader.Close();
                return totalDespesa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Despesa t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Despesa where id_des = @id";

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
