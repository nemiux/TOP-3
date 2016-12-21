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

    public partial class NaujaPreke : Form
    {
        public string pavadinimas;
        public int prekesNr, kiekis, kategorija;
        public decimal kaina;
        public bool cancel = true;
        dbEntities1 context;
        bool update = false;
        bool kurta = false;
        public NaujaPreke()
        {
            InitializeComponent();
            context = new dbEntities1();
            var k = context.Set<Kategorija>();
            foreach(var item in k)
            {
                comboBox1.Items.Add(item.Vardas);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public NaujaPreke(ListViewItem a)
        {
            InitializeComponent();
            Text = "Prekės redagavimas";
            button2.Text = "Atnaujinti";
            context = new dbEntities1();
            var k = context.Set<Kategorija>();
            foreach (var item in k)
            {
                comboBox1.Items.Add(item.Vardas);
            }
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(a.SubItems[1].Text);
            textBox1.Text = a.SubItems[0].Text;
            textBox3.Text = a.SubItems[2].Text;
            textBox4.Text = a.SubItems[3].Text;
            pavadinimas = textBox1.Text;
            update = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            cancel = false;
            prekesNr = context.Preke.Where(x => x.Pavadinimas == pavadinimas).Select(y => y.prekesNr).FirstOrDefault();
            //MessageBox.Show("Prekes Nr: " + prekesNr.ToString());
            pavadinimas = textBox1.Text;
            kategorija = context.Kategorija.Where(x => comboBox1.Text == x.Vardas).Select(y => y.KategorijosID).FirstOrDefault();
            if (kategorija == 0)
            {
                MessageBox.Show("Kategorijos \"" + comboBox1.Text + "\" nera. Kuriama...");
                kategorija = sukurtiKategorija();

            }
            kiekis = Int32.Parse(textBox3.Text);
            kaina = Decimal.Parse(textBox4.Text);
            // INSERT
            if (update)
            {
                Preke keiciama = context.Preke.FirstOrDefault(x => x.prekesNr == prekesNr);
                keiciama.Pavadinimas = pavadinimas;
                keiciama.Kaina = kaina;
                keiciama.Kiekis = kiekis;
                Kategorija k = context.Kategorija.FirstOrDefault(x => x.KategorijosID == kategorija);
                k.Preke.Add(keiciama);
                context.SaveChanges();
                //MessageBox.Show("Keiciam " + keiciama.prekesNr + " " + keiciama.Pavadinimas +
                //    "\nJos kategorija: " + keiciama.Kategorija.Select(x=>x.KategorijosID).FirstOrDefault().ToString());
            }
            //---
            Close();
        }
        private int sukurtiKategorija()
        {
            Kategorija nauja = new Kategorija() { Vardas = comboBox1.Text};
            context.Kategorija.Add(nauja);
            context.SaveChanges();
            kurta = true;
            int catid = nauja.KategorijosID;
            //MessageBox.Show("Naujas Kategorijos ID: " + catid.ToString());
            return catid;
        }
    }
}
