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
using System.Windows.Shapes;
using System.Diagnostics;

namespace proyectoAna
{
    /// <summary>
    /// Interaction logic for Sesiones.xaml
    /// </summary>
    public partial class VideosTemas : Window
    {
        public VideosTemas()
        {
            InitializeComponent();
        }

        private void btnConteoFiguras_Click(object sender, RoutedEventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo.FileName = @"C:\Users\RONNY\Desktop\DBS\cap 73.mp4";
            proceso.Start();
        }
    }
}
