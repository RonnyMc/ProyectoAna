using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliotecaAna;

namespace proyectoAna
{
    /// <summary>
    /// Interaction logic for ConfigInit.xaml
    /// </summary>
    public partial class ConfigInit : Window
    {
        public int count = 0;
        public ConfigInit()
        {
            InitializeComponent();
        }
        public void CrearComando()
        {
            SqlConnection con = Coneccion.ObtenerConecction();
            Comandos cm = new Comandos(txtComando.Text, txtAccion.Text, txtRespuesta.Text);
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Comandos(comandos, accion, respuesta) " +
                                            "Values ('{0}', '{1}', '{2}');", cm.Comando, cm.Accion, cm.Respuesta) ,con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Comando Insertado");
                txtAccion.Clear();
                txtComando.Clear();
                txtRespuesta.Clear();
            }
            else
            {
                MessageBox.Show("Comando no insertado");
            }
            con.Close();
        }
        public void llenarGrid()
        {
            SqlConnection con = Coneccion.ObtenerConecction();
            List<Comandos> listaComandos = new List<Comandos>();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Comandos"), con);
            SqlDataReader dataReader= cmd.ExecuteReader();
            while (dataReader.Read())
            {
                listaComandos.Add(new Comandos(dataReader.GetInt32(0),dataReader.GetString(1),dataReader.GetString(2), 
                                               dataReader.GetString(3)));
            }
            dgCmd.ItemsSource = listaComandos;
            con.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CrearComando();
            llenarGrid();
        }
    }
}
