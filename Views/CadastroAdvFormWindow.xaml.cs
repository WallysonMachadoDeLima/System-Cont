using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System_Cont.Database;
using System_Cont.Models;
using System;


namespace System_Cont.Views
{
    public partial class CadastroAdvFormWindow : Window
    {
        private Funcionario _funcionario = new Funcionario();
        private Perfil _perfil = new Perfil();

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
            Close();
            LoginAdvFormWindow view = new LoginAdvFormWindow();
            view.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

            if ((txtPassword.Password == txtRepeatPassword.Password) && (txtPassword.Password != ""))
            {
                _funcionario.NomeFuncionario = txtUsername.Text;
                _funcionario.Email = txtEmail.Text;
                _funcionario.Cpf = txtCpf.Text;
                _funcionario.Rg = txtRg.Text;
                _funcionario.Numero_Inscricao = txtNumeroInscricao.Text;
                _funcionario.Senha = txtPassword.Password;

                try
                {
                    var dao = new FuncionarioDAO();

                    dao.Insert(_funcionario);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                    Close();
                    LoginAdvFormWindow view = new LoginAdvFormWindow();
                    view.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Você informou senhas diferentes nos campos");
            }

        }
    }
}
