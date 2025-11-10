using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoArrocha
{
    public class DataBase
    {
        private static string connectionString = "server=Localhost;Database=proyecto_ds4;Uid=root;Pwd=Dinosaurio19;";
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
    }
}
