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
    internal class ReuniaoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Reuniao reuniao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirReuniao " +
                "(@status, @DataReuniao, @horarioInicio, @horarioTermino, @tema);";

                comando.Parameters.AddWithValue("@status", reuniao.Status);
                comando.Parameters.AddWithValue("@DataReuniao", reuniao.DataReuniao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@horarioInicio", reuniao.HorarioIncio?.ToString("HH:mm"));
                comando.Parameters.AddWithValue("@horarioTermino", reuniao.HorarioTermino?.ToString("HH:mm"));
                comando.Parameters.AddWithValue("@tema", reuniao.Tema);

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

        public List<Reuniao> List()
        {
            try
            {
                var lista = new List<Reuniao>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Reuniao";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var reuniao = new Reuniao();

                    reuniao.Id = reader.GetInt32("id_reu");
                    reuniao.Status = DAOHelper.GetString(reader, "status_reu");
                    reuniao.DataReuniao = DAOHelper.GetDateTime(reader, "data_reu");
                    reuniao.HorarioIncio = DAOHelper.GetDateTime(reader, "horario_inicio_reu");
                    reuniao.HorarioTermino = DAOHelper.GetDateTime(reader, "horario_termino_reu"); 
                    reuniao.Tema = DAOHelper.GetString(reader, "resumo_reu");
                    lista.Add(reuniao);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Reuniao t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Reuniao where id_reu = @id";

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
