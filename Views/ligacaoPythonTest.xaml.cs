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
        /*  
         *              ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile(@"D:\IFRO\Projeto Cont\python\main.py");
         *  
                    var engine = Python.CreateEngine();

            var script = @"D:\IFRO\Projeto Cont\python\main.py";
            var source = engine.CreateScriptSourceFromFile(script);

            var scope = engine.CreateScope();
            source.Execute(scope);

        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var p = new Process
            {
                StartInfo =
                 {
                     FileName = "main.py",
                     WorkingDirectory = @"D:\IFRO\Projeto Cont\python\",
                 }
            }.Start();
        }
    }
}
