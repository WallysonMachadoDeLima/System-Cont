using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Cont.Database;

namespace System_Cont.Models
{
    internal class PerfilDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Perfil perfil)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call InserirPerfil " +
                "(@descricao, @data_egresso);";

                comando.Parameters.AddWithValue("@descricao", perfil.Descricao);
                comando.Parameters.AddWithValue("@data_egresso", perfil.Data_Egresso?.ToString("yyyy-MM-dd"));


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
    }
}
