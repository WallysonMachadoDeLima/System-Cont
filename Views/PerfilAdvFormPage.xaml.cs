using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System_Cont.Models;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para PerfilAdvFormPage.xam
    /// </summary>
    public partial class PerfilAdvFormPage : Page
    {
        public PerfilAdvFormPage()
        {
            InitializeComponent();
            ImagemPerfil();
        }

        public void ImagemPerfil()
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Funcionarios/" + VrsGlobais.nomeLogado + "/";
            string[] files = Directory.GetFiles(saida);

            foreach (string file in files)
            {
                if (file != "")
                {
                    imgPerfil.Source = new BitmapImage(new Uri(file));
                }
            }

        }

        private void Button_BadgeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void btnInserirImg_Click(object sender, RoutedEventArgs e)
        {

            var dao = new FuncionarioDAO();
            string saida = Directory.GetCurrentDirectory();
            string imgOriginal = saida.Substring(0, saida.Length - 9) + @"Imagens/avatar.jpg";
            saida = saida.Substring(0, saida.Length - 9) + @"Funcionarios/" + VrsGlobais.nomeLogado + "/";

            string sourcePath = "", fileName = "";

            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                sourcePath = opf.FileName;
                fileName = opf.SafeFileName;

                if (sourcePath != "")
                {
                    imgPerfil.Source = new BitmapImage(new Uri(imgOriginal));
                    File.Copy(sourcePath, saida + "ImgPerfil", true);
                    ImagemPerfil();
                }
            }
        }
    }
}
