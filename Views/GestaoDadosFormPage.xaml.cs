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

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para GestaoDadosFormPage.xam
    /// </summary>
    public partial class GestaoDadosFormPage : Page
    {
        public GestaoDadosFormPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ligacaoPythonTest chama = new ligacaoPythonTest();

            chama.ShowDialog();
        }
    }
}
