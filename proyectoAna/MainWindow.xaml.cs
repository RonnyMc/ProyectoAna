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
        //SpeechRecognitionEngine rec2 = new SpeechRecognitionEngine();
        SpeechRecognitionEngine rec3 = new SpeechRecognitionEngine();
        SpeechSynthesizer VozAna = new SpeechSynthesizer();
        List<Comandos> Listacomandos = new List<Comandos>();
        List<Respuestas> ListaRespuestas = new List<Respuestas>();
        int capturarID = 0;
        int temp = 0;
        //string voz;
        string[] CargarFrases;
        string[] CargarFrasesRespuestas;
        int c = 0;
        //int pregunta = 0;
        public MainWindow()
        {
            InitializeComponent();
            lblVisor.Content = string.Empty;
            visor.Visibility = Visibility.Hidden;
            Listacomandos = Negocio.CNegocio.Instancia.comandos_ListarAll();
            CargarFrases = Negocio.CNegocio.Instancia.CargarFrases();
            ListaRespuestas = Negocio.CNegocio.Instancia.respuestas_ListarAll();
            CargarFrasesRespuestas = Negocio.CNegocio.Instancia.CargarFrasesRespuestas();
            Bienvenida();
            c = c + 1;
        }
        private void Bienvenida()
        {
            if (c == 0)
            {
                VozAna.Speak("Ana te da la bienvenida");
                //VozAna.Speak("Welcome Everyone, My name is Ana");
            }
        }
        private void cargarComandos()
        {
            Listacomandos = Negocio.CNegocio.Instancia.comandos_ListarAll();
            CargarFrases = Negocio.CNegocio.Instancia.CargarFrases();
            //Reconoce las palabras que se le indica explicita como parametro en la funcion
            Choices frases = new Choices(CargarFrases);
            //Funcion para construir la gramatica para el reconocedor y reproduccion de voz.
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            //Se pasa el arreglo de frases creadas en choices y se adjunta al constructor de gramatica.
            grammarBuilder.Append(frases);
            Grammar grammar = new Grammar(grammarBuilder);
            //El reconocedor cargara las gramaticas que hemos construido
            rec.LoadGrammar(grammar);
        }
        private void cargarRespuestas()
        {
            ListaRespuestas = Negocio.CNegocio.Instancia.respuestas_ListarAll();
            CargarFrasesRespuestas = Negocio.CNegocio.Instancia.CargarFrasesRespuestas();
            //Reconoce las palabras que se le indica explicita como parametro en la funcion
            Choices frasesRespuestas = new Choices(CargarFrasesRespuestas);
            //Funcion para construir la gramatica para el reconocedor y reproduccion de voz.
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            //Se pasa el arreglo de frases creadas en choices y se adjunta al constructor de gramatica.
            grammarBuilder.Append(frasesRespuestas);
            Grammar grammar = new Grammar(grammarBuilder);
            //El reconocedor cargara las gramaticas que hemos construido
            rec3.LoadGrammar(grammar);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Capturar el sonido de la voz por la entrada por defecto del ordenador
                rec.SetInputToDefaultAudioDevice();
                //rec2.SetInputToDefaultAudioDevice();
                //rec2.LoadGrammar(new DictationGrammar());
                rec3.SetInputToDefaultAudioDevice();
                cargarComandos();
                cargarRespuestas();
                //La sincronizacion del microfono con las palabras a decir siempre esta activa y escuchando.
                rec.RecognizeAsync(RecognizeMode.Multiple);
                //rec2.RecognizeAsync(RecognizeMode.Multiple);
                rec3.RecognizeAsync(RecognizeMode.Multiple);
                //Reconoce el patron de frase hablado por el usuario y ejecuta una accion.
                //rec2.SpeechRecognized += Rec2_SpeechRecognized;
                rec.SpeechRecognized += Rec_SpeechRecognized;
                rec3.SpeechRecognized += Rec3_SpeechRecognized;
            }
            catch(Exception ex)
            {
                VozAna.Speak("Ha ocurrido un error inesperado");
                MessageBox.Show(" -----> CIERRE EL ASISTENTE, COMPRUEBE SI ESTA INICIALIZADO EL SERVIDOR XAMP, SI ESTA CONECTADO SU MICROFONO O HAY DATOS EN LA BASE DE DATOS, CASO CONTRARIO CONSULTE CON SU PROVEEDOR DEL DISPOSITIVO", ex.Message);
            }

            //genera un valor al reconocer la voz
            rec.AudioLevelUpdated += Rec_AudioLevelUpdated;
        }

        private void Rec3_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string[] RespuestaRandom = { "Muy bien", "Fantástico, Tu respuesta es correcta", "Muy bien, correcto, eres increíble", "Muy bien, buena respuesta", "Eres muy inteligente, buena respuesta", "Bien, es correcto", "Correcto, Gracias por participar" };
            Random r = new Random();
            int aleatorioHRequest = r.Next(0, 6);

            //MessageBox.Show("ID comando: "+ capturarID);
            foreach (Respuestas resp in ListaRespuestas)
            {
                if (capturarID != 0)
                {
                    if (capturarID == resp.IdComandos)
                    {
                        if (resp.Respuesta.ToString().Equals(e.Result.Text.ToString()))
                        {
                            capturarID = 0;
                            temp = 1;
                            VozAna.Speak(RespuestaRandom[aleatorioHRequest]);
                            break;
                        }
                        else
                        {
                            temp = 1;
                            VozAna.Speak("Intentalo otra vez, porfavor");
                            break;
                        }
                    }
                }
            }
            //capturarID = 0;
        }

        //private void Rec2_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    voz = e.Result.Text;
        //    //VozAna.Speak(voz);
        //   // MessageBox.Show("ESTO ACABO DE DECIR: "+voz);
        //}

        private void Rec_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            pbAudio.Value = e.AudioLevel;
        }
        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int validator = 0;
            string[] comandRandomHi = { "Hola", "Hola, Yo Soy Ana", "Hola, mi nombre es ANA", "Comencemos", "Encantado de saludarte", "Hola, ¿Puedo ayudarte en algo?", "Hola, Estoy lista para ti" };

            Random r = new Random();
            int aleatorioHi = r.Next(0, 6);
            if (temp==0)
            {
                foreach (Comandos com in Listacomandos)
                {
                    validator = 1;
                    if (e.Result.Confidence > 0.3)
                    {
                        if (com.Comando.ToString().Equals(e.Result.Text.ToString()))
                        {
                            //VozAna.Speak(com.Respuesta.ToString());
                            //VozAna.Speak(e.Result.Text.ToString());
                            if (com.Accion.Trim().Length > 0 && com.Accion != null)
                            {
                                System.Diagnostics.Process.Start(com.Accion.ToString());
                                //if (c==2)
                                //{
                                //VozAna.Speak(com.Respuesta.ToString());
                                //c = 1;
                                //}

                            }
                            if (com.Respuesta.Trim().Length > 0)
                            {
                                //if (pregunta == 0)
                                //{
                                if (com.Comando.ToString().Equals("Hola"))
                                {
                                    //MessageBox.Show("id = " + com.Id);
                                    VozAna.Speak(comandRandomHi[aleatorioHi]);
                                }
                                else
                                {
                                    capturarID = com.Id;
                                    VozAna.Speak(com.Respuesta.ToString());
                                }
                                //if (com.Respuesta.ToString().Equals("how many geometric figures do you see in this image?"))
                                //{
                                //    pregunta = 1;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("how many geometric figures do you see now?"))
                                //{
                                //    pregunta = 2;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("how mane geometric figures there are here?"))
                                //{
                                //    pregunta = 3;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("Tell me, how many geometric figures do you see?"))
                                //{
                                //    pregunta = 4;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("cuantas figuras geométricas observas aqui"))
                                //{
                                //    pregunta = 5;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("how many circles do you see in this image?"))
                                //{
                                //    pregunta = 6;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("how many triangles do you see?"))
                                //{
                                //    pregunta = 7;
                                //    break;
                                //}
                                //if (com.Respuesta.ToString().Equals("how many geometric figures do you see in total?"))
                                //{
                                //    pregunta = 8;
                                //    break;
                                //}
                                //}
                                //if (pregunta == 1)
                                //{
                                //    if (e.Result.Text.ToString().Equals("seven"))
                                //    {
                                //        VozAna.Speak("great, is correct");
                                //        pregunta = 0;
                                //        break;
                                //    }
                                //}
                                //if (pregunta == 2)
                                //{
                                //    if (e.Result.Text.ToString().Equals("five"))
                                //    {
                                //        VozAna.Speak("Very Well");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 3)
                                //{
                                //    if (e.Result.Text.ToString().Equals("seven"))
                                //    {
                                //        VozAna.Speak("Very good, friend, correct");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 4)
                                //{
                                //    if (e.Result.Text.ToString().Equals("six"))
                                //    {
                                //        VozAna.Speak("good, is correct");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 5)
                                //{
                                //    if (e.Result.Text.ToString().Equals("seis"))
                                //    {
                                //        VozAna.Speak("Respuesta correcta");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 6)
                                //{
                                //    if (e.Result.Text.ToString().Equals("four"))
                                //    {
                                //        VozAna.Speak("you request is correct");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 7)
                                //{
                                //    if (e.Result.Text.ToString().Equals("four"))
                                //    {
                                //        VozAna.Speak("Is correct");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                                //if (pregunta == 8)
                                //{
                                //    if (e.Result.Text.ToString().Equals("seven"))
                                //    {
                                //        VozAna.Speak("congratulations, is correct");
                                //        pregunta = 0;
                                //        break;
                                //    }

                                //}
                            }
                        }
                    }
                    if (validator == 0)
                    {
                        VozAna.Speak("No es la respuesta");
                    }
                }
            }
            else
            {
                temp = 0;
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
            //VozAna.Speak("When you need my help, Start on Ana Holographic, I hope help you, Good Bye");

            this.Close();
        }
        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.Show();
        }
        private void btnComandos_Click(object sender, RoutedEventArgs e)
        {
            ConfigInit config = new ConfigInit();
            config.Show();
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            c = 2;
            cargarComandos();
            VozAna.Speak("actualizando datos, Datos actualizados");
        }
    }
}
