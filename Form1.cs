using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chechen_latyn_cyrillic_convertor
{
    public partial class Form1 : Form
    {
        Convertor convertor = new Convertor();
        bool to_cyrillic = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String value = convertor.convert(textBox1.Text, to_cyrillic);
            textBox2.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox2.Text;
            to_cyrillic = !to_cyrillic;
            textBox1.Text = temp;
        }
    }
}
