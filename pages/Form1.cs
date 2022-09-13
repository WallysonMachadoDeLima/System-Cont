using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTETOPBAR.pages
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ofd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }
    }
}
