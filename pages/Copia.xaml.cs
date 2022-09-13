using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using Microsoft.Win32;

namespace TESTETOPBAR.pages
{
    /// <summary>
    /// Lógica interna para Copia.xaml
    /// </summary>
    public partial class Copia : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        public Copia()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        void CopyFile (string source, string des)
        {
            FileStream fsOut = new FileStream(des, FileMode.Create);
            FileStream fsin = new FileStream(source, FileMode.Open);
            byte[] bt = new byte[1048756];
            int readBytes;

            while((readBytes = fsOut.Read(bt , 0, bt.Length)) > 0)
                {
                fsOut.Write(bt, 0, readBytes);
                worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }
            fsin.Close();
            fsOut.Close();
        }

        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if(o.ShowDialog() == DialogResult.)
            {

            }
        }
    }
}
