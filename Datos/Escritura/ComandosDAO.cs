﻿using System;
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
        MySqlConnection con = Conexion.ObtenerConecction();
        public static Comandos InsertarComando(Comandos cm)
        {
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO Comandos(comandos, accion, respuesta) " +
                                            "Values ('{0}', '{1}', '{2}');", cm.Comando, cm.Accion, cm.Respuesta), con);
            cmd.ExecuteNonQuery();
            con.Close();
            return cm;
        }
        public static int DeleteComando(int id)
        {
            MySqlConnection con = Conexion.ObtenerConecction();
            MySqlCommand cmd = new MySqlCommand(string.Format("DELETE FROM comandos WHERE idComandos = "+id), con);
            cmd.ExecuteNonQuery();
            con.Close();
            return id;
        }
    }
}
