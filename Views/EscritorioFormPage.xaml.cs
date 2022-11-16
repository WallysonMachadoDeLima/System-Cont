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
using System_Cont.Views.EscritorioViews;

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
        }


        private void btnAdcMovimentacao_Click(object sender, RoutedEventArgs e)
        {
            CadMovimentacaoFormWindow view = new CadMovimentacaoFormWindow();
            view.ShowDialog();
        }

        private void btnListRecebimento_Click(object sender, RoutedEventArgs e)
        {
            ListRecebimentoFormWindow view = new ListRecebimentoFormWindow();
            view.ShowDialog();
        }
        private void btnAdcRecebimento_Click(object sender, RoutedEventArgs e)
        {
            CadRecebimentoFormWindow view = new CadRecebimentoFormWindow();
            view.ShowDialog();
        }

        private void btnListDespesa_Click(object sender, RoutedEventArgs e)
        {
            ListDespesaFormWindow view = new ListDespesaFormWindow();
            view.ShowDialog();
        }

        private void btnAdcDespesa_Click(object sender, RoutedEventArgs e)
        {
            CadDespesaFormWindow view = new CadDespesaFormWindow();
            view.ShowDialog();
        }
    }
}
