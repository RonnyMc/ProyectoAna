using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BibliotecaAna
{
    public class Coneccion
    {
        public static MySqlConnection ObtenerConecction()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;database=baseana;Uid=root;pwd=;SSL Mode=none;");
            con.Open();
            return con;
        }
    }
}
