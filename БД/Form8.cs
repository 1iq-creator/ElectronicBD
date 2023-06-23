using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace БД
{
    public partial class Form8 : Form
    {
        SqlConnection sqlConnection;
        public string baseDirectory;
        public string connection;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Поставщики". При необходимости она может быть перемещена или удалена.
            //this.поставщикиTableAdapter.Fill(this.electronicsDBDataSet.Поставщики);
            baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + baseDirectory + @"\ElectronicsDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet.Tables[0];
            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                string naim = textBox1.Text;
                string tel = maskedTextBox1.Text;
                SqlCommand command = new SqlCommand($"INSERT INTO Поставщики (НазваниеПоставщика, Телефон) VALUES (N'{naim}', '{tel}')", sqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Поставщик добавлен");
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                textBox1.Text = "";
                maskedTextBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || maskedTextBox2.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                string s = dataGridView2.CurrentCell.Value.ToString();
                SqlCommand command = new SqlCommand($"UPDATE Поставщики Set НазваниеПоставщика = N'{textBox2.Text}' WHERE КодПоставщика = '{s}'", sqlConnection);
                command.ExecuteNonQuery();
                SqlCommand command4 = new SqlCommand($"UPDATE Поставщики Set Телефон = '{maskedTextBox2.Text}'  WHERE КодПоставщика = '{s}'", sqlConnection);
                command4.ExecuteNonQuery();
                MessageBox.Show("Данные о поставщике изменены");
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                textBox2.Text = "";
                maskedTextBox2.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "0")
            {
                MessageBox.Show("Поле должно быть заполненно");
            }
            else
            {
                string k = "";
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    string obj3 = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    k = obj3;
                }
                int x = Convert.ToInt32(k);
                int kol_2 = Convert.ToInt32(numericUpDown1.Text);
                if (x >= kol_2)
                {
                SqlCommand command = new SqlCommand("DELETE FROM Поставщики WHERE КодПоставщика = @kod", sqlConnection);
                command.Parameters.AddWithValue("kod", numericUpDown1.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о поставщике удалены");
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                }
                else
                {
                    MessageBox.Show("Такого поставщика не существует");
                }
            }
        }
    }
}