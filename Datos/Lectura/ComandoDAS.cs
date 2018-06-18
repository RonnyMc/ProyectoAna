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
    public class ComandoDAS
    {
        public static  List<Comandos> LlenarListaComandos()
        {
            List<Comandos> ListaComandos = new List<Comandos>();
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM Comandos"), con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ListaComandos.Add(new Comandos(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2),
                                               dataReader.GetString(3)));
            }
            con.Close();
            return ListaComandos;
        }
        public static string[] CargarFrases()
        {
            string[] frases = new string[0];
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT comandos FROM Comandos"), con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Array.Resize(ref frases, frases.Length + 1);
                frases[frases.Length - 1] = dataReader.GetString(0);
            }

            return frases;
        }
    }
}
