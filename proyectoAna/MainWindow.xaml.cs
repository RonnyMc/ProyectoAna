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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Capturar el sonido de la voz por la entrada por defecto del ordenador
            rec.SetInputToDefaultAudioDevice();
            //Reconoce las palabras que se le indica explicita como parametro en la funcion
            Choices frases = new Choices(new string[] {"hola", "Como Estas", "Que haces", "gracias", "Inicia Google"});
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
        }

        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Reconoce las palabras que el usuario dice y las repite dependiendo de su diccionario de frases.
            //VozAna.Speak(e.Result.Text);
            switch (e.Result.Text)
            {
                case "hola":
                    VozAna.Speak("Hola Ronny, ¿Como Esta el Dia de hoy?");
                    break;
                case "Inicia Google":
                    VozAna.SpeakAsync("Iniciando google");
                    System.Diagnostics.Process.Start("www.google.com");
                    VozAna.Speak("google Iniciado");
                    break;
            }
        }
    }
}
