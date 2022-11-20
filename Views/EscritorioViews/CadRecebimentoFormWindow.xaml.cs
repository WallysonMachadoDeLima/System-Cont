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
    /// Lógica interna para CadRecebimentoFormWindow.xaml
    /// </summary>
    public partial class CadRecebimentoFormWindow : Window
    {

        private Recebimento _recebimento = new Recebimento();

        public CadRecebimentoFormWindow()
        {
            InitializeComponent();
            Loaded += CadRecebimentoFormWindow_Loaded;
        }

        private void CadRecebimentoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDescricaoRec.Text = _recebimento.DescricaoRec;
            txtValorRec.Text = Convert.ToString(_recebimento.ValorRec);
            dtpRecebimento.SelectedDate = _recebimento.Data_Recebimento;
        }

        private void btnSalvarRecebimento_Click(object sender, RoutedEventArgs e)
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
    }
}
