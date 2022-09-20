using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTETOPBAR.pages
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Spacecraft", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void populete()
        {
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(100, 100);

            String[] paths = { };
            paths = Directory.GetFiles("C:\\Users\\macha\\OneDrive\\Imagens\\img");

            try
            {
                foreach(String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            {
                listView1.SmallImageList = imgs;
                listView1.Items.Add("mapa", 0);
                listView1.Items.Add("mapa", 1);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populete();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = listView1.SelectedItems[0].ToString();
            MessageBox.Show(selected);
        }
    }
}
