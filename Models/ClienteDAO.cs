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
    internal class ClienteDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert (Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Cliente VALUES " +
                "(null, @nome_cliente, @telefone, @rg, @cpf, @nacionalidade, @renda, @email, @local);";

                comando.Parameters.AddWithValue("@nome_cliente", cliente.NomeCliente);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@rg", cliente.Rg);
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@nacionalidade", cliente.Nacionalidade);
                comando.Parameters.AddWithValue("@renda", cliente.Renda);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@local", cliente.Local);


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

        public List<Cliente> List()
        {
            try
            {
                var lista = new List<Cliente>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Cliente";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = reader.GetInt32("id_cli");
                    cliente.NomeCliente = DAOHelper.GetString(reader, "nome_cli");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone_cli");
                    cliente.Rg = DAOHelper.GetString(reader, "rg_cli");
                    cliente.Cpf = DAOHelper.GetString(reader, "cpf_cli");
                    cliente.Nacionalidade = DAOHelper.GetString(reader, "nacionalidade_cli");
                    cliente.Renda = DAOHelper.GetString(reader, "renda_cli");
                    cliente.Email = DAOHelper.GetString(reader, "email_cli");
                    cliente.Local = DAOHelper.GetString(reader, "local_cli");

                    lista.Add(cliente);

                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Cliente t)
        {

            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Cliente where id_cli = @id";

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
