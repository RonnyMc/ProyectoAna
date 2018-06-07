using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition; //Reconocedor, escuchar e interpretar nuestra voz
using System.Speech.Synthesis; //Voz del dispositivo, Voz de Ana
using System.Data.SqlClient;
using BibliotecaAna;

namespace proyectoAna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //instanciar interpretador de voz
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        SpeechSynthesizer VozAna = new SpeechSynthesizer();
        List<Comandos> Listacomandos = new List<Comandos>();
        Random aleartorio = new Random();
        public int numero1 = 0;
        public int numero2 = 0;
        int c = 0;
        public MainWindow()
        {
            InitializeComponent();
            lblVisor.Content = string.Empty;
            visor.Visibility = Visibility.Hidden;
            //Bienvenida();
            c = c + 1;
        }
        private void Bienvenida()
        {
            if (c==0)
            {
                VozAna.Speak("Bienvenido a tu nueva asistente virtual, Soy Ana, Me da gusto conocerte");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Capturar el sonido de la voz por la entrada por defecto del ordenador
            rec.SetInputToDefaultAudioDevice();
            //Reconoce las palabras que se le indica explicita como parametro en la funcion
            Choices frases = new Choices(CargarFrases());
            //Funcion para construir la gramatica para el reconocedor y reproduccion de voz.
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            //Se pasa el arreglo de frases creadas en choices y se adjunta al constructor de gramatica.
            grammarBuilder.Append(frases);
            Grammar grammar = new Grammar(grammarBuilder);
            //El reconocedor cargara las gramaticas que hemos construido
            rec.LoadGrammar(grammar);
            //La sincronizacion del microfono con las palabras a decir siempre esta activa y escuchando.
            rec.RecognizeAsync(RecognizeMode.Multiple);
            //Reconoce el patron de frase hablado por el usuario y ejecuta una accion.
            rec.SpeechRecognized += Rec_SpeechRecognized;
            //genera un valor al reconocer la voz
            rec.AudioLevelUpdated += Rec_AudioLevelUpdated;
        }
        private void Rec_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            pbAudio.Value = e.AudioLevel;
        }
        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (Comandos com in Listacomandos)
            {
                if (e.Result.Confidence > 0.6)
                {
                    if (com.Comando.ToString().Equals(e.Result.Text.ToString()))
                    {
                        //VozAna.Speak(e.Result.Text.ToString());
                        if (com.Accion.Trim().Length > 0 && com.Accion != null)
                        {
                            System.Diagnostics.Process.Start(com.Accion.ToString());
                        }
                        if (com.Respuesta.Trim().Length > 0)
                        {
                            VozAna.Speak(com.Respuesta.ToString());
                        }
                    }
                }
            }
        }
        private void LlenarListaComandos()
        {
            SqlConnection con = Coneccion.ObtenerConecction();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Comandos"), con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Listacomandos.Add(new Comandos(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2),
                                               dataReader.GetString(3)));
            }
            con.Close();
        }
        private string [] CargarFrases()
        {
            string[] frases = new string[0];
            SqlConnection con = Coneccion.ObtenerConecction();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT comandos FROM Comandos"), con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Array.Resize(ref frases, frases.Length + 1);
                frases[frases.Length - 1] = dataReader.GetString(0);
            }

            return frases;
        }
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            SonarClick();
            String nombreBoton = ((FrameworkElement)sender).Name.ToString();
            visor.Visibility = Visibility.Visible;
            lblVisor.Content = nombreBoton.Substring(3).ToUpper();
        }
        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            visor.Visibility = Visibility.Hidden;
            lblVisor.Content = string.Empty;
        }

        private static void SonarClick()
        {
            if (Properties.Settings.Default.EfectoSonido == true)
            {
                var uri = new Uri(@"../../Sound/hover.wav", UriKind.RelativeOrAbsolute);
                var player = new MediaPlayer();

                player.Open(uri);
                player.Play();

            }

        }
        private void hearth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void heart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.EfectoSonido == true)
            {
                var uri = new Uri(@"../../Sound/hearth.wav", UriKind.RelativeOrAbsolute);
                var player = new MediaPlayer();

                player.Open(uri);
                player.Play();
            }

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            String nombreBoton = ((FrameworkElement)sender).Name.ToString();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VozAna.Speak("Cuando me necesites, vuelve a inicializarme, espero haberte ayudado, Adios");
            this.Close();
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComandos_Click(object sender, RoutedEventArgs e)
        {
            ConfigInit config = new ConfigInit();
            config.Show();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
           
            if (c>0)
            {
                MainWindow main = new MainWindow();
                main.c = 1;
                main.Show();
                this.Close();
                VozAna.Speak("Actualizando datos. Datos Actualizados");
            }
        }
    }
}
