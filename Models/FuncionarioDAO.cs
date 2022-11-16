using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Cont.Database;

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
                "(@nome_funcionario, @carga_horaria, @turno, @descricao, @escola);";

                comando.Parameters.AddWithValue("@nome_curso", funcionario.NomeFuncionario);
                comando.Parameters.AddWithValue("@escola", funcionario.Perfil.Id);

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
