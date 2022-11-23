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

        private void btnAdcProcesso_Click(object sender, RoutedEventArgs e)
        {
            CadProcessoFormWindow view = new CadProcessoFormWindow();
            view.ShowDialog();
        }

        private void btnAdcReuniao_Click(object sender, RoutedEventArgs e)
        {
            CadReunioesFormWindow view = new CadReunioesFormWindow();
            view.ShowDialog();
        }

        private void btnAdcPagamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListProcesso_Click(object sender, RoutedEventArgs e)
        {
            ListProcessoFormWindow view = new ListProcessoFormWindow();
            view.ShowDialog();
        }
    }
}
