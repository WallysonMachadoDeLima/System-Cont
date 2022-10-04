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
    /// Interação lógica para ListarCliFormPage.xam
    /// </summary>
    public partial class ListarCliFormPage : Page
    {
        public ListarCliFormPage()
        {
            InitializeComponent();
        }

     

        private void ButtonAddCliente_Click_(object sender, RoutedEventArgs e)
        {
            NavTopBarFormWindow obj = new NavTopBarFormWindow();
            obj.fraPaginas.Content = new CadastroCliFormPage();
        }
    }
}
