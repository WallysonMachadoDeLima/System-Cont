using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using Microsoft.Win32;

namespace TESTETOPBAR.pages
{
    /// <summary>
    /// Lógica interna para Copia.xaml
    /// </summary>
    public partial class Copia : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        string fileName = "", sourcePath = "", saida = "C:\\Users\\macha\\OneDrive\\Área de Trabalho\\PROJETOS\\System-Cont\\Gerenciador_arquivos\\Arquivos\\";
        
        public Copia()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        

        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                txtsource.Text = opf.FileName;
                sourcePath = opf.FileName;
                fileName = opf.SafeFileName;
            }

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            File.Copy(txtsource.Text, saida + fileName, true);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
