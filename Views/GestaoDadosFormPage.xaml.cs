using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para GestaoDadosFormPage.xam
    /// </summary>
    public partial class GestaoDadosFormPage : Page
    {
        BackgroundWorker worker = new BackgroundWorker();
        public GestaoDadosFormPage()
        {
            InitializeComponent();
        }

        private void RecortarImagem_Click(object sender, RoutedEventArgs e)
        {

        }

        public void SelecionarArquivos()
        {
            string sourcePath = "", fileName = "";
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\ListView\";

            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                sourcePath = opf.FileName;
                fileName = opf.SafeFileName;
            }
        }

        private void SelecionarArquivos_Click(object sender, RoutedEventArgs e)
        {
            string sourcePath = "", fileName = "";
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\ListView\";

            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                 sourcePath = opf.FileName;
                 fileName = opf.SafeFileName;

                if (sourcePath != "") File.Copy(sourcePath, saida + fileName, true);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PDFpIMG_Click(object sender, RoutedEventArgs e)
        {
            /*string sourcePath = "", fileName = "";
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Alterar\";

            if (opf.ShowDialog() == true)
            {
                sourcePath = opf.FileName;
                fileName = opf.SafeFileName;

                if (sourcePath != "") File.Move(sourcePath, saida + fileName);
            }
            */
        }
    }
}
