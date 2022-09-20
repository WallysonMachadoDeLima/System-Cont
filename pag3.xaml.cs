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
using TESTETOPBAR.pages;

namespace TESTETOPBAR
{
    /// <summary>
    /// Lógica interna para pag3.xaml
    /// </summary>
    public partial class pag3 : Window
    {
        public pag3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow open = new MainWindow();
            open.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pag1 open = new pag1();
            open.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Copia open = new Copia();
            open.ShowDialog();
        }

        private void Button_Click_LIST(object sender, RoutedEventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
