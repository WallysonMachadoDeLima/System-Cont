using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System_Cont.Database;
using System_Cont.Helpers;

namespace System_Cont.Models
{
    internal class HonorarioDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Honorario honorario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirHonorario " +
                "(@valor, @descricao, @data, @idProcesso);";

                comando.Parameters.AddWithValue("@valor", honorario.Valor);
                comando.Parameters.AddWithValue("@descricao", honorario.Descricao);
                comando.Parameters.AddWithValue("@data", honorario.DataHonorario?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@idProcesso", honorario.Processo.Id);

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

        public List<Honorario> List()
        {
            try
            {
                var lista = new List<Honorario>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Honorario";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var processo = new Honorario();

                    processo.Id = reader.GetInt32("id_hon");
                    processo.Valor = DAOHelper.GetDouble(reader, "valor_hon");
                    processo.Descricao = DAOHelper.GetString(reader, "descricao_hon");
                    processo.DataHonorario = DAOHelper.GetDateTime(reader, "data_hon");


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
    }
}
