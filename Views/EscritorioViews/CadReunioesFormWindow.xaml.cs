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
    /// Lógica interna para CadReunioesFormWindow.xaml
    /// </summary>
    public partial class CadReunioesFormWindow : Window
    {

        private Reuniao _reuniao = new Reuniao();

        public CadReunioesFormWindow()
        {
            InitializeComponent();
            Loaded += CadReunioesFormWindow_Loaded;
        }
        private void CadReunioesFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatusReu.Text = _reuniao.Status;
            txtTemaReu.Text = _reuniao.Tema;
            dtpReunioes.SelectedDate = _reuniao.DataReuniao;
            
            tpHorarioIniReu.SelectedTime = _reuniao.HorarioIncio;
            tpHorarioTerReu.SelectedTime = _reuniao.HorarioTermino;

        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new ReuniaoDAO();
                List<Reuniao> listaReuniao = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvarReu_Click(object sender, RoutedEventArgs e)
        {
            _reuniao.Tema = txtTemaReu.Text;
            _reuniao.Status = txtStatusReu.Text;
            _reuniao.DataReuniao = dtpReunioes.SelectedDate;
            _reuniao.HorarioIncio = tpHorarioIniReu.SelectedTime;
            _reuniao.HorarioTermino = tpHorarioTerReu.SelectedTime;

            try
            {
                var dao = new ReuniaoDAO();

                dao.Insert(_reuniao);
                MessageBox.Show("Registro Salvo com Sucesso!");
                CarregarListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimparReu_Click(object sender, RoutedEventArgs e)
        {
            txtTemaReu.Clear();
            txtStatusReu.Clear();
            dtpReunioes.SelectedDate = null;
            tpHorarioIniReu = null;
            tpHorarioTerReu = null;
        }
    }
}
