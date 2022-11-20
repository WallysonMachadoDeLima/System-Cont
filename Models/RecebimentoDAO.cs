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
    internal class RecebimentoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Recebimento recebimento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirRecebimento " +
                "(@descricao, @valor, @dataRecebimento, @idCaixa, @idHonorario);";

                comando.Parameters.AddWithValue("@descricao", recebimento.DescricaoRec);
                comando.Parameters.AddWithValue("@valor", recebimento.ValorRec);
                comando.Parameters.AddWithValue("@dataRecebimento", recebimento.Data_Recebimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@idCaixa", recebimento.Caixa.Id);
                comando.Parameters.AddWithValue("@idHonorario", recebimento.Honorario.Id);

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

        public List<Recebimento> List()
        {
            try
            {
                var lista = new List<Recebimento>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Recebimento";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var recebimento = new Recebimento();

                    recebimento.Id = reader.GetInt32("id_rec");
                    recebimento.DescricaoRec = DAOHelper.GetString(reader, "descricao_rec");
                    recebimento.ValorRec = DAOHelper.GetDouble(reader, "valor_rec");
                    recebimento.Data_Recebimento = DAOHelper.GetDateTime(reader, "data_recebimento_rec");

                    lista.Add(recebimento);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
          public double SomaRecebimento()
          {
            double totalRecebimentoAnual = 0;

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select sum(valor_rec) from Recebimento";

                var recebimento = new Recebimento();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    totalRecebimentoAnual = DAOHelper.GetDouble(reader, "sum(valor_rec)");

                }

                reader.Close();
                return totalRecebimentoAnual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          }
                                
        public void Delete(Recebimento t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Recebimento where id_rec = @id";

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
