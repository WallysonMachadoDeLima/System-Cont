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
using System.IO;
using WinForms = System.Windows.Forms;
using Microsoft.Win32;


namespace System_Cont.Views
{
    /// <summary>
    /// Lógica interna para GestaoDadosFormSalvarArquivo.xaml
    /// </summary>
    public partial class GestaoDadosFormSalvarArquivo : Window
    {
        string sourcePath = "", fileName = "", imagem = "";
        public GestaoDadosFormSalvarArquivo()
        {
            InitializeComponent();
            RecarregarLista();
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
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";
            string[] files = Directory.GetFiles(saida);

            Listimg.Items.Clear();
            foreach (string file in files)
            {
                string name = "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
                TipoArquivo(file);
                if (imagem == "")
                {
                    Listimg.Items.Add(new imgsFinished()
                    {
                        Imagem = file,
                        Local = file,
                        Nome = name
                    });
                }
                else
                {
                    Listimg.Items.Add(new imgsFinished()
                    {
                        Imagem = imagem,
                        Local = file,
                        Nome = name
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
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";

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

        // SALVAR ARQUIVOS
        private void SalvarArquivos_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                string caminho = folderDialog.SelectedPath;
                MoverArquivos(caminho);
            }
            Close();
        }

        // MOVER ARQUIVOS
        public void MoverArquivos(string caminho)
        {
            string name = "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
            string saida = Directory.GetCurrentDirectory();
            saida = saida.Substring(0, saida.Length - 9) + @"Files\Finished\";
            string[] files = Directory.GetFiles(saida);

            Listimg.Items.Clear();
            foreach (string file in files)
            {
               File.Copy(file, caminho + @"\" + name + file.Substring(saida.Length));
            }
        }

        // NÃO SABO
        private void DataGridImg_SelectionChangedXXXX(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CancelarTranferencia_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
    public class imgsFinished
    {
        public string Imagem { get; set; }
        public string Local { get; set; }
        public string Nome { get; set; }
    }
}
