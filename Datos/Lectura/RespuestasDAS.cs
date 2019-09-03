using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Datos;
using System.Data;
using Entidades;

namespace Datos.Lectura
{
    public class RespuestasDAS
    {
        public static List<Respuestas> LlenarListaRespuestas()
        {
            List<Respuestas> ListaRespuestas = new List<Respuestas>();
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM respuestas"), con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ListaRespuestas.Add(new Respuestas(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2)));
            }
            con.Close();
            return ListaRespuestas;
        }
        public static string[] CargarFrasesRespuestas()
        {
            string[] frasesRespuestas = new string[0];
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT respuesta FROM Respuestas"), con); 
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Array.Resize(ref frasesRespuestas, frasesRespuestas.Length + 1);
                frasesRespuestas[frasesRespuestas.Length - 1] = dataReader.GetString(0);
            }

            return frasesRespuestas;
        }

    }
}
