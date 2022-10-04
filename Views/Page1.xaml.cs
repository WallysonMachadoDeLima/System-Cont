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
using System_Cont.Views;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para Page1.xam
    /// </summary>
    public partial class Page1 : Page
    {

        private Frame _frame;

        public Page1(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RecortarImagem_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastroCliFormPage();
        }
    }
}
