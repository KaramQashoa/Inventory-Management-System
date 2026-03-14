using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karam1
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            workerForm frm = new workerForm();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            custemerForm frm = new custemerForm();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
        }
    }
}
