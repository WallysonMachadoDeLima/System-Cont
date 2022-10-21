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
    /// Lógica interna para CadMovimentacaoFormWindow.xaml
    /// </summary>
    public partial class CadMovimentacaoFormWindow : Window
    {

        private Despesa _despesa = new Despesa();
        private Recebimento _recebimento = new Recebimento();

        public CadMovimentacaoFormWindow()
        {
            InitializeComponent();
            CarregarListagem();
            Loaded += CadastroMovimentacao_Loaded;
        }

        private void CadastroMovimentacao_Loaded(object sender, RoutedEventArgs e)
        {
            txtDescricaoDes.Text = _despesa.DescricaoDes;
            txtValorDes.Text = Convert.ToString(_despesa.ValorDes);
            dtpDespesa.SelectedDate = _despesa.Data_Despesa;

            txtDescricaoRec.Text = _recebimento.DescricaoRec;
            txtValorRec.Text = Convert.ToString(_recebimento.ValorRec);
            dtpRecebimento.SelectedDate = _recebimento.Data_Recebimento;

        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new RecebimentoDAO();
                List<Recebimento> listaRecebimento = dao.List();

                var dao2 = new DespesaDAO();
                List<Despesa> listaDespesa = dao2.List();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        private void btnSalvarRec_Click_1(object sender, RoutedEventArgs e)
        {
            _recebimento.DescricaoRec = txtDescricaoRec.Text;
            _recebimento.ValorRec = Convert.ToDouble(txtValorRec.Text);
            _recebimento.Data_Recebimento = dtpRecebimento.SelectedDate;

            try
            {
                var dao = new RecebimentoDAO();

                dao.Insert(_recebimento);
                MessageBox.Show("Registro Salvo com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvarDes_Click_1(object sender, RoutedEventArgs e)
        {
            _despesa.DescricaoDes = txtDescricaoDes.Text;
            _despesa.ValorDes = Convert.ToDouble(txtValorDes.Text);
            _despesa.Data_Despesa = dtpDespesa.SelectedDate;

            try
            {
                var dao = new DespesaDAO();

                dao.Insert(_despesa);
                MessageBox.Show("Registro Salvo com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
