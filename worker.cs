using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using VewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Karam1
{
    public partial class workerForm : Form
    {
        public workerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db=new DbWorker();
            dataGridView1.DataSource = db.GetAllWorkers().Tables[0];
        }

        private void Id_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are You Sure To Delete worker?", "Delete worker", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                Worker w = new Worker();
                DbWorker db = new DbWorker();
                int i = dataGridView1.CurrentCell.RowIndex;
                w.Id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                db.deletWorker(w);
                MessageBox.Show("worker delete succes!!", "Delete!!!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Worker W = new Worker();
            DbWorker db = new DbWorker();


            W.Id = int.Parse(textBox1.Text);
            W.FirstName = textBox2.Text;
            W.LastName = textBox3.Text;
            W.Phone = textBox4.Text;
            W.Email = textBox5.Text;
            W.City = textBox6.Text;
            W.Sallary = int.Parse(textBox7.Text);

            db.InsertWorker(W);
            MessageBox.Show("add sucses");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Worker W = new Worker();
            DbWorker db = new DbWorker();


            W.Id = int.Parse(textBox1.Text);
            W.FirstName = textBox2.Text;
            W.LastName = textBox3.Text;
            W.Phone = textBox4.Text;
            W.Email = textBox5.Text;
            W.City = textBox6.Text;
            W.Sallary = int.Parse(textBox7.Text);

            db.UpdateWorker(W);
            MessageBox.Show("update sucses","update");




        }

        private void button6_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            Worker w = new Worker();
            //search by id
            if (comboBox1.SelectedIndex == 0)
            {
                w.Id = int.Parse(textBox8.Text);
                if (db.FoundWorkerById(w.Id) == false)
                {
                    MessageBox.Show("This Worker Not Found", "Error");
                    dataGridView1.DataSource = db.SeacrhWorkerById(w.Id).Tables[0];
                }
                else dataGridView1.DataSource = db.SeacrhWorkerById(w.Id).Tables[0];
            }
            //search by name
            if (comboBox1.SelectedIndex == 1)
            {
                w.FirstName = (textBox8.Text);
                if (db.FoundWorkerByName(w.FirstName) == false)
                {
                    MessageBox.Show("This Worker Not Found", "Error");
                    dataGridView1.DataSource = db.SeacrhWorkerByName(w.FirstName).Tables[0];
                }
                else dataGridView1.DataSource = db.SeacrhWorkerByName(w.FirstName).Tables[0];
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
