using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_3
{
    public partial class PerkamaP : Form
    {
        dbEntities1 context = new dbEntities1();
        public bool closing = true;
        int[] indexes;
        public int sandelyje, perkama, sel;
        public PerkamaP()
        {
            InitializeComponent();
            var prekes = context.Set<Preke>();
            indexes = new int[prekes.Count()];
            int i = 0;
            foreach(var preke in prekes)
            {
                comboBox1.Items.Add(preke.Pavadinimas);
                indexes[i] = preke.prekesNr;
                i++;
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sandelyje = Int32.Parse(lblKiekis.Text);
            perkama = Int32.Parse(textBox1.Text);
            if (sandelyje < perkama) MessageBox.Show("Sandelyje yra tik " + sandelyje + " prekių, o tu bandai pirkti " + perkama);
            else
            {
                closing = false;
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sel = indexes[comboBox1.SelectedIndex];
            lblKiekis.Text = context.Preke.Where(x => x.prekesNr == sel).Select(y => y.Kiekis).FirstOrDefault().ToString();
        }
    }
}
