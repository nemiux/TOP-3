using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TOP_3
{
    public partial class NaujasVartotojas : Form
    {
        public string vardas, slaptazodis, miestas, gatve, namas, butas;
        string regex = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z]).{8,}$";
        public bool cancel = true;
        private void button2_Click(object sender, EventArgs e)
        {
            cancel = true;
            Close();
        }

        public NaujasVartotojas()
        {
            InitializeComponent();

        }
        public NaujasVartotojas(ListViewItem a)
        {
            if (a == null) return;
            InitializeComponent();
            Text = "Redaguoti vartotoją";
            button1.Text = "Atnaujinti";
            textBox1.ReadOnly = true;
            textBox1.Text = a.SubItems[0].Text;
            textBox2.Text = a.SubItems[1].Text;
            textBox4.Text = a.SubItems[2].Text;
            textBox3.Text = a.SubItems[3].Text;
            textBox6.Text = a.SubItems[4].Text;
            textBox5.Text = a.SubItems[5].Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex rg = new Regex(regex);
            if (rg.IsMatch(textBox2.Text))
            {
                cancel = false;
                vardas = textBox1.Text;
                slaptazodis = textBox2.Text;
                miestas = textBox4.Text;
                gatve = textBox3.Text;
                namas = textBox6.Text;
                butas = textBox5.Text;
                Close();
            }
            else MessageBox.Show("Slaptažodis turi turėti bent vieną didžiąją, mažąją raides bei bent vieną skaičių ir būti ne trumpesnis nei 8 simboliai");
        }
    }
}
