using System.Windows;
using System.Windows.Input;

namespace System_Cont.Views
{
    public partial class CadastroAdvFormWindow : Window
    {
        public CadastroAdvFormWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void btnHaveLog_Click(object sender, RoutedEventArgs e)
        {
            NavTopBarFormWindow view = new NavTopBarFormWindow();
            view.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
