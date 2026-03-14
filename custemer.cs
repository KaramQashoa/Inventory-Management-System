using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VewModel;

namespace Karam1
{
    public partial class custemerForm : Form
    {
        public custemerForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer C = new Customer();
            DbCustomer db = new DbCustomer();


            C.Id = int.Parse(textBox1.Text);
            C.FirstName = textBox2.Text;
            C.LastName = textBox3.Text;
            C.Phone = textBox4.Text;
            C.Email = textBox5.Text;
            C.Address = textBox6.Text;
            C.Date = textBox7.Text;
            C.PParticipation = textBox9.Text;
            C.CustomerNum = textBox10.Text;

            db.InsertCustomer(C);
            MessageBox.Show("add sucses");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are You Sure To Delete Customer?", "Delete Customer", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                Customer C = new Customer();
                DbCustomer db = new DbCustomer();
                int i = dataGridView1.CurrentCell.RowIndex;
                C.Id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                db.deletCustomer(C);
                MessageBox.Show("Customer delete succes!!", "Delete!!!");

            }
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
            textBox9.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customer C = new Customer();
            DbCustomer db = new DbCustomer();


            C.Id = int.Parse(textBox1.Text);
            C.FirstName = textBox2.Text;
            C.LastName = textBox3.Text;
            C.Phone = textBox4.Text;
            C.Email = textBox5.Text;
            C.Address = textBox6.Text;
            C.Date = textBox7.Text;
            C.PParticipation = textBox9.Text;
            C.CustomerNum = textBox10.Text;

            db.UpdateCustomer(C);
            MessageBox.Show("update sucses", "update");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DbCustomer db = new DbCustomer();
            Customer C = new Customer();
            //search by id
            if (comboBox1.SelectedIndex == 0)
            {
                C.Id = int.Parse(textBox8.Text);
                if (db.FoundCustomerById(C.Id) == false)
                {
                    MessageBox.Show("This Worker Not Found", "Error");
                    dataGridView1.DataSource = db.SeacrhCustomerById(C.Id).Tables[0];
                }
                else dataGridView1.DataSource = db.SeacrhCustomerById(C.Id).Tables[0];
            }
            //search by name
            if (comboBox1.SelectedIndex == 1)
            {
                C.FirstName = (textBox8.Text);
                if (db.FoundCustomerByName(C.FirstName) == false)
                {
                    MessageBox.Show("This Worker Not Found", "Error");
                    dataGridView1.DataSource = db.SeacrhCustomerByName(C.FirstName).Tables[0];
                }
                else dataGridView1.DataSource = db.SeacrhCustomerByName(C.FirstName).Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCustomer db = new DbCustomer();
            dataGridView1.DataSource = db.GetAllCustomer().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
