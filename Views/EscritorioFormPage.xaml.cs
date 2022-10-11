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
using System_Cont.Models;
using System_Cont.Views;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para EscritorioFormPage.xam
    /// </summary>
    public partial class EscritorioFormPage : Page
    {
        public EscritorioFormPage()
        {
            InitializeComponent();
            Loaded += EscritorioFormPage_Loaded;
        }

        private void EscritorioFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new RecebimentoDAO();
                List<Recebimento> listaRecebimento = dao.List();
                dataGridRecebimento.ItemsSource = listaRecebimento;

                var dao2 = new DespesaDAO();
                List<Despesa> listaDespesa = dao2.List();
                dataGridDespesa.ItemsSource = listaDespesa;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirRecebimento_Click(object sender, RoutedEventArgs e)
        {
            var recebimentoSelected = dataGridRecebimento.SelectedItem as Recebimento;

            var result = MessageBox.Show($"Deseja realmente excluir o Recebimento '{recebimentoSelected.DescricaoRec}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new RecebimentoDAO();
                    dao.Delete(recebimentoSelected);
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluirDespesa_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelected = dataGridDespesa.SelectedItem as Despesa;

            var result = MessageBox.Show($"Deseja realmente excluir a Despesa '{despesaSelected.DescricaoDes}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao2 = new DespesaDAO();
                    dao2.Delete(despesaSelected);
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdcMovimentacao_Click(object sender, RoutedEventArgs e)
        {
            CadMovimentacaoFormWindow view = new CadMovimentacaoFormWindow();
            view.ShowDialog();
        }
    }
}
