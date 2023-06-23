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
    public partial class Form5 : Form
    {
        SqlConnection sqlConnection;
        public string baseDirectory;
        public string connection;
        public Form5()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            //this.клиентыTableAdapter.Fill(this.electronicsDBDataSet.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            //this.заказыTableAdapter.Fill(this.electronicsDBDataSet1.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            //this.заказыTableAdapter.Fill(this.electronicsDBDataSet1.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Производитель". При необходимости она может быть перемещена или удалена.
            //this.производительTableAdapter.Fill(this.electronicsDBDataSet.Производитель);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Поставщики". При необходимости она может быть перемещена или удалена.
            //this.поставщикиTableAdapter.Fill(this.electronicsDBDataSet.Поставщики);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Товары". При необходимости она может быть перемещена или удалена.
            // this.товарыTableAdapter.Fill(this.electronicsDBDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            // this.заказыTableAdapter.Fill(this.electronicsDBDataSet.Заказы);
            baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + baseDirectory + @"\ElectronicsDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Заказы", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
            DataSet dataSet2 = new DataSet();
            dataAdapter2.Fill(dataSet2);

            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView3.DataSource = dataSet.Tables[0];
            dataGridView4.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet2.Tables[0];
            dataGridView10.DataSource = dataSet2.Tables[0];
            dataGridView7.DataSource = dataSet.Tables[0];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                object obj = dataGridView2.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox1.Items.Add(obj);
            }   
            for (int i = 0; i < dataGridView10.Rows.Count; i++)
            {
                object obj = dataGridView10.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox8.Items.Add(obj);
            }
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || numericUpDown1.Text == "0" || comboBox10.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == comboBox1.Text)
                    {
                        object s = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        numericUpDown4.Text = s.ToString();
                    }
                }               
                int naim = Convert.ToInt32(numericUpDown4.Text);
                int f_r = Convert.ToInt32(numericUpDown10.Text);
                int f_s = Convert.ToInt32(numericUpDown11.Text);
                string data = dateTimePicker1.Text;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == comboBox1.Text)
                    {
                        object s = dataGridView2.Rows[i].Cells[1 + 5].Value.ToString();
                        numericUpDown2.Text = s.ToString();
                    }
                }
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == comboBox1.Text)
                    {
                        object s2 = dataGridView2.Rows[i].Cells[1 + 4].Value.ToString();
                        numericUpDown3.Text = s2.ToString();
                    }
                }
                int kol = Convert.ToInt32(numericUpDown1.Text);
                int kol_2 = Convert.ToInt32(numericUpDown3.Text);
                int sum = Convert.ToInt32(numericUpDown2.Text);
                int sum_z = Convert.ToInt32(numericUpDown2.Text);
                int kol_3 = kol_2 - kol;
                sum_z = kol * sum;
                if (kol < kol_2)
                {

                    SqlCommand command = new SqlCommand($"INSERT INTO Заказы (КодТовара, ДатаПокупки, Количество, ЦенаТовара, СуммаЗаказа) VALUES ('{naim}', '{data}', '{kol}', '{sum}', '{sum_z}')", sqlConnection);
                    command.ExecuteNonQuery();
                    SqlCommand command2 = new SqlCommand($"UPDATE Товары Set Количество = '{kol_3}'  WHERE Наименование = N'{comboBox1.Text}'", sqlConnection);
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Заказы", sqlConnection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                    DataSet dataSet2 = new DataSet();
                    dataAdapter2.Fill(dataSet2);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView3.DataSource = dataSet.Tables[0];
                    dataGridView4.DataSource = dataSet.Tables[0];
                    dataGridView2.DataSource = dataSet2.Tables[0];
                    dataGridView10.DataSource = dataSet2.Tables[0];
                    comboBox1.Text = "";
                    comboBox10.Text = "";
                    numericUpDown1.Text = "0";
                    numericUpDown2.Text = "0";
                    numericUpDown3.Text = "0";
                }
                else
                {
                    MessageBox.Show("Товар закончился");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "" || numericUpDown8.Text == "0" || comboBox9.Text =="")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == comboBox8.Text)
                    {
                        object s = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        numericUpDown4.Text = s.ToString();
                    }
                }                
                for (int i = 0; i < dataGridView10.Rows.Count; i++)
                {
                    if (dataGridView10.Rows[i].Cells[1].Value.ToString() == comboBox8.Text)
                    {
                        object s = dataGridView10.Rows[i].Cells[1 + 5].Value.ToString();
                        numericUpDown5.Text = s.ToString();
                    }
                }
                for (int i = 0; i < dataGridView10.Rows.Count; i++)
                {
                    if (dataGridView10.Rows[i].Cells[1].Value.ToString() == comboBox8.Text)
                    {
                        object s2 = dataGridView10.Rows[i].Cells[1 + 4].Value.ToString();
                        numericUpDown6.Text = s2.ToString();
                    }
                }
                int kol = Convert.ToInt32(numericUpDown8.Text);
                int kol_2 = Convert.ToInt32(numericUpDown6.Text);
                int sum = Convert.ToInt32(numericUpDown5.Text);
                int sum_z = Convert.ToInt32(numericUpDown5.Text);
                sum_z = kol * sum;
                if (kol < kol_2)
                {
                    string s = dataGridView3.CurrentCell.Value.ToString();
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (dataGridView3.Rows[i].Cells[0].Value.ToString() == s)
                        {
                            object s2 = dataGridView3.Rows[i].Cells[0 + 5].Value.ToString();
                            numericUpDown9.Text = s2.ToString();
                        }
                    }
                    int kol_3 = Convert.ToInt32(numericUpDown9.Text);
                    if (kol > kol_3)
                    {
                        kol_3 = kol_2 - (kol - kol_3);
                    }
                    else if (kol < kol_3)
                    {
                        kol_3 = kol_2 + (kol_3 - kol);
                    }
                    else if (kol == kol_3)
                    {
                        kol_3 = kol_2;
                    }
                    SqlCommand command2 = new SqlCommand($"UPDATE Товары Set Количество = '{kol_3}'  WHERE Наименование = N'{comboBox8.Text}'", sqlConnection);
                    command2.ExecuteNonQuery();
                    SqlCommand command = new SqlCommand($"UPDATE Заказы Set КодТовара = '{numericUpDown4.Text}' WHERE КодЗаказа = '{s}'", sqlConnection);
                    command.ExecuteNonQuery();
                    SqlCommand command5 = new SqlCommand($"UPDATE Заказы Set ДатаПокупки = '{dateTimePicker2.Text}' WHERE КодЗаказа = '{s}'", sqlConnection);
                    command5.ExecuteNonQuery();
                    SqlCommand command6 = new SqlCommand($"UPDATE Заказы Set Количество = '{kol}' WHERE КодЗаказа = '{s}'", sqlConnection);
                    command6.ExecuteNonQuery();
                    SqlCommand command8 = new SqlCommand($"UPDATE Заказы Set ЦенаТовара = '{sum}' WHERE КодЗаказа = '{s}'", sqlConnection);
                    command8.ExecuteNonQuery();
                    SqlCommand command7 = new SqlCommand($"UPDATE Заказы Set СуммаЗаказа = '{sum_z}' WHERE КодЗаказа = '{s}'", sqlConnection);
                    command7.ExecuteNonQuery();
                    MessageBox.Show("Информация о заказе изменена");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Заказы", sqlConnection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                    DataSet dataSet2 = new DataSet();
                    dataAdapter2.Fill(dataSet2);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView3.DataSource = dataSet.Tables[0];
                    dataGridView4.DataSource = dataSet.Tables[0];
                    dataGridView2.DataSource = dataSet2.Tables[0];
                    dataGridView10.DataSource = dataSet2.Tables[0];
                    comboBox8.Text = "";
                    comboBox9.Text = "";
                    numericUpDown5.Text = "0";
                    numericUpDown6.Text = "0";
                    numericUpDown8.Text = "0";
                }
                else
                {
                    MessageBox.Show("Товар закончился");
                }
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
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    string obj3 = dataGridView4.Rows[i].Cells[0].Value.ToString();
                    k = obj3;
                }
                int x = Convert.ToInt32(k);
                int kol_2 = Convert.ToInt32(numericUpDown7.Text);
                if (x >= kol_2)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Заказы WHERE КодЗаказа = @kod", sqlConnection);
                    command.Parameters.AddWithValue("kod", numericUpDown7.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные о заказе удалены");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Заказы", sqlConnection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                    DataSet dataSet2 = new DataSet();
                    dataAdapter2.Fill(dataSet2);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView3.DataSource = dataSet.Tables[0];
                    dataGridView4.DataSource = dataSet.Tables[0];
                    dataGridView2.DataSource = dataSet2.Tables[0];
                    dataGridView10.DataSource = dataSet2.Tables[0];
                }
                else
                { 
                    MessageBox.Show("Такого заказа не существует");  
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox7.SelectedIndex)
            {
                case 0:
                    (dataGridView7.DataSource as DataTable).DefaultView.RowFilter = $"СуммаЗаказа <= 30000";
                    break;
                case 1:
                    (dataGridView7.DataSource as DataTable).DefaultView.RowFilter = $"СуммаЗаказа >= 30000 AND СуммаЗаказа <= 100000";
                    break;
                case 2:
                    (dataGridView7.DataSource as DataTable).DefaultView.RowFilter = $"СуммаЗаказа >= 100000";
                    break;
                case 3:
                    (dataGridView7.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;


            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[2].Value.ToString() == comboBox9.Text)
                {
                    object obj = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    if (obj != null) comboBox8.Items.Add(obj);
                }
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[2].Value.ToString() == comboBox10.Text)
                {
                    object obj = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    if (obj != null) comboBox1.Items.Add(obj);
                }
            }
        }
    }
}