using Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VewModel;

namespace Karam1
{
    public partial class ProductForm : Form
    {
        byte[] ImageData = null;
        public ProductForm()
        {
            InitializeComponent();
        }

        public byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void product_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                product p =new product();


                
                Dbproduct db = new Dbproduct();
                p.Id = int.Parse(textBox1.Text);
                p.Name = textBox2.Text;
                p.GB = int.Parse(textBox6.Text);
                p.Price = int.Parse(textBox3.Text);
                p.Color = textBox4.Text;
                p.Quantity = int.Parse(textBox7.Text);
                p.image = ImageData;
                int add = db.InsertProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                MessageBox.Show("Added Successfully ", "Insert");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are You Sure To Delete Product?", "Delete Product", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                product p = new product();
                Dbproduct db = new Dbproduct();
                int i = dataGridView1.CurrentCell.RowIndex;
                p.Id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                db.DeleteProduct(p);
                MessageBox.Show("Product Delete Succes!!", "Delete!!!");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            byte[] data = (byte[])dataGridView1.Rows[i].Cells[5].Value;
            MemoryStream ms = new MemoryStream(data);
            Picture.Image = Image.FromStream(ms);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dbproduct db = new Dbproduct();
            product p = new product();

            //search by id
            if (comboBox3.SelectedIndex == 0)
            {
                p.Id = int.Parse(textBox5.Text);
                if (!db.FoundProductById(p.Id))
                {
                    MessageBox.Show("This Product Not Found", "Error");
                }

                dataGridView1.DataSource = db.SeacrhProductsById(p.Id); 
            }
            //search by name
            if (comboBox3.SelectedIndex == 1)
            {
                p.Name = (textBox5.Text);
                if (!db.FoundProductByName(p.Name))
                {
                    MessageBox.Show("This Product Not Found", "Error");

                }
                dataGridView1.DataSource = db.SeacrhProductByName(p.Name).Tables[0];
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Title = "C# - Select photo for Product";
            fdialog.InitialDirectory = @"c:\";
            fdialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                ImageData = ReadFile(fdialog.FileName);
                Picture.ImageLocation = fdialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dbproduct db = new Dbproduct();
            dataGridView1.DataSource = db.GetAllProduct().Tables[0];
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
