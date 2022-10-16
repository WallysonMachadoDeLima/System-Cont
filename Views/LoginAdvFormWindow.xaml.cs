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

namespace System_Cont.Views
{
    /// <summary>
    /// Lógica interna para LoginAdvFormWindow.xaml
    /// </summary>
    public partial class LoginAdvFormWindow : Window
    {
        public LoginAdvFormWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavTopBarFormWindow view = new NavTopBarFormWindow();
            view.ShowDialog();
        }

        private void btnNoAccount_Click(object sender, RoutedEventArgs e)
        {
            CadastroAdvFormWindow view = new CadastroAdvFormWindow();
            view.ShowDialog();
        }      
    }
}
