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
using TESTETOPBAR.pages;
using System.IO;
using Microsoft.Win32;

namespace TESTETOPBAR
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
      
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnSelecionaArquivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            //define as propriedades do controle OpenFileDialog
            ofd1.Multiselect = false;
            ofd1.Title = "Selecionar Arquivo";
            ofd1.InitialDirectory = @"C:\dados\txt";
            //filtra para exibir todos os arquivos
            ofd1.Filter = "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;
            DialogResult dr = ofd1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //atribui o nome do arquivo ao arquivo texto
                txtArquivo.Text = ofd1.FileName;
            }
        }

        private void BtnSelecionaDiretorio_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.Description = "Selecione o diretório de destino";
            //define pasta inicial
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                // Exibe a pasta selecionada
                txtDiretorio.Text = fbd1.SelectedPath;
            }
    }
}
