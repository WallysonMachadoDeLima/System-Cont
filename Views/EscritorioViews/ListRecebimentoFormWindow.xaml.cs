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
    /// Lógica interna para ListRecebimentoFormWindow.xaml
    /// </summary>
    public partial class ListRecebimentoFormWindow : Window
    {
        public ListRecebimentoFormWindow()
        {
            InitializeComponent();
            Loaded += ListRecebimentoFormWindow_Loaded;
        }

        private void ListRecebimentoFormWindow_Loaded(object sender, RoutedEventArgs e)
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
    }
}
