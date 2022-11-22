using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System_Cont.Models;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para CadastroCliFormPage.xam
    /// </summary>
    public partial class CadastroCliFormPage : Page
    {
        private Cliente _cliente = new Cliente();
        private Frame fraPaginas;

        public CadastroCliFormPage(Frame _frame)
        {
            InitializeComponent();
            CarregarListagem();
            Loaded += CadastroCliente_Loaded;
            fraPaginas = _frame;
        }

        public CadastroCliFormPage(Cliente cliente, Frame _frame)
        {
            InitializeComponent();
            fraPaginas = _frame;
            Loaded += CadastroCliente_Loaded;
            CarregarListagem();
            _cliente = cliente;
        }


        private void CadastroCliente_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCli.Text = _cliente.NomeCliente;
            txtTelefoneCli.Text = _cliente.Telefone;
            txtRgCli.Text = _cliente.Rg;
            txtCpfCli.Text = _cliente.Cpf;
            txtNacionalidadeCli.Text = _cliente.Nacionalidade;
            txtRendaCli.Text = _cliente.Renda;
            txtEmailCli.Text = _cliente.Email;
            txtLocalCli.Text = _cliente.Local;
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalvarCliente_Click(object sender, RoutedEventArgs e)
        {
            _cliente.NomeCliente = txtNomeCli.Text;
            _cliente.Telefone = txtTelefoneCli.Text;
            _cliente.Rg = txtRgCli.Text;
            _cliente.Cpf = txtCpfCli.Text;
            _cliente.Nacionalidade = txtNacionalidadeCli.Text;
            _cliente.Renda = txtRendaCli.Text;
            _cliente.Email = txtEmailCli.Text;
            _cliente.Local = txtLocalCli.Text;

            try
            {
                var dao = new ClienteDAO();

                if (_cliente.Id > 0)
                {
                    dao.Update(_cliente);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_cliente);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnVoltarListCliente_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new ListarCliFormPage(fraPaginas);
        }
    }
}
