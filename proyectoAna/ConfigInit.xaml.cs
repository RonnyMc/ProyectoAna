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
using Entidades;
using Datos;
using MySql.Data.MySqlClient;

namespace proyectoAna
{
    /// <summary>
    /// Interaction logic for ConfigInit.xaml
    /// </summary>
    public partial class ConfigInit : Window
    {
        public int count = 0;
        List<Comandos> listacomandos = new List<Comandos>();
        public ConfigInit()
        {
            InitializeComponent();
            llenarGridComandos();
        }
        public void InsertarComando()
        {
            try
            {
                Comandos cm = new Comandos();
                if (count ==1)
                {
                    cm.Accion = txtAccion.Text;
                    cm.Comando = txtComando.Text;
                    cm.Respuesta = txtRespuesta.Text;
                    Negocio.CNegocio.Instancia.InsertarComando(cm);
                    MessageBox.Show("Comando Insertado");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Error Metodo InsertarComando: ->"+exe.Message);
            }
            
        }
        public void llenarGridComandos()
        {
            listacomandos = Negocio.CNegocio.Instancia.comandos_ListarAll();
            dgCmd.ItemsSource = listacomandos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            count = 1;
            InsertarComando();
            llenarGridComandos();
        }
    }
}
