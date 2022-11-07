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
        }


        private void btnAdcMovimentacao_Click(object sender, RoutedEventArgs e)
        {
            CadMovimentacaoFormWindow view = new CadMovimentacaoFormWindow();
            view.ShowDialog();
        }

        private void btnListRecebimento_Click(object sender, RoutedEventArgs e)
        {
            EscritorioViews.ListRecebimentoFormWindow view = new EscritorioViews.ListRecebimentoFormWindow();
            view.ShowDialog();
        }
    }
}
