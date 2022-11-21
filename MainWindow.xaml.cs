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
using System_Cont.Views;

namespace System_Cont
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GerenciarPastas();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginAdvFormWindow view = new LoginAdvFormWindow();
             view.ShowDialog();
        }

        public void GerenciarPastas()
        {
            string diretory = Directory.GetCurrentDirectory();
            diretory = diretory.Substring(0, diretory.Length - 9) + @"Files";

           
            Directory.CreateDirectory(diretory);
            Directory.CreateDirectory(diretory + @"\Change");
            Directory.CreateDirectory(diretory + @"\Finished");
            Directory.CreateDirectory(diretory + @"\ListView");
        }

        public void VerifyLogin(string confirmacao)
        {
            if (confirmacao == "Yes")
            {
                Close();
            }
        }
    }
}
