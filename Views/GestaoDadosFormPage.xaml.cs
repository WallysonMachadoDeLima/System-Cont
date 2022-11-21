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
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para GestaoDadosFormPage.xam
    /// </summary>
    public partial class GestaoDadosFormPage : Page
    {
        BackgroundWorker worker = new BackgroundWorker();

        string sourcePath = "", fileName = "", imagem = "", imgview = "", filemove = "";
        public GestaoDadosFormPage()
        {
            InitializeComponent();
            RecarregarLista();
            ImagemViewClick();
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

        // RECARREGAR LISTA DE ARQUIVOS
        public void RecarregarLista()
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\ListView\";
            string[] files = Directory.GetFiles(saida);
            string name = "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

            Listimg.Items.Clear();
            foreach (string file in files)
            {
                TipoArquivo(file);
                string clear = file.Substring(saida.Length);
                string origem = clear.Replace("++", @"\").Replace("!!", @":");
                if (imagem == "")
                {
                    Listimg.Items.Add(new imgs()
                    {
                        Imagem = origem,
                        Local = file,
                        Nome = name,
                        Origem = origem
                    });
                }
                else
                {
                    Listimg.Items.Add(new imgs()
                    {
                        Imagem = imagem,
                        Local = file,
                        Nome = name,
                        Origem = origem
                    });
                    imagem = "";
                }
            }
            //if(Directory.GetFiles(saida).Length > 0) Listimg.Items.Add("");
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
                string origem = sourcePath.Replace(@"\", "++").Replace(@":", "!!");
                if (sourcePath != "")
                {
                    File.Copy(sourcePath, saida + origem, true);
                    RecarregarLista();
                }
            }
        }

        // BOTÃO EXCLUIR 
        private void Deletar_Click(object sender, RoutedEventArgs e)
        {
            if (Listimg.SelectedItem != null)
            {
                var resultado = MessageBox.Show($"Deseja realmente excluir o arquivo?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var selected = Listimg.SelectedItem as imgs;
                        string imagemSelecionada = selected.Local;
                        Listimg.Items.Remove(Listimg.SelectedItem);
                        File.Delete(imagemSelecionada);
                        if (selected.Imagem == imgview) ImagemViewClick();
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // FUNÇÃO MOVER
        public void MoverFiles()
        {
            string saida = Directory.GetCurrentDirectory();
            string entrada = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Change\";
            entrada = entrada.Substring(0, entrada.Length - 9) + @"Files\ListView\";

            var selected = Listimg.SelectedItem as imgs;
            string imagemSelecionada = selected.Local;
            string nomefile = imagemSelecionada.Substring(entrada.Length);
            Listimg.Items.Remove(Listimg.SelectedItem);
            File.Move(imagemSelecionada, saida + nomefile);
            filemove = saida + nomefile;
            if (selected.Imagem == imgview) ImagemViewClick();
        }

        // FUNÇÃO ABRIR FINISHED
        public void OpenFinished()
        {
            File.Delete(filemove);
            GestaoDadosFormSalvarArquivo page = new GestaoDadosFormSalvarArquivo();
            page.ShowDialog();
        }

        // FUNÇÃO LIMPAR FINISHED
        public void LimparFinished()
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";
            string[] files = Directory.GetFiles(saida);
            Listimg.Items.Clear();
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        // ABRIR HISTÓRICO
        private void Historico_Click(object sender, RoutedEventArgs e)
        {
            GestaoDadosFormSalvarArquivo page = new GestaoDadosFormSalvarArquivo();
            page.ShowDialog();
        }

        // BOTÕES DE CONVERTER
        private void ImageInText_Click(object sender, RoutedEventArgs e)
        {
            if (Listimg.SelectedItem != null)
            {
                var resultado = MessageBox.Show($"Converter imagem para arquivo de texto?", "Confirmar converção", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        string saida = Directory.GetCurrentDirectory();
                        saida = saida.Substring(0, saida.Length - 9) + @"Py\";

                        var selected = Listimg.SelectedItem as imgs;
                        string imagemSelecionada = selected.Local;
                        Listimg.Items.Remove(Listimg.SelectedItem);
                        if (File.Exists(saida + "receba")) File.Delete(saida+"recaba");
                        File.Move(imagemSelecionada, saida + "receba.jpg");
                        filemove = saida + "receba";
                        if (selected.Imagem == imgview) ImagemViewClick();
                        LimparFinished();
                        // SCRIPT PYHTON
                        ScriptEngine pythonEngine = Python.CreateEngine();

                        // Imprime os caminhos de pesquisa padrão 
                        System.Console.Out.WriteLine("Search paths:");
                        ICollection<string> searchPaths = pythonEngine.GetSearchPaths();
                        foreach ( string caminho in searchPaths)
                        {
                            Console.Out.WriteLine(caminho);
                        }
                        Console.Out.WriteLine();

                        // Agora modifique os caminhos de pesquisa para incluir o diretório 
                        // do qual executamos o script 
                        searchPaths.Add("..\\..\\Py\\");
                        pythonEngine.SetSearchPaths(searchPaths);

                        // Execute o script
                        // Executamos este script a partir do Visual Studio
                        // então o programa será executado a partir de bin\Debug ou bin\Release
                        ScriptSource pythonScript = pythonEngine.CreateScriptSourceFromFile("..\\..\\Py\\extrair_texto.py");
                        pythonScript.Execute();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void PDFpIMG_Click(object sender, RoutedEventArgs e)
        {
            if (Listimg.SelectedItem != null)
            {
                var resultado = MessageBox.Show($"Converter imagem para arquivo de texto?", "Confirmar converção", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {

                        LimparFinished();
                        // SCRIPT PYHTON
                        ScriptEngine pythonEngine = Python.CreateEngine();

                        // Imprime os caminhos de pesquisa padrão 
                        System.Console.Out.WriteLine("Search paths:");
                        ICollection<string> searchPaths = pythonEngine.GetSearchPaths();
                        foreach (string caminho in searchPaths)
                        {
                            Console.Out.WriteLine(caminho);
                        }
                        Console.Out.WriteLine();

                        // Agora modifique os caminhos de pesquisa para incluir o diretório 
                        // do qual executamos o script 
                        searchPaths.Add("..\\..\\Py\\");
                        pythonEngine.SetSearchPaths(searchPaths);

                        // Execute o script
                        // Executamos este script a partir do Visual Studio
                        // então o programa será executado a partir de bin\Debug ou bin\Release
                        ScriptSource pythonScript = pythonEngine.CreateScriptSourceFromFile("..\\..\\Py\\converter_pdf");
                        pythonScript.Execute();
                        OpenFinished();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RecortarImg_Click(object sender, RoutedEventArgs e)
        {
            if (Listimg.SelectedItem != null)
            {
                var resultado = MessageBox.Show($"Recortar imagem selecionada?", "Confirmar recorte", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var selected = Listimg.SelectedItem as imgs;
                        LimparFinished();

                        string saida = Directory.GetCurrentDirectory();
                        string entrada = Directory.GetCurrentDirectory();
                        saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";
                        entrada = entrada.Substring(0, entrada.Length - 9) + @"Files\ListView\";


                       
                        string imagemSelecionada = selected.Local;
                        string nomefile = imagemSelecionada.Substring(entrada.Length);
                        Listimg.Items.Remove(Listimg.SelectedItem);
                        File.Move(imagemSelecionada, saida + nomefile);
                        filemove = saida + nomefile;

                        System.Diagnostics.Process.Start("explorer.exe", filemove);
                        if (selected.Imagem == imgview) ImagemViewClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditarDocumento_Click(object sender, RoutedEventArgs e)
        {
            if (Listimg.SelectedItem != null)
            {
                var resultado = MessageBox.Show($"Editar documento selecionado?", "Confirmar edição", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var selected = Listimg.SelectedItem as imgs;
                        LimparFinished();

                        string saida = Directory.GetCurrentDirectory();
                        string entrada = Directory.GetCurrentDirectory();
                        saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";
                        entrada = entrada.Substring(0, entrada.Length - 9) + @"Files\ListView\";

                        string imagemSelecionada = selected.Local;
                        string nomefile = imagemSelecionada.Substring(entrada.Length);
                        Listimg.Items.Remove(Listimg.SelectedItem);
                        File.Move(imagemSelecionada, saida + nomefile);
                        filemove = saida + nomefile;

                        if (selected.Imagem == imgview) ImagemViewClick();
                        System.Diagnostics.Process.Start("explorer.exe", filemove);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // VISUALIZAR IMAGEM
        private void ImagemViewClick()
        {
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Imagens\avatar.jpg";

            imgPhoto.Source = new BitmapImage(new Uri(saida));
        }
        private void MostrarImg_Click(object sender, RoutedEventArgs e)
        {
            
            if (Listimg.SelectedItem != null)
            {
                var selected = Listimg.SelectedItem as imgs;
                imgPhoto.Source = new BitmapImage(new Uri(selected.Imagem));
                imgview = selected.Imagem;
            }
            else
            {
                MessageBox.Show("Selecione um arquivo", "Selecionar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RemoverView_Click(object sender, RoutedEventArgs e)
        {
            ImagemViewClick();
        }

        // NÃO SABO
        private void Listimg_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
        private void DataGridImg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click_TesteSalvar(object sender, RoutedEventArgs e)
        {
            GestaoDadosFormSalvarArquivo obj = new GestaoDadosFormSalvarArquivo();
            obj.ShowDialog();
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
        public string Origem { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
    }
}
