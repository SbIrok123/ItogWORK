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
    public partial class Form5 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["furniStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"select name,ProductType,Price from Products where ProductType=N'{textBox1.Text}'",
            sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"select count(ProductID) from Orders where ProductID={textBox7.Text} and (OrderDate between N'{textBox2.Text}' and N'{textBox3.Text}')",
            sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"select * from Orders where DeliveryDate between N'{textBox5.Text}' and N'{textBox4.Text}' ",
            sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"SELECT (SELECT Name FROM Customers WHERE CustomerID = Orders.CustomerID) AS Customer_Name,SUM(Quantity * P.Price) AS Total FROM Orders JOIN Products P ON Orders.ProductID = P.ProductID where CustomerID={textBox6.Text} GROUP BY Orders.CustomerID;",
            sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
