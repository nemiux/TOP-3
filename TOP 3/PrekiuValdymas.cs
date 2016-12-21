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
    public partial class PrekiuValdymas : Form
    {
        dbEntities1 context;   
        public PrekiuValdymas()
        {
            context = new dbEntities1();
            InitializeComponent();
            updateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NaujaPreke np = new NaujaPreke();
            np.ShowDialog();
            if(!np.cancel)
            {
                Kategorija k = context.Kategorija.FirstOrDefault(x => x.KategorijosID == np.kategorija);
                context.Preke.Add(new Preke() { Pavadinimas = np.pavadinimas, Kiekis = np.kiekis, Kaina = np.kaina, Kategorija = k });
                context.SaveChanges();
                updateTable();
            }
        }
        private void updateTable()
        {
            listView1.Items.Clear();
            context = new dbEntities1();
            var products = context.Set<Preke>();
            
            foreach (var item in products)
            {
                string[] arr = {
                    item.Kategorija.Vardas,
                    item.Kiekis.ToString(),
                    item.Kaina.ToString() };
                listView1.Items.Add(item.Pavadinimas).SubItems.AddRange(arr);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                NaujaPreke rp = new NaujaPreke(listView1.SelectedItems[0]);
                rp.ShowDialog();
                updateTable();
            }
            else MessageBox.Show("Pasirinkite prekę, kurią norite redaguoti");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string trint = listView1.SelectedItems[0].SubItems[0].Text;
            Preke trinama = (from x in context.Preke where x.Pavadinimas == trint select x).First();
            context.Preke.Remove(trinama);
            context.SaveChanges();
            updateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TopProducts tp = new TopProducts();
            tp.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateTable();
        }
    }
}
