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
using System.Data;

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
            txtAccion.IsEnabled = false;
            txtComando.IsEnabled = false;
            txtRespuesta.IsEnabled = false;
            btnAgregar.IsEnabled = false;
        }
        public void InsertarComando()
        {
            try
            {
                Comandos cm = new Comandos();
                if (count==1)
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
        public void SelecionarDeLaLista(Comandos c)
        {
            txtAccion.Text = c.Accion;
            txtComando.Text = c.Comando;
            txtRespuesta.Text = c.Respuesta;
            txtId.Text = c.Id.ToString();
        } 
        public void EliminarComando()
        {
            try
            {
                if (dgCmd.SelectedIndex != -1)
                {
                    int id = Int32.Parse(txtId.Text);
                    Negocio.CNegocio.Instancia.DeleteComando(id);
                    dgCmd.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Seleccione comando a eliminar");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo eliminar -> "+ex.Message);
            }

        }
        public void llenarGridComandos()
        {
            listacomandos = Negocio.CNegocio.Instancia.comandos_ListarAll();
            dgCmd.ItemsSource = listacomandos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtComando.Text == "" || txtRespuesta.Text == "")
            {
                MessageBox.Show("Ingrese comando mas la respuesta");
            }
            else
            {
                count = 1;
                InsertarComando();
                llenarGridComandos();
                txtAccion.Clear();
                txtRespuesta.Clear();
                txtId.Clear();
                txtComando.Clear();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            count = 10;
            EliminarComando();
            llenarGridComandos();
        }

        private void dgCmd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCmd.SelectedIndex != -1)
            {
                Comandos comandos = dgCmd.SelectedItem as Comandos;
                SelecionarDeLaLista(comandos);
            }
            else
            {
                if (count == 10)
                {
                    MessageBox.Show("Comando Eliminado");
                    count = 0;
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna fila");
                }
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtAccion.IsEnabled = true;
            txtComando.IsEnabled = true;
            txtRespuesta.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            txtAccion.Clear();
            txtRespuesta.Clear();
            txtId.Clear();
            txtComando.Clear();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            count = 2;
            txtAccion.IsEnabled = true;
            txtComando.IsEnabled = true;
            txtRespuesta.IsEnabled = true;
        }
    }
}
