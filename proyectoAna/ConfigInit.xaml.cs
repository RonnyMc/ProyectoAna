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
        public int count = 1;
        List<Comandos> listacomandos = new List<Comandos>();
        List<Respuestas> listarespuestas = new List<Respuestas>();
        public ConfigInit()
        {
            InitializeComponent();
            llenarGridComandos();
            txtAccion.IsEnabled = false;
            txtComando.IsEnabled = false;
            txtRespuesta.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnEditar.IsEnabled = false;
            txtRespuestaPregunta.IsEnabled = false;
        }
        public void InsertarComando()
        {
            try
            {
                Comandos cm = new Comandos();
                Respuestas resp = new Respuestas();
                if (count==1)
                {
                    cm.Accion = txtAccion.Text;
                    cm.Comando = txtComando.Text;
                    cm.Respuesta = txtRespuesta.Text;
                    cm.RespuestaPregunta = txtRespuestaPregunta.Text;
                    Negocio.CNegocio.Instancia.InsertarComando(cm);
                    resp.Respuesta = txtRespuestaPregunta.Text;
                    Negocio.CNegocio.Instancia.InsertarRespuestas(resp);
                    if (txtRespuestaPregunta.Text == "")
                    {
                        MessageBox.Show("Comando Insertado");
                    }
                    else
                    {
                        MessageBox.Show("Comando y Respuesta Insertados");
                    }

                }
                else
                {
                    cm.Accion = txtAccion.Text;
                    cm.Comando = txtComando.Text;
                    cm.Respuesta = txtRespuesta.Text;
                    cm.Id = Int32.Parse(txtId.Text);
                    cm.RespuestaPregunta = txtRespuestaPregunta.Text;
                    Negocio.CNegocio.Instancia.UpdateComando(cm);
                    resp.Respuesta = txtRespuestaPregunta.Text;
                    resp.IdComandos = Int32.Parse(txtId.Text);
                    Negocio.CNegocio.Instancia.UpdateRespuestas(resp);
                    MessageBox.Show("Comando Actualizado");
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
            txtRespuestaPregunta.Text = c.RespuestaPregunta;
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
                InsertarComando();
                llenarGridComandos();
                txtAccion.Clear();
                txtRespuesta.Clear();
                txtId.Clear();
                txtComando.Clear();
                txtRespuestaPregunta.Clear();
                btnAgregar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnNuevo.IsEnabled = true;
                btnAgregar.Content = "Agregar";
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
                btnEditar.IsEnabled = true;
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
            txtRespuestaPregunta.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            txtAccion.Clear();
            txtRespuesta.Clear();
            txtId.Clear();
            txtComando.Clear();
            txtRespuestaPregunta.Clear();
            btnAgregar.Content = "Agregar";
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            count = 2;
            txtAccion.IsEnabled = true;
            txtComando.IsEnabled = true;
            txtRespuesta.IsEnabled = true;
            txtRespuestaPregunta.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            btnEliminar.IsEnabled = false;
            btnAgregar.Content = "Modificar";
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtAccion.IsEnabled = false;
            txtComando.IsEnabled = false;
            txtRespuesta.IsEnabled = false;
            txtRespuestaPregunta.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            txtAccion.Clear();
            txtRespuesta.Clear();
            txtId.Clear();
            txtComando.Clear();
            btnAgregar.Content = "Agregar";
            btnEliminar.IsEnabled = true;
            btnEditar.IsEnabled = false;
        }
    }
}
