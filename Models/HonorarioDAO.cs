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
                "(@numero_processo, @valor, @descricao, @data, @idProcesso);";

                comando.Parameters.AddWithValue("@numero_processo", honorario.NumeroProcesso);
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
                    var honorario = new Honorario();

                    honorario.Id = reader.GetInt32("id_hon");
                    honorario.NumeroProcesso = DAOHelper.GetString(reader, "numero_processo_hon");
                    honorario.Valor = DAOHelper.GetDouble(reader, "valor_hon");
                    honorario.Descricao = DAOHelper.GetString(reader, "descricao_hon");
                    honorario.DataHonorario = DAOHelper.GetDateTime(reader, "data_hon");

                    lista.Add(honorario);
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
