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
    /// Lógica interna para ListDespesaFormWindow.xaml
    /// </summary>
    public partial class ListDespesaFormWindow : Window
    {
        public ListDespesaFormWindow()
        {
            InitializeComponent();
            Loaded += ListDespesaFormWindow_Loaded;
        }

        private void ListDespesaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao2 = new DespesaDAO();
                List<Despesa> listaDespesa = dao2.List();
                dataGridDespesa.ItemsSource = listaDespesa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
