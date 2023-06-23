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
    public partial class Form11 : Form
    {
        SqlConnection sqlConnection;
        public string baseDirectory;
        public string connection;
        public Form11()
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

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Товары". При необходимости она может быть перемещена или удалена.
            //this.товарыTableAdapter.Fill(this.electronicsDBDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Поставки". При необходимости она может быть перемещена или удалена.
            //this.поставкиTableAdapter.Fill(this.electronicsDBDataSet.Поставки);
            baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + baseDirectory + @"\ElectronicsDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставки", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
            DataSet dataSet2 = new DataSet();
            dataAdapter2.Fill(dataSet2);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet.Tables[0];
            dataGridView3.DataSource = dataSet2.Tables[0];
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells[2].Value.ToString() == comboBox1.Text)
                {
                    object obj = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    if (obj != null) comboBox2.Items.Add(obj);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || numericUpDown1.Text == "0" || comboBox2.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (dataGridView3.Rows[i].Cells[1].Value.ToString() == comboBox2.Text)
                    {
                        object s = dataGridView3.Rows[i].Cells[1 + 2].Value.ToString();
                        numericUpDown3.Text = s.ToString();
                        object s2 = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        numericUpDown2.Text = s2.ToString();
                        object s3 = dataGridView3.Rows[i].Cells[1 + 4].Value.ToString();
                        numericUpDown4.Text = s3.ToString();
                    }
                }
                int post = Convert.ToInt32(numericUpDown3.Text);
                int naim = Convert.ToInt32(numericUpDown2.Text);
                int kol = Convert.ToInt32(numericUpDown1.Text);
                int kol_2 = Convert.ToInt32(numericUpDown4.Text);
                int kol_n = kol + kol_2;
                string data = dateTimePicker1.Text;
                SqlCommand command = new SqlCommand($"INSERT INTO Поставки (КодТовара, КодПоставщика, Количество, ДатаПоставки) VALUES ('{naim}','{post}','{kol}','{data}')", sqlConnection);
                command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand($"UPDATE Товары Set Количество = '{kol_n}'  WHERE КодТовара = '{numericUpDown2.Text}'", sqlConnection);
                command2.ExecuteNonQuery();
                MessageBox.Show("Поставка добавлена");
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставки", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet2.Tables[0];
                numericUpDown1.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Text == "0")
            {
                MessageBox.Show("Поле должно быть заполненно");
            }
            else
            {
                string k = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string obj3 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    k = obj3;
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == numericUpDown7.Text)
                    {
                        object s = dataGridView1.Rows[i].Cells[0 + 3].Value.ToString();
                        numericUpDown4.Text = s.ToString();
                        object s2 = dataGridView1.Rows[i].Cells[0 + 1].Value.ToString();
                        numericUpDown2.Text = s2.ToString();
                    }
                }
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (dataGridView3.Rows[i].Cells[0].Value.ToString() == numericUpDown2.Text)
                    {
                        object s = dataGridView3.Rows[i].Cells[0 + 5].Value.ToString();
                        numericUpDown3.Text = s.ToString();
                    }
                }
                int k_old = Convert.ToInt32(numericUpDown3.Text);
                int k_post = Convert.ToInt32(numericUpDown4.Text);
                int k_new = k_old - k_post;
                int x = Convert.ToInt32(k);
                int kol_2 = Convert.ToInt32(numericUpDown7.Text);
                if (x >= kol_2)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Поставки WHERE КодПоставки = @kod", sqlConnection);
                    command.Parameters.AddWithValue("kod", numericUpDown7.Text);
                    command.ExecuteNonQuery();
                    SqlCommand command2 = new SqlCommand($"UPDATE Товары Set Количество = '{k_new}'  WHERE КодТовара = '{numericUpDown2.Text}'", sqlConnection);
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Данные о поставке удалены");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Поставки", sqlConnection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                    DataSet dataSet2 = new DataSet();
                    dataAdapter2.Fill(dataSet2);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView2.DataSource = dataSet.Tables[0];
                    dataGridView3.DataSource = dataSet2.Tables[0];
                }
                else
                {
                    MessageBox.Show("Такой поставки не существует");
                }
            }
        }
    }
}
