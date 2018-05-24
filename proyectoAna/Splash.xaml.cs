using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proyectoAna
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        BackgroundWorker backGroundWorker = new BackgroundWorker();
        public Splash()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            backGroundWorker.WorkerReportsProgress = true;
            backGroundWorker.DoWork += BackGroundWorker_DoWork;
            backGroundWorker.ProgressChanged += BackGroundWorker_ProgressChanged;
            backGroundWorker.RunWorkerCompleted += BackGroundWorker_RunWorkerCompleted;
            backGroundWorker.RunWorkerAsync();
        }

        private void BackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Cargado Con éxito");
            if (Properties.Settings.Default.cfgInit == false)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }

        private void BackGroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoad.Value = e.ProgressPercentage;
        }

        private void BackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i=0; i<=100; i++)
            {
                Thread.Sleep(20);
                backGroundWorker.ReportProgress(i);
            }
        }

    }
}
