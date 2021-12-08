using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Machine_Tools_2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "Время: " + DateTime.Now.ToString("HH:mm:ss");
            label4.Text = "Дата: " + DateTime.Now.ToString("MM/dd/yy");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }
    }
}
