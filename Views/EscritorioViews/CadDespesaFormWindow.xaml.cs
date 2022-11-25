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
    /// Lógica interna para CadDespesaFormWindow.xaml
    /// </summary>
    public partial class CadDespesaFormWindow : Window
    {

        private Despesa _despesa = new Despesa();

        public CadDespesaFormWindow()
        {
            InitializeComponent();
            Loaded += CadDespesaFormWindow_Loaded;
        }

        private void CadDespesaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeDes.Text = _despesa.NomeDes;
            txtDescricaoDes.Text = _despesa.DescricaoDes;
            txtValorDes.Text = Convert.ToString(_despesa.ValorDes);
            dtpDespesa.SelectedDate = _despesa.Data_Despesa;

        }
        private void CarregarListagem()
        {
            try
            {
                var dao2 = new DespesaDAO();
                List<Despesa> listaDespesa = dao2.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvarDespesa_Click(object sender, RoutedEventArgs e)
        {
            _despesa.NomeDes = txtNomeDes.Text;
            _despesa.DescricaoDes = txtDescricaoDes.Text;
            _despesa.ValorDes = Convert.ToDouble(txtValorDes.Text);
            _despesa.Data_Despesa = dtpDespesa.SelectedDate;

            try
            {
                var dao = new DespesaDAO();

                dao.Insert(_despesa);
                MessageBox.Show("Registro Salvo com Sucesso!");

                CarregarListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNomeDes.Clear();
            txtDescricaoDes.Clear();
            txtValorDes.Clear();
            dtpDespesa.SelectedDate = null;
        }
    }
}
