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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mESDBDataSet.util_state' table. You can move, or remove it, as needed.
            this.util_stateTableAdapter.Fill(this.mESDBDataSet.util_state);

        }
    }
}
