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
    /// Lógica interna para ListHonorairosFormWindow.xaml
    /// </summary>
    public partial class ListHonorairosFormWindow : Window
    {
        public ListHonorairosFormWindow()
        {
            InitializeComponent();
            Loaded += ListHonorarioFormWindow_Loaded;
        }

        private void ListHonorarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new HonorarioDAO();
                List<Honorario> listaHonorario = dao.List();
                dataGridHonorario.ItemsSource = listaHonorario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirHonorario_Click(object sender, RoutedEventArgs e)
        {
            var honorarioSelected = dataGridHonorario.SelectedItem as Honorario;

            var result = MessageBox.Show($"Deseja realmente excluir o Honorário '{honorarioSelected.Descricao}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new HonorarioDAO();
                    dao.Delete(honorarioSelected);
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
