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

        string sourcePath = "", fileName = "", imagem = "";
        public GestaoDadosFormPage()
        {
            InitializeComponent();
            RecarregarLista();
        }

        // RECARREGAR LISTA DE ARQUIVOS
        public void RecarregarLista()
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\ListView\";
            string[] files = Directory.GetFiles(saida);

            Listimg.Items.Clear();
            foreach (string file in files)
            {
                TipoArquivo(file);
                if (imagem == "")
                {
                    Listimg.Items.Add(new imgs()
                    {
                        Imagem = file,
                        Local = file,
                        Nome = file.Substring(saida.Length)
                    });
                }
                else
                {
                    Listimg.Items.Add(new imgs()
                    {
                        Imagem = imagem,
                        Local = file,
                        Nome = file.Substring(saida.Length)
                    });
                    imagem = "";
                }
            }
            //if(Directory.GetFiles(saida).Length > 0) Listimg.Items.Add("");
        }

        // INDENTIFICA O TIPO DO ARQUIVO
        public void TipoArquivo(string local)
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Imagens\";

            List<string> tipos = new List<string>();
            string[] formatos = new string[] { ".pdf", ".docx", ".txt", ".pptx" };
            tipos.AddRange(formatos);

            if (local.Contains(tipos[0])) imagem = saida + "pdf.png";

            if (local.Contains(tipos[1])) imagem = saida + "docx.png";
            if (local.Contains(tipos[2])) imagem = saida + "txt.png";
            if (local.Contains(tipos[3])) imagem = saida + "pptx.jpg";
        }

        // ADICIONAR ITEM A LISTA
        private void SelecionarArquivos_Click(object sender, RoutedEventArgs e)
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\ListView\";

            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                sourcePath = opf.FileName;
                fileName = opf.SafeFileName;

                if (sourcePath != "")
                {
                    File.Copy(sourcePath, saida + fileName, true);
                    RecarregarLista();
                }
            }
        }

        // BOTÃO EXCLUIR OU MOVER ARQUIVO
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string saida = Directory.GetCurrentDirectory();
            string entrada = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Change\";
            entrada = entrada.Substring(0, entrada.Length - 9) + @"Files\ListView\";

            var selected = Listimg.SelectedItem as imgs;

            var resultado = MessageBox.Show($"Deseja realmente excluir o arquivo?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    string imagemSelecionada = selected.Local;

                    string nomefile = imagemSelecionada.Substring(entrada.Length);

                    
                    Listimg.Items.Remove(Listimg.SelectedItem);
                    MessageBox.Show(imagemSelecionada);
                    File.Move(imagemSelecionada, saida + nomefile);


                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PDFpIMG_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(imagem);
        }

        // NÃO SABO
        private void Listimg_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
        private void DataGridImg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RecortarImagem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class imgs
    {
        public string Imagem { get; set; }
        public string Local { get; set; }
        public string Nome { get; set; }
    }
}
