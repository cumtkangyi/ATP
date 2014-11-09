using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATP.TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This is a test messsage box, you can click ok to click this dialog.", "Form2");
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2 have been clicked.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("The text box text is null.");
            }
        }
    }
}
