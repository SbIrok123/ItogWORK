using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace ItogWORK
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["furniStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            "select * from Products",
            sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
            $"INSERT INTO [Products] (Name, ProductType, Price, QuantityInStock) VALUES (N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}', N'{textBox4.Text}')",
            sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Products] SET ProductType= @NewName WHERE ProductID = @CustomerID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox5.Text);
            command.Parameters.AddWithValue("@CustomerID", textBox9.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Замінено");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Products] SET Name= @NewName WHERE ProductID = @CustomerID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox6.Text);
            command.Parameters.AddWithValue("@CustomerID", textBox9.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Замінено");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Products] SET Price= @NewName WHERE ProductID = @CustomerID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox8.Text);
            command.Parameters.AddWithValue("@CustomerID", textBox9.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Замінено");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Products] SET QuantityInStock= @NewName WHERE ProductID = @CustomerID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox7.Text);
            command.Parameters.AddWithValue("@CustomerID", textBox9.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Замінено");
            }
        }
    }
}
