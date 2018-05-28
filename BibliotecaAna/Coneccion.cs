using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAna
{
    public class Coneccion
    {
        public static SqlConnection ObtenerConecction()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Coneccion);
            con.Open();
            return con;
        }
    }
}
