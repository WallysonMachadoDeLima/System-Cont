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
    /// Lógica interna para ListProcessoFormWindow.xaml
    /// </summary>
    public partial class ListProcessoFormWindow : Window
    {
        public ListProcessoFormWindow()
        {
            InitializeComponent();
            Loaded += ListProcessoFormWindow_Loaded;
        }

        private void ListProcessoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ProcessoDAO();
                List<Processo> listaProcesso = dao.List();
                dataGridProcesso.ItemsSource = listaProcesso;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirProcesso_Click(object sender, RoutedEventArgs e)
        {
            var processoSelected = dataGridProcesso.SelectedItem as Processo;

            var result = MessageBox.Show($"Deseja realmente excluir o Processo '{processoSelected.NumeroProcesso}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ProcessoDAO();
                    dao.Delete(processoSelected);
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
