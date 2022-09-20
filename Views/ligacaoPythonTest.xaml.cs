using IronPython.Hosting;
using System;
using System.Collections.Generic;
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
        static void testePython()
        {
            var engine = Python.CreateEngine();

            var script = @"D:\IFRO\Projeto Cont\python\main.py";
            var source = engine.CreateScriptSourceFromFile(script);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1) Create engine
            var engine = Python.CreateEngine();

            // 2) Provide script and arguments
            var script = @"C:\Users\rafag\Music\RunPythonScriptFromCS\DaysBetweenDates.py";
            var source = engine.CreateScriptSourceFromFile(script);

            var argv = new List<string>();
            argv.Add("");
            argv.Add("2019-1-1");
            argv.Add("2019-1-22");

            engine.GetSysModule().SetVariable("argv", argv);

            // 3) Output redirect
            var eIO = engine.Runtime.IO;

            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);

            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);

            // 4) Execute script
            var scope = engine.CreateScope();
            source.Execute(scope);

            // 5) Display output
            string str(byte[] x) => Encoding.Default.GetString(x);

            tbxReceba.Text = Convert.ToString(argv[0]);
            Console.WriteLine("ERRORS:");
            Console.WriteLine(str(errors.ToArray()));
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(str(results.ToArray()));
        }
    }
}
