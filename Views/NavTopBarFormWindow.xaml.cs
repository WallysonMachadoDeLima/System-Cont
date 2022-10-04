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

namespace System_Cont.Views
{
    /// <summary>
    /// Lógica interna para NavTopBarFormWindow.xaml
    /// </summary>
    public partial class NavTopBarFormWindow : Window
    {
        public NavTopBarFormWindow()
        {
            InitializeComponent();
            
        }

        private void btnPagInicial_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new PagInicialFormPage();
        }

        private void btnEscritório_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new EscritorioFormPage();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnAjuda_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new AjudaFormPage();
        }

        private void btnGestaoDeDados_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new GestaoDadosFormPage();
            //fraPaginas.Content = new Page1(fraPaginas);
        }

        private void btnForms_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new Aplica();
        }

        private void btnListaCliente_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new ListarCliFormPage();
        }

        private void btnAcessarPerfil_Click(object sender, RoutedEventArgs e)
        {
            fraPaginas.Content = new PerfilAdvFormPage();
        }
    }
}
