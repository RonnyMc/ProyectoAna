using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Speech.Recognition; //Reconocedor, escuchar e interpretar nuestra voz
using System.Speech.Synthesis; //Voz del dispositivo, Voz de Ana
using Entidades;

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
        string[] CargarFrases;
        Random aleartorio = new Random();
        public int numero1 = 0;
        public int numero2 = 0;
        int c = 0;
        int pregunta = 0;
        public MainWindow()
        {
            InitializeComponent();
            lblVisor.Content = string.Empty;
            visor.Visibility = Visibility.Hidden;
            Listacomandos = Negocio.CNegocio.Instancia.comandos_ListarAll();
            CargarFrases = Negocio.CNegocio.Instancia.CargarFrases();
            Bienvenida();
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
            Choices frases = new Choices(CargarFrases);
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
                //if (e.Result.Confidence > 0.3)
                //{
                    if (com.Comando.ToString().Equals(e.Result.Text.ToString()))
                    {
                        //VozAna.Speak(com.Respuesta.ToString());
                        //VozAna.Speak(e.Result.Text.ToString());
                        if (com.Accion.Trim().Length > 0 && com.Accion != null)
                        {
                            System.Diagnostics.Process.Start(com.Accion.ToString());
                            VozAna.Speak(com.Respuesta.ToString());
                        }
                        if (com.Respuesta.Trim().Length > 0)
                        {
                            if (pregunta==0)
                            {
                                VozAna.Speak(com.Respuesta.ToString());
                                if (com.Respuesta.ToString().Equals("cuanto es uno mas uno"))
                                {
                                    pregunta = 1;
                                    break;
                                }break;
                            }
                            if (pregunta==1)
                            {
                                if (e.Result.Text.ToString().Equals("dos"))
                                {
                                    VozAna.Speak("Respuesta correcta");
                                    pregunta = 0;
                                    break;
                                }
                            }
                            
                        }
                    }
                //}
            }
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
