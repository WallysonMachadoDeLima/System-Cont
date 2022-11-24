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
using System_Cont.Models;

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
            try
            {
                
                var dao = new FuncionarioDAO();

                if (dao.Login(txtNomeFuncionario.Text, txtSenha.Password) == "Yes")
                {
                    Close();
                    NavTopBarFormWindow view = new NavTopBarFormWindow();
                    view.ShowDialog();
                    var metod = new MainWindow();
                    metod.VerifyLogin(dao.Login(txtNomeFuncionario.Text, txtSenha.Password));
                }
                else
                {
                    
                    MessageBox.Show("Login Incorreto!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnNoAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
            CadastroAdvFormWindow view = new CadastroAdvFormWindow();
            view.ShowDialog();
        }      
    }
}
