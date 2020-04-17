using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceBox
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "GUA-" + textBox1.Text.Substring(textBox1.Text.Length - 1, 1) + textBox2.Text.Substring(0, 1) + "-" + (textBox1.Text.Length + textBox2.Text.Length).ToString();
            Form2 formsito = new Form2(name);
            formsito.Show();
            this.Close();
        }
    }
}
