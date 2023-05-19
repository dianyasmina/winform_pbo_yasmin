using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace winform_pbo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=pbo_CRUD; User Id=postgres; Password=Tyoganteng1"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update toko_yasmin set nama_barang=@nama_barang,harga=@harga where id_barang=@id_barang";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id_barang", textBox1.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@nama_barang", textBox2.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@harga", textBox3.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Data berhasil diperbarui");
                }
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=pbo_CRUD; User Id=postgres; Password=Tyoganteng1"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Delete from toko_yasmin where id_barang=@id_barang";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id_barang", textBox1.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    textBox1.Text = "";
                    MessageBox.Show("Data berhasil dihapus");
                }
            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=pbo_CRUD; User Id=postgres; Password=Tyoganteng1"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from toko_yasmin";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=pbo_CRUD; User Id=postgres; Password=Tyoganteng1"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into toko_yasmin values (@id_barang,@nama_barang,@harga)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id_barang", textBox1.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@nama_barang", textBox2.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@harga", textBox3.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Data berhasil diinput");
                }
            }
            catch (Exception ex) { }
        }
    }
}