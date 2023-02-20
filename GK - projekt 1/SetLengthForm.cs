using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK___projekt_1
{
    public partial class SetLengthForm : Form
    {
        public int LengthValue { get; set; }

        public SetLengthForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LengthValue = int.Parse(textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
