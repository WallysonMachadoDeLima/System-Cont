using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Lógica interna para ligacaoPythonTest.xaml
    /// </summary>
    public partial class ligacaoPythonTest : Window
    {
        public ligacaoPythonTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var p = new Process
            {
                StartInfo =
                 {
                     FileName = "main.py",
                     WorkingDirectory = @"D:\IFRO\Projeto Cont\System-Cont\python\",
                 }
            }.Start();
        }
    }
}
