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
    public partial class Perkama : Form
    {
        int tid;
        dbEntities1 context = new dbEntities1();
        public Perkama(int transactionID, string pirkejas)
        {
            InitializeComponent();
            tid = transactionID;
            label4.Text = tid.ToString();
            label3.Text = pirkejas;
            updateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerkamaP pp = new PerkamaP();
            pp.ShowDialog();
            if (!pp.closing)
            {
                Preke preke = context.Preke.First(x => pp.sel == x.prekesNr);
                Transakcijos tr = context.Transakcijos.First(x => tid == x.transakcijosID);
                context.PerkamaPreke.Add(new PerkamaPreke() { PerkamasKiekis = pp.perkama, prekesNr = pp.sel, transakcijosID = tid, Preke = preke, Transakcijos = tr });
                context.SaveChanges();
                updateTable();
            }
        }
        private void updateTable()
        {
            listView1.Items.Clear();
            int sum = 10;
            //var buying = context.PerkamaPreke.Where(x => x.transakcijosID == tid);
            //var buying = from x in context.PerkamaPreke where x.transakcijosID == tid select x;
            var buying = (from x in context.PerkamaPreke
                          join y in context.Preke on x.prekesNr equals y.prekesNr
                          where (x.prekesNr == y.prekesNr && x.transakcijosID == tid) select new {PerkamaPreke = x, Preke = y });
            foreach (var item in buying)
            {
                
                string[] arr = { item.PerkamaPreke.PerkamasKiekis.ToString(), item.Preke.Kaina.ToString(), (item.PerkamaPreke.PerkamasKiekis*item.Preke.Kaina).ToString()};
                listView1.Items.Add(item.Preke.Pavadinimas).SubItems.AddRange(arr);


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string trint = listView1.SelectedItems[0].SubItems[0].Text;
            PerkamaPreke trinamas = (from x in context.PerkamaPreke where x.Preke.Pavadinimas.Equals(trint) select x).First();
            context.PerkamaPreke.Remove(trinamas);
            context.SaveChanges();
            updateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
