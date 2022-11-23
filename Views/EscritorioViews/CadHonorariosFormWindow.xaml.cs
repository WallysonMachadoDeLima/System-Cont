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
    /// Lógica interna para CadHonorariosFormWindow.xaml
    /// </summary>
    public partial class CadHonorariosFormWindow : Window
    {

        private Honorario _honorario = new Honorario();

        public CadHonorariosFormWindow()
        {
            InitializeComponent();
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new HonorarioDAO();
                List<Honorario> listaHonorario = dao.List();

                cmbNumeroProcesso.ItemsSource = listaHonorario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvarHon_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNumeroProcesso.SelectedItem != null)
            {
                _honorario.Processo = cmbNumeroProcesso.SelectedItem as Processo;
            }
            _honorario.NumeroProcesso = cmbNumeroProcesso.Text;
            _honorario.Descricao = txtDescricaoHon.Text;
            _honorario.DataHonorario = dtpHonorarios.SelectedDate;

            try
            {
                var dao = new HonorarioDAO();

                dao.Insert(_honorario);
                MessageBox.Show("Registro Salvo com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
