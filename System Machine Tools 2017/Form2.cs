using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace System_Machine_Tools_2017
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "Время: " + DateTime.Now.ToString("HH:mm:ss");
            label4.Text = "Дата: " + DateTime.Now.ToString("MM/dd/yy");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Machine_tools;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            int a = 0;


            SqlCommand command = new SqlCommand("SELECT * FROM [Autorizetion] where Email = @loginin and Password= @passos", sqlConnection);
            // SqlCommand command = new SqlCommand("SELECT * FROM [user] where login =  textBox1.Text AND password=textBox2.Text", sqlConnection);

            command.Parameters.AddWithValue("loginin", textBox1.Text);
            command.Parameters.AddWithValue("passos", textBox2.Text);

            await command.ExecuteNonQueryAsync();

            sqlReader = await command.ExecuteReaderAsync();



            while (await sqlReader.ReadAsync())
            {
                a = Convert.ToInt32(sqlReader["Status_auto"]);
            }
           
                switch (a)
                {
                    case 1:
                        {
                            MessageBox.Show("Выш статус " + Convert.ToString(a));
                            Form1 form1;
                            form1 = new Form1();
                            form1.Show();
                            button1.Hide();
                            this.Hide();
                            break;
                        }
                    default:
                    MessageBox.Show("Такого пользователя не существует или неправльный логин и/или пароль!");
                    break;
                }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
