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
    /// Lógica interna para ListReuniaoFormWindow.xaml
    /// </summary>
    public partial class ListReuniaoFormWindow : Window
    {
        public ListReuniaoFormWindow()
        {
            InitializeComponent();
            Loaded += ListReuniaoFormWindow_Loaded;
        }

        private void ListReuniaoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ReuniaoDAO();
                List<Reuniao> listaReuniao = dao.List();
                dataGridReuniao.ItemsSource = listaReuniao;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirReuniao_Click(object sender, RoutedEventArgs e)
        {
            var reuniaoSelected = dataGridReuniao.SelectedItem as Reuniao;

            var result = MessageBox.Show($"Deseja realmente excluir a Reuniao '{reuniaoSelected.Tema}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ReuniaoDAO();
                    dao.Delete(reuniaoSelected);
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
