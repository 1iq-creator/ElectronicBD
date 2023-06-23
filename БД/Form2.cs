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

    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        public string baseDirectory;
        public string connection;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 s = new Form5();
            s.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 s = new Form7();
            s.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 s = new Form8();
            s.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            //this.заказыTableAdapter.Fill(this.electronicsDBDataSet1.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "electronicsDBDataSet1.Клиенты". При необходимости она может быть перемещена или удалена.
            //this.клиентыTableAdapter.Fill(this.electronicsDBDataSet1.Клиенты);
            baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + baseDirectory + @"\ElectronicsDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);    
            sqlConnection.Open();
           //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Клиенты", sqlConnection);
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Заказы", sqlConnection);
            DataSet dataSet2 = new DataSet();
            dataAdapter2.Fill(dataSet2);
            //dataGridView3.DataSource = dataSet.Tables[0];
            dataGridView4.DataSource = dataSet2.Tables[0];
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void button8_Click(object sender, EventArgs e)
        {
     
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabPage2.Parent = tabControl1;
            tabPage1.Parent = null;
            label5.Visible = true;
            comboBox1.Visible = true;
            string[] mas = { "0-10000", "10000-50000", "50000 и выше", "Все значения" };
            comboBox1.Items.AddRange(mas);
            tabControl1.SelectedTab = tabPage2;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Заказы.КодТовара, Наименование, SUM(Заказы.Количество) as N'Количество', SUM(Заказы.СуммаЗаказа) as N'На сумму' FROM Заказы, Товары " +
                    "WHERE Заказы.КодТовара = Товары.КодТовара GROUP BY Заказы.КодТовара, Наименование", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {           
            tabPage1.Parent = tabControl1;
            tabPage2.Parent = null;
            label5.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            tabControl1.SelectedTab = tabPage1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabPage2.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage2;
            label5.Visible = true;
            comboBox2.Visible = true;
            string[] mas = { "0-5", "5-10", "10 и выше", "Все значения" };
            comboBox2.Items.AddRange(mas);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Заказы.КодСотрудника, Фамилия, COUNT(Заказы.КодТовара) as 'Товары' FROM Заказы, Сотрудники " +
            "WHERE Заказы.КодСотрудника = Сотрудники.КодСотрудника GROUP BY Заказы.КодСотрудника, Фамилия HAVING COUNT(*) > 1", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage3;
            label6.Visible = true;
            label7.Visible = true;
            button23.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage3;
            comboBox5.Visible = true;
            label8.Visible = true;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                object obj = dataGridView3.Rows[i].Cells[1].Value.ToString();
                if (obj != null) comboBox5.Items.Add(obj);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabPage2.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage2;
            label5.Visible = true;
            comboBox4.Visible = true;
            string[] mas = { "0-200", "200-600", "600 и выше", "Все значения" };
            comboBox4.Items.AddRange(mas);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT ВидТовара as N'ВидТовара', SUM(Количество) as N'Количество'" +
                    "FROM Товары WHERE Количество IS NOT NULL GROUP BY ВидТовара", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabPage1.Parent = tabControl1;
            tabPage3.Parent = null;
            tabControl1.SelectedTab = tabPage1;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button23.Visible = false;
            label8.Visible = false;
            comboBox5.Visible = false;
            comboBox5.Items.Clear();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            tabPage3.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage3;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Наименование, ВидТовара, Количество, ЦенаТовара FROM Товары", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            int height = dataGridView2.Height;
            dataGridView2.Height = dataGridView2.Rows.Count * dataGridView2.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
            dataGridView2.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage3;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Заказы.КодСотрудника, Фамилия, Имя, Отчество, SUM(Заказы.СуммаЗаказа) as N'На сумму' FROM Заказы, Сотрудники " +
            "WHERE Заказы.КодСотрудника = Сотрудники.КодСотрудника GROUP by Заказы.КодСотрудника, Фамилия, Имя, Отчество", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tabPage2.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage2;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Заказы.КодКлиента, Фамилия, Имя, Отчество, SUM(Заказы.Количество) as N'Количество' FROM Заказы, Клиенты " +
            "WHERE Заказы.КодКлиента = Клиенты.КодКлиента GROUP by Заказы.КодКлиента, Фамилия, Имя, Отчество", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabPage2.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage2;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Товары.КодПоставщика, НазваниеПоставщика, Телефон, SUM(Товары.Количество) as N'Количество' FROM Товары, Поставщики " +
            "WHERE Товары.КодПоставщика = Поставщики.КодПоставщика GROUP by Товары.КодПоставщика, НазваниеПоставщика, Телефон", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = tabControl1;
            tabPage1.Parent = null;
            tabControl1.SelectedTab = tabPage3;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT N'Производитель' AS 'Категория', НазваниеПроизводителя AS 'Название' FROM Производитель " +
                         "UNION SELECT N'Поставщик' AS 'Категория', НазваниеПоставщика AS 'Название' FROM Поставщики;", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[На сумму] <= 10000";
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[На сумму] >= 10000 AND [На сумму] <= 50000";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[На сумму] >= 50000";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Товары <= 5";
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Товары >= 5 AND Товары <= 10";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Товары >= 10";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Количество <= 200";
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Количество >= 200 AND Количество <= 600";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Количество >= 600";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Form11 s = new Form11();
            s.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM Заказы WHERE ДатаПокупки >=CONVERT(Date,'{dateTimePicker1.Text}') AND ДатаПокупки <=CONVERT(Date,'{dateTimePicker2.Text}')", sqlConnection); 
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells[1].Value.ToString() == comboBox5.Text)
                {
                    object s = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    numericUpDown1.Text = s.ToString();
                }
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Заказы.КодКлиента, Наименование, Заказы.Количество as N'Количество', СуммаЗаказа as N'Сумма заказа' FROM Заказы, Клиенты, Товары " +
            "WHERE Заказы.КодКлиента = @kod AND Товары.КодТовара = Заказы.КодТовара GROUP by Заказы.КодКлиента, Наименование, Заказы.Количество, СуммаЗаказа ", sqlConnection);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@kod", numericUpDown1.Text);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }
    }
}
