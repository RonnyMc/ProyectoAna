using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;
using System.Windows;

namespace Datos.Escritura
{
    public class ComandosDAO
    {
        public static int c;
        public static Comandos InsertarComando(Comandos cm)
        {
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO Comandos(comandos, accion, respuesta) " +
                                            "Values ('{0}', '{1}', '{2}');", cm.Comando, cm.Accion, cm.Respuesta), con);
            c = cmd.ExecuteNonQuery();
            con.Close();
            return cm;
        }
    }
}
