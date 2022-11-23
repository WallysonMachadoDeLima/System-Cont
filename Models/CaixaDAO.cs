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
    internal class CaixaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(double saldo, int funcionarioId)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirCaixa " +
                "(@saldoAtual, @idFuncionario);";

                comando.Parameters.AddWithValue("@saldoAtual", saldo);
                comando.Parameters.AddWithValue("@idFuncionario", funcionarioId);

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
        public void LastIdCaixa()
        {
            int idCaixaLast = 0;
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "select id_cai from Caixa where id_cai = last_insert_id()";

                var caixa = new Caixa();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    idCaixaLast = DAOHelper.GetInt(reader, "id_cai");
                }
                reader.Close();
                VrsGlobais.idCaixa = idCaixaLast;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
