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
    public class RespuestasDAO
    {
        public static int c;
        MySqlConnection con = Conexion.ObtenerConecction();

        public static Respuestas InsertarRespuesta(Respuestas resp)
        {
            MySqlConnection cone = Conexion.ObtenerConecction();
            MySqlCommand cmds = new MySqlCommand(string.Format("SELECT MAX(idComandos) as id FROM comandos"), cone);
            

            MySqlDataReader dataReader = cmds.ExecuteReader();

            while (dataReader.Read())
            {
                resp.IdComandos = dataReader.GetInt32(0);
            }
            cone.Close();
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO Respuestas(respuesta, idComando) " +
                                            "Values ('{0}', '{1}');", resp.Respuesta, resp.IdComandos), con);

            cmd.ExecuteNonQuery();
            con.Close();
            return resp;
        }
        public static Respuestas UpdateRespuestas(Respuestas resp)
        {
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE respuestas set respuesta = '" + 
                                                resp.Respuesta + "' WHERE idComando = '" + resp.IdComandos + "'"), con);
            cmd.ExecuteNonQuery();
            con.Close();
            return resp;
        }
    }
}
