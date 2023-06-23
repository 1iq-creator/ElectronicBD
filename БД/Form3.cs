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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public string baseDirectory;
        public string connection;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Производитель". При необходимости она может быть перемещена или удалена.
            //this.производительTableAdapter.Fill(this.electronicsDBDataSet.Производитель);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Поставщики". При необходимости она может быть перемещена или удалена.
            //this.поставщикиTableAdapter.Fill(this.electronicsDBDataSet.Поставщики);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet.Товары". При необходимости она может быть перемещена или удалена.
            //this.товарыTableAdapter.Fill(this.electronicsDBDataSet.Товары);
            baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + baseDirectory + @"\ElectronicsDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
            DataSet dataSet2 = new DataSet();
            dataAdapter2.Fill(dataSet2);
            SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT * FROM Производитель", sqlConnection);
            DataSet dataSet3 = new DataSet();
            dataAdapter3.Fill(dataSet3);
            dataGridView6.DataSource = dataSet.Tables[0];
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet.Tables[0];
            dataGridView3.DataSource = dataSet.Tables[0];
            dataGridView4.DataSource = dataSet2.Tables[0];
            dataGridView5.DataSource = dataSet3.Tables[0];
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                object obj = dataGridView4.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox1.Items.Add(obj);
            }
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                object obj = dataGridView5.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox2.Items.Add(obj);
            }
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                object obj = dataGridView4.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox3.Items.Add(obj);
            }
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                object obj = dataGridView5.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox4.Items.Add(obj);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text == "" || numericUpDown1.Text == "0" || numericUpDown2.Text == "0" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    if (dataGridView4.Rows[i].Cells[1].Value.ToString() == comboBox1.Text)
                    {
                        object s = dataGridView4.Rows[i].Cells[0].Value.ToString();
                        numericUpDown6.Text = s.ToString();
                    }
                }
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (dataGridView5.Rows[i].Cells[1].Value.ToString() == comboBox2.Text)
                    {
                        object s2 = dataGridView5.Rows[i].Cells[0].Value.ToString();
                        numericUpDown7.Text = s2.ToString();
                    }
                }
                int post = Convert.ToInt32(numericUpDown6.Text);
                int firm = Convert.ToInt32(numericUpDown7.Text);
                string naim = comboBox9.Text;
                int kol = Convert.ToInt32(numericUpDown1.Text);
                int sum = Convert.ToInt32(numericUpDown2.Text);
                string vid = comboBox5.Text;
                SqlCommand command = new SqlCommand($"INSERT INTO Товары (Наименование,ВидТовара, КодПоставщика, КодПроизводителя, Количество, ЦенаТовара) VALUES (N'{naim}', N'{vid}','{post}', '{firm}', '{kol}', '{sum}')",sqlConnection);
                command.ExecuteNonQuery();     
                MessageBox.Show("Товар добавлен");
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2);
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT * FROM Производитель", sqlConnection);
                DataSet dataSet3 = new DataSet();
                dataAdapter3.Fill(dataSet3);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                dataGridView4.DataSource = dataSet2.Tables[0];
                dataGridView5.DataSource = dataSet3.Tables[0];
                comboBox8.Text = "";
                numericUpDown1.Text = "0";
                numericUpDown2.Text = "0";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (comboBox10.Text == "" || numericUpDown3.Text == "0" || numericUpDown4.Text == "0" ||  comboBox3.Text == "" || comboBox4.Text == "" || comboBox6.Text== "")
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    if (dataGridView4.Rows[i].Cells[1].Value.ToString() == comboBox3.Text)
                    {
                        object s2 = dataGridView4.Rows[i].Cells[0].Value.ToString();
                        numericUpDown6.Text = s2.ToString();
                    }
                }
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (dataGridView5.Rows[i].Cells[1].Value.ToString() == comboBox4.Text)
                    {
                        object s3 = dataGridView5.Rows[i].Cells[0].Value.ToString();
                        numericUpDown7.Text = s3.ToString();
                    }
                }
                string s = dataGridView2.CurrentCell.Value.ToString();
                SqlCommand command = new SqlCommand($"UPDATE Товары Set Наименование = N'{comboBox10.Text}' WHERE КодТовара = '{s}'", sqlConnection);
                command.ExecuteNonQuery();
                SqlCommand command6 = new SqlCommand($"UPDATE Товары Set ВидТовара = N'{ comboBox6.Text}'  WHERE КодТовара = '{s}'", sqlConnection);
                command6.ExecuteNonQuery();
                SqlCommand command4 = new SqlCommand($"UPDATE Товары Set КодПоставщика = N'{ numericUpDown6.Text}'  WHERE КодТовара = '{s}'", sqlConnection);
                command4.ExecuteNonQuery();
                SqlCommand command5 = new SqlCommand($"UPDATE Товары Set КодПроизводителя = N'{ numericUpDown7.Text}'  WHERE КодТовара = '{s}'", sqlConnection);
                command5.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand($"UPDATE Товары Set Количество = '{ numericUpDown3.Text}'  WHERE КодТовара = '{s}'", sqlConnection);
                command2.ExecuteNonQuery();
                SqlCommand command3 = new SqlCommand($"UPDATE Товары Set ЦенаТовара = '{ numericUpDown4.Text}'  WHERE КодТовара = '{s}'", sqlConnection);
                command3.ExecuteNonQuery();
                MessageBox.Show("Товар Изменен");              
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2);
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT * FROM Производитель", sqlConnection);
                DataSet dataSet3 = new DataSet();
                dataAdapter3.Fill(dataSet3);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                dataGridView4.DataSource = dataSet2.Tables[0];
                dataGridView5.DataSource = dataSet3.Tables[0];
                comboBox10.Text = "";
                numericUpDown3.Text = "0";
                numericUpDown4.Text = "0";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Text == "0")
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
                int kol_2 = Convert.ToInt32(numericUpDown5.Text);
                if (x >= kol_2)
                {
                SqlCommand command = new SqlCommand("DELETE FROM Товары WHERE КодТовара = @kod", sqlConnection);     
                command.Parameters.AddWithValue("kod", numericUpDown5.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о товаре удалены"); 
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Товары", sqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Поставщики", sqlConnection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2);
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT * FROM Производитель", sqlConnection);
                DataSet dataSet3 = new DataSet();
                dataAdapter3.Fill(dataSet3);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView3.DataSource = dataSet.Tables[0];
                dataGridView4.DataSource = dataSet2.Tables[0];
                dataGridView5.DataSource = dataSet3.Tables[0];
                }
                else
                {
                    MessageBox.Show("Такого товара не существует");
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = $"Количество <= 50";
                    break;
                case 1:
                    (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = $"Количество >= 50 AND Количество <= 300";
                    break;
                case 2:
                    (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = $"Количество >= 300";
                    break;
                case 3:
                    (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
                    

            }
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = $"ВидТовара LIKE '%{comboBox8.Text}%'";
            if (comboBox8.SelectedIndex == 8)
                (dataGridView6.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == comboBox5.Text)
                {
                    object obj = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (obj != null) comboBox9.Items.Add(obj);
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Items.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == comboBox6.Text)
                {
                    object obj = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (obj != null) comboBox10.Items.Add(obj);
                }
            }
        }
    }
}
