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
        Random aleartorio = new Random();
        public string hola = "hola";
        public int numero1 = 0;
        public int numero2 = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Capturar el sonido de la voz por la entrada por defecto del ordenador
            rec.SetInputToDefaultAudioDevice();
            //Reconoce las palabras que se le indica explicita como parametro en la funcion
            Choices frases = new Choices(new string[] {"Hola Ana", "Como Estas", "Que haces", "inicies Google", "iniciar google",
                                                        "iniciar musica", "bien" });
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
            //VozAna.Speak("Bienvenido a a tu nueva asistente virtual, soy Ana, Me da gusto conocerte");
            //genera un valor al reconocer la voz
            rec.AudioLevelUpdated += Rec_AudioLevelUpdated;
        }

        private void Rec_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            pbAudio.Value = e.AudioLevel;
        }

        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Reconoce las palabras que el usuario dice y las repite dependiendo de su diccionario de frases.
            //VozAna.Speak(e.Result.Text);
            lblPalabras.Content = e.Result.Text;
            switch (e.Result.Text)
            {
                case "bien":
                    VozAna.Speak("Me alegro señor jassio, ¿alguna otra pregunta?");
                    break;
                case "Hola Ana":
                    VozAna.Speak("Hola Ronny, ¿como estas?");
                    break;
                case "inicies Google":
                    VozAna.SpeakAsync("Iniciando google");
                    System.Diagnostics.Process.Start("www.google.com");
                    VozAna.Speak("google Iniciado");
                    break;
                case "Que haces":
                    int valor = aleartorio.Next(1, 4);
                    if (valor == 1)
                    {
                        VozAna.Speak("Lo que tu no haces");
                    }
                    if (valor == 2)
                    {
                        VozAna.Speak("Esperando hacer algo por ti");
                    }
                    if (valor == 3)
                    {
                        VozAna.Speak("Aburrida y ¿tu?");
                    }
                    if (valor == 4)
                    {
                        VozAna.Speak("Filosofando de la vida, gracias, aunque yo no tengo vida, pero la tendré");
                    }
                    break;
                case "Como Estas":
                    VozAna.Speak("Bien gracias, y usted ¿cómo esta?");
                    break;
                case "iniciar musica":
                    System.Diagnostics.Process.Start("C:/Users/RONNY/Desktop/instrumentalDePiano.mp3");
                    break;
                case "iniciar google":
                    VozAna.SpeakAsync("Iniciando google");
                    System.Diagnostics.Process.Start("www.google.com");
                    VozAna.Speak("google Iniciado");
                    break;
                default:
                    break;
            }
        }
    }
}
