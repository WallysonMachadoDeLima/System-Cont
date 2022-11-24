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

namespace System_Cont.Views.EscritorioViews
{
    /// <summary>
    /// Lógica interna para CadProcessoFormWindow.xaml
    /// </summary>
    public partial class CadProcessoFormWindow : Window
    {

        private Processo _processo = new Processo();

        public CadProcessoFormWindow()
        {
            InitializeComponent();
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();
                var dao2 = new FuncionarioDAO();
                List<Funcionario> listaFuncionario = dao2.List();

                cmbCliente.ItemsSource = listaClientes;
                cmbFuncionario.ItemsSource = listaFuncionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvarPro_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCliente.SelectedItem != null)
            {
                _processo.Cliente = cmbCliente.SelectedItem as Cliente;
            }
            if (cmbFuncionario.SelectedItem != null)
            {
                _processo.Funcionario = cmbFuncionario.SelectedItem as Funcionario;
            }

            _processo.NumeroProcesso = txtNumeroProcesso.Text;
            _processo.ClienteProcesso = cmbCliente.Text;
            _processo.ResponsavelProcesso = cmbFuncionario.Text;
            _processo.Status = txtStatusPro.Text;
            _processo.Tipo = txtTipoPro.Text;

            try
            {
                var dao = new ProcessoDAO();

                dao.Insert(_processo);
                MessageBox.Show("Registro Salvo com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimparPro_Click(object sender, RoutedEventArgs e)
        {
            txtNumeroProcesso.Clear();
            cmbCliente.Text = null;
            cmbFuncionario.Text = null;
            txtTipoPro.Clear();
            txtStatusPro.Clear();
        }
    }
}
