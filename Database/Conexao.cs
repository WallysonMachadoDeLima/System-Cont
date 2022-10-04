using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;

namespace System_Cont.Database
{
    internal class Conexao
    {
        private static string host = "localhost";
        //3306  &  3360
        private static string port = "3306";

        private static string user = "root";
        //Star@pixel4862+!  &   root  & Star@pixel4268!(notebook)
        private static string password = "Star@pixel4862+!";

        private static string dbname = "";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                connection.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlCommand Query(string query)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
